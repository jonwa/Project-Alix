using UnityEngine;
using System.Collections;

/* Discription: ObjectComponent class for rotating items in fixed position in inspect mode
 * 
 * 
 * 
 */

[RequireComponent(typeof(Collider))]
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
	private bool 		m_HoldingObject=false;
	private bool 		m_move=true;
	#endregion
	
	
	void Start()
	{
		m_CameraTransform  = Camera.main.transform;
	}
	
	void Update()
	{
		if(!GetIsActive())
		{
			MoveToInspectDistance(false);
			m_HoldingObject=false;
			//m_CameraTransform.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
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
				transform.position = Vector3.Lerp(transform.position, targetPosition, m_LerpSpeed/10.0f);
			}
		}
		else
		{
			m_HoldingObject=true;
		}
	}
	
	public override void Interact ()
	{
		if(GetIsActive())
		{
			MoveToInspectDistance(true);

			if(m_HoldingObject == true && m_move == true){
				Vector3 cameraPosition = m_CameraTransform.position;

				Vector3 targetPosition;

				Vector3 cameraForward  = m_CameraTransform.forward.normalized;
				
				cameraForward *= m_InspectionViewDistance;
				targetPosition = cameraPosition+cameraForward;

				transform.position = targetPosition;
			}
			//Vector3.Lerp(transform.position, targetPosition, m_LerpSpeed/10.0f);
		}
		
		//Check if we should inspect the object or not.
		if(Input.GetButton(m_Input))
		{
			Activate();
			m_DeActivateCounter = 0;
		}
		else
		{
			DeActivate();
		}
	}

	public void OnCollisionEnter()
	{
		Debug.Log("Krock");
		//collider.transform.localScale.Set(1.5f, 1.5f, 1.5f);
		//m_move=false;
	}

	public void OnCollisionExit()
	{
		Debug.Log("Slut Krock");
		//collider.transform.localScale.Set(1.0f, 1.0f, 1.0f);
		m_move=true;
	}

}