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
	private bool		m_IsInspecting		 = false;
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
			if(m_DeActivateCounter > 4 &&  m_UnlockedCamera == false && m_IsOriginalPosition && Quaternion.Angle(transform.rotation, m_OriginalRotation) < 0.5f)
			{
				Camera.main.transform.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
				Camera.main.transform.parent.GetComponent<FirstPersonController>().UnLockPlayerMovement();
				m_UnlockedCamera = true;
				m_ShouldMoveBack = false;
				m_IsOriginalPosition = true;
				m_IsInspecting = false;
				if(gameObject.GetComponent<PickUp>() == null){
					Camera.main.GetComponent<Raycasting>().Release();
				}

			}
			m_DeActivateCounter++;
		}
		else
		{
			m_DeActivateCounter++;
			if(m_DeActivateCounter > 5)
			{
				m_ShouldMoveBack = true;
			}
		}
	}

	//Lerps position and rotation of the object to the inspection Mode distance and back to original position/rotation
	void MoveToInspectDistance(bool shouldInspect)
	{
		Vector3 cameraPosition 		 = Camera.main.transform.position;
		Vector3 targetPosition;
		float   cameraObjectDistance = Vector3.Distance(cameraPosition, transform.position);
		float	lerpSpeed			 = m_LerpSpeed;

		if(shouldInspect)
		{
			Vector3 cameraForward  = Camera.main.transform.forward.normalized;
			cameraForward *= m_InspectionViewDistance;
			targetPosition = cameraPosition+cameraForward;
			transform.position = Vector3.Lerp(transform.position, targetPosition, m_LerpSpeed/10.0f);
			m_IsOriginalPosition = false;


			if(gameObject.GetComponent<Rigidbody>() != null)
			{
				gameObject.GetComponent<Gravity>().SetGravity(false);
				rigidbody.velocity   		= Vector3.zero;
				rigidbody.angularVelocity 	= Vector3.zero;
			}
		}
		else
		{
			if(Vector3.Distance(transform.position, m_OriginalPosition) > 0.01f  || Quaternion.Angle(transform.rotation, m_OriginalRotation) > 0.2f)
			{
				m_IsOriginalPosition = false;
				transform.rotation = Quaternion.Lerp(transform.rotation, m_OriginalRotation, lerpSpeed/10.0f);
				transform.position = Vector3.Lerp(transform.position, m_OriginalPosition, lerpSpeed/10.0f);
			}
			else if(Vector3.Distance(transform.position, m_OriginalPosition) < 0.03f && Quaternion.Angle(transform.rotation, m_OriginalRotation) < 0.5f)
			{
				m_IsOriginalPosition = true;
				m_ShouldMoveBack 	 = false;
				if(gameObject.GetComponent<Rigidbody>() != null)
				{
					gameObject.GetComponent<Gravity>().SetGravity(true);
				}
			}
		}
	}

	public Vector3 OriginalPosition
	{
		set { m_OriginalPosition = value; } 
	}

	public override void Interact ()
	{


		//Check if we should inspect the object or not.
		if(Input.GetButton(m_Input)/* && m_IsOriginalPosition*/)
		{
			if(!IsActive)
			{
				Camera.main.transform.gameObject.GetComponent<FirstPersonCamera>().LockCamera();
				Camera.main.transform.parent.GetComponent<FirstPersonController>().LockPlayerMovement();
				if(gameObject.GetComponent<PickUp>() != null){
					m_OriginalPosition = transform.position;
					m_OriginalRotation = transform.rotation;
				}
				m_UnlockedCamera   = false;
				m_ShouldMoveBack = true;
			}
			Activate();
			m_DeActivateCounter = 0;
		}

		//if we are active we rotate the object with the mouse here.
		if(IsActive)
		{
			if(Input.GetButton(m_Input)){
				Camera.main.GetComponent<Raycasting>().IsPickedUp = true; 
				MoveToInspectDistance(true);
				
				float m_moveX = Input.GetAxis("Mouse X") * m_Sensitivity;
				float m_moveY = Input.GetAxis("Mouse Y") * m_Sensitivity;
				
				//rotates the object based on mouse input
				transform.RotateAround(collider.bounds.center,Vector3.left, m_moveY);
				transform.RotateAround(collider.bounds.center,Vector3.up, m_moveX);
				m_IsInspecting = true;
			}
			else 
			{
				m_ShouldMoveBack = true;
				Debug.Log("Yolo");
				DeActivate();
			}
		}
	}
	public bool IsInspecting
	{
		get{ return m_IsInspecting; }
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}