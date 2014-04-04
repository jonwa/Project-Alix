using UnityEngine;
using System.Collections;

/* Discription: ObjectComponent class for rotating items in fixed position in inspect mode
 * 
 * Created by: Robert Datum: 02/04-14
 * Modified by: Jimmy 03-04-14
 * 
 */

public class Inspect : ObjectComponent
{
	#region PublicMemberVariables
	public float m_Sensitivity 			  = 20.0f;
	public float m_InspectionViewDistance = 2.0f;
	public float m_LerpSpeed			  = 1f;
	public string m_Input;
	#endregion

	#region PrivateMemberVariables
	private Vector3 	m_OriginalPosition;
	private Quaternion  m_OriginalRotation;
	private Transform   m_CameraTransform;
	private int			m_DeActivateCounter;
	#endregion


	void Start()
	{
		m_CameraTransform  = Camera.main.transform;
		m_OriginalPosition = transform.position;
		m_OriginalRotation = transform.rotation;
	}

	void Update()
	{
		if(!GetIsActive())
		{
			MoveToInspectDistance(false);
			m_CameraTransform.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
		}
		else
		{
			m_DeActivateCounter++;
			if(m_DeActivateCounter > 10)
				DeActivate();
		}
	}

	//Lerps position and rotation of the object to the inspection Mode distance and back to original position/rotation
	void MoveToInspectDistance(bool shouldInspect)
	{
		Vector3 cameraPosition 		 = m_CameraTransform.position;
		float   cameraObjectDistance = Vector3.Distance(cameraPosition, transform.position);

		if(cameraObjectDistance > m_InspectionViewDistance)
		{ 
			Vector3 targetPosition;
			if(shouldInspect)
			{
				Vector3 cameraForward  = m_CameraTransform.forward.normalized;

				cameraForward *= m_InspectionViewDistance;
				targetPosition = cameraPosition+cameraForward;
			}
			else
			{
				targetPosition = m_OriginalPosition;
				transform.rotation = Quaternion.Lerp(transform.rotation, m_OriginalRotation, m_LerpSpeed/10.0f);
			}
			transform.position = Vector3.Lerp(transform.position, targetPosition, m_LerpSpeed/10.0f);
		}
	}

	public override void Interact ()
	{
		if(GetIsActive())
		{
			MoveToInspectDistance(true);

			float m_moveX = Input.GetAxis("Mouse X") * m_Sensitivity;
			float m_moveY = Input.GetAxis("Mouse Y") * m_Sensitivity;

			//state changed to inspecting or camera is locked

			//rotates the object based on mouse input
			transform.RotateAround(collider.bounds.center,Vector3.left, m_moveY);
			transform.RotateAround(collider.bounds.center,Vector3.up, m_moveX);
		}

		//Check if we should inspect the object or not.
		if(Input.GetButton(m_Input))
		{
			if(!GetIsActive())
			{
				m_CameraTransform.gameObject.GetComponent<FirstPersonCamera>().LockCamera();
				m_OriginalPosition = transform.position;
				m_OriginalRotation = transform.rotation;
			}
			Activate();
			m_DeActivateCounter = 0;
		}
		else
		{
			DeActivate();
		}
	}

}