using UnityEngine;
using System.Collections;

/* Discription: ObjectComponent class for rotating items in fixed position in inspect mode
 * 
 * 
 * 
 */

[RequireComponent(typeof(Rigidbody))]
public class PickUp : ObjectComponent
{
	#region PublicMemberVariables
	public float m_Sensitivity 			  = 20.0f;
	public float m_InspectionViewDistance = 2.0f;
	public float m_LerpSpeed			  = 1f;
	public string m_Input				  = "Fire2";
	#endregion



	#region PrivateMemberVariables
	private Transform   m_CameraTransform;
	private int			m_DeActivateCounter;
	private int			m_Collided=0;
	private bool 		m_HoldingObject=false;
	private bool 		m_Move=true;
	#endregion
	
	
	void Start()
	{
		m_CameraTransform  = Camera.main.transform;
	}
	
	void Update()
	{
		m_DeActivateCounter++;
		if(m_DeActivateCounter > 10)
		{
			rigidbody.useGravity=true;
			m_HoldingObject=false;
		}
		if(m_Collided>0)
		{
			m_Collided--;
		}
		//Interact();
		/*if(!GetIsActive())
		{
			MoveToInspectDistance(false);
			rigidbody.useGravity=true;
			m_HoldingObject=false;
			//m_CameraTransform.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
		}
		else
		{
			rigidbody.useGravity=false;
			m_DeActivateCounter++;
			if(m_DeActivateCounter > 10)
				DeActivate();
		}*/
	}
	
	//Lerps position and rotation of the object to the inspection Mode distance and back to original position/rotation
	void MoveToInspectDistance(bool shouldInspect)
	{
		Vector3 cameraPosition 		 = m_CameraTransform.position;
		float   cameraObjectDistance = Vector3.Distance(cameraPosition, transform.position);
		
		if(cameraObjectDistance-0.2 >= m_InspectionViewDistance)
		{ 
			Vector3 targetPosition;
			Vector3 cameraForward  = m_CameraTransform.forward.normalized;
			
			cameraForward *= m_InspectionViewDistance;
			targetPosition = cameraPosition+cameraForward;
			transform.position = Vector3.Lerp(transform.position, targetPosition, m_LerpSpeed/10.0f);
		}
		else
		{
			m_HoldingObject=true;
		}
	}
	
	public override void Interact ()
	{
		if(m_Collided==0){
			rigidbody.useGravity=false;
			m_DeActivateCounter=0;

			if(m_HoldingObject == true && m_Move == true){
				Vector3 cameraPosition = m_CameraTransform.position;

				Vector3 targetPosition;

				Vector3 cameraForward  = m_CameraTransform.forward.normalized;
					
				cameraForward *= m_InspectionViewDistance;
				targetPosition = cameraPosition+cameraForward;

				transform.position = targetPosition;
			}
			
			//Check if we should inspect the object or not.
			if(Input.GetButton(m_Input))
			{
				MoveToInspectDistance(true);
			}
		}
	}

	public void OnCollisionEnter()
	{
		Debug.Log("Krock");
		m_Move=false;
		m_Collided=30;
	}

	public void OnCollisionExit()
	{
		Debug.Log("Slut Krock");
		m_Move=true;
	}

}