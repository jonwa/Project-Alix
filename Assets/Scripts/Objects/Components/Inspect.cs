using UnityEngine;
using System.Collections;

/* Discription: ObjectComponent class for rotating items in fixed position in inspect mode
 * 
 * Created by: Robert Datum: 02/04-14
 * Modified by: Jimmy 03-04-14
 * 				Jon Wahlström 2014-04-14
 * 
 */

public class Inspect : ObjectComponent
{
	#region PublicMemberVariables
	public float m_Sensitivity 			  = 20.0f;
	public float m_InspectionViewDistance = 2.0f;
	public float m_LerpSpeed			  = 1f;
	public string m_Input				  = "Fire2"; 
	#endregion

	#region PrivateMemberVariables
	private Vector3 	m_OriginalPosition;
	private Quaternion  m_OriginalRotation;
	private int			m_DeActivateCounter  = 0;
	private bool		m_IsOriginalPosition = true;
	private bool		m_UnlockedCamera	 = true;
	private bool		m_ShouldMoveBack	 = false;
	#endregion


	void Start()
	{
		m_OriginalPosition = transform.position;
		m_OriginalRotation = transform.rotation;
	}

	void Update()
	{
		if(!IsActive)
		{
			if(m_ShouldMoveBack)
			{
				MoveToInspectDistance(false);
			}
			if(m_UnlockedCamera == false)
			{
				Camera.main.transform.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
				Camera.main.transform.parent.GetComponent<FirstPersonController>().UnLockPlayerMovement();
				m_UnlockedCamera = true;
			}
		}
		else
		{
			m_DeActivateCounter++;

			if(m_DeActivateCounter > 10)
			{
				DeActivate();
			}
		}
	}

	//Lerps position and rotation of the object to the inspection Mode distance and back to original position/rotation
	void MoveToInspectDistance(bool shouldInspect)
	{
		Vector3 cameraPosition 		 = Camera.main.transform.position;
		float   cameraObjectDistance = Vector3.Distance(cameraPosition, transform.position);
		float	lerpSpeed			 = m_LerpSpeed;

		if(cameraObjectDistance > m_InspectionViewDistance)
		{ 
			Vector3 targetPosition;

			if(shouldInspect)
			{
				Vector3 cameraForward  = Camera.main.transform.forward.normalized;

				cameraForward *= m_InspectionViewDistance;
				targetPosition = cameraPosition+cameraForward;
			}
			else
			{
				targetPosition	   = m_OriginalPosition;
				transform.rotation = Quaternion.Lerp(transform.rotation, m_OriginalRotation, m_LerpSpeed/10.0f);

				if(Vector3.Distance(transform.position, targetPosition) > 0.01)
				{
					m_IsOriginalPosition = false;
				}
				else
				{
					m_IsOriginalPosition = true;
					m_ShouldMoveBack = false;
				}
			}
			transform.position = Vector3.Lerp(transform.position, targetPosition, m_LerpSpeed/10.0f);
		}
	}

	public Vector3 OrigionalPosition
	{
		set { m_OriginalPosition = value; } 
	}

	public override void Interact ()
	{
		//if we are active we rotate the object with the mouse here.
		if(IsActive)
		{
			MoveToInspectDistance(true);

			float m_moveX = Input.GetAxis("Mouse X") * m_Sensitivity;
			float m_moveY = Input.GetAxis("Mouse Y") * m_Sensitivity;

			//rotates the object based on mouse input
			transform.RotateAround(collider.bounds.center,Vector3.left, m_moveY);
			transform.RotateAround(collider.bounds.center,Vector3.up, m_moveX);
		}

		//Check if we should inspect the object or not.
		if(Input.GetButton(m_Input) && m_IsOriginalPosition)
		{
			if(!IsActive)
			{
				Camera.main.transform.gameObject.GetComponent<FirstPersonCamera>().LockCamera();
				Camera.main.transform.parent.GetComponent<FirstPersonController>().LockPlayerMovement();
				m_OriginalPosition = transform.position;
				m_OriginalRotation = transform.rotation;
				m_UnlockedCamera   = false;
				m_ShouldMoveBack = true;
			}

			Activate();
			m_DeActivateCounter = 0;
		}
		else
		{
			DeActivate();
		}
		//Ignore collision with some object, determent by layer
		Physics.IgnoreLayerCollision(9, 9, true);
	}
}