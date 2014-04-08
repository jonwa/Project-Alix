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
	private int			m_CollidedWall=0;
	private bool 		m_HoldingObject=false;
	private bool 		m_Move=true;
	//private bool 		m_Colliding=false;
	#endregion
	
	
	void Start()
	{
		m_CameraTransform  = Camera.main.transform;
	}
	
	void Update()
	{
		//Turn on everything again if objects stops being pickup
		m_DeActivateCounter++;
		if(m_DeActivateCounter > 10)
		{
			Physics.IgnoreLayerCollision(9, 9, false);
			rigidbody.useGravity=true;
			m_HoldingObject=false;
		}
		if(m_CollidedWall>0)
		{
			m_CollidedWall--;
		}
	}

	//Moves the object towards the camera
	void MoveToInspectDistance(bool shouldInspect)
	{
		if(m_CameraTransform==null)
		{
			m_CameraTransform = Camera.main.transform;
		}
		Vector3 cameraPosition 		 = m_CameraTransform.position;
		float   cameraObjectDistance = Vector3.Distance(cameraPosition, transform.position);
		
		if(cameraObjectDistance-0.3 >= m_InspectionViewDistance)
		{ //Move object closer to camera
			Vector3 targetPosition;
			Vector3 cameraForward  = m_CameraTransform.forward.normalized;
			
			cameraForward *= m_InspectionViewDistance;
			targetPosition = cameraPosition+cameraForward;
			transform.position = Vector3.Lerp(transform.position, targetPosition, m_LerpSpeed/10.0f);
		}
		else
		{//When the object is close to the camera
			m_HoldingObject=true;
		}
	}

	public override void Interact ()
	{
		if(m_CollidedWall==0)
		{
			m_DeActivateCounter=0;

			//Object is close enough and allowed to move
			if(m_HoldingObject == true && m_Move == true)
			{
				Vector3 cameraPosition = m_CameraTransform.position;

				Vector3 targetPosition;

				Vector3 cameraForward  = m_CameraTransform.forward.normalized;
					
				cameraForward *= m_InspectionViewDistance;
				targetPosition = cameraPosition+cameraForward;



				//transform.position = targetPosition;
				transform.position = Vector3.Lerp(transform.position, targetPosition, m_LerpSpeed/10f);
				//transform.rotation = m_CameraTransform.rotation;
			}
			//Used to stop the object rotating/fallen while holding
			rigidbody.useGravity=false;
			MoveToInspectDistance(true);
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			//Ignore collision with some object, determent by layer
			Physics.IgnoreLayerCollision(9, 9, true);
		}
	}

	//Check collison
	public void OnCollisionEnter(Collision col)
	{
		//With wall, release the object
		if(m_HoldingObject == true)
		{
			if(col.collider.CompareTag("Wall"))
			{
				m_Move=false;
				m_CollidedWall=40;
				//Debug.Log("Krockat med vägg");
				Camera.main.SendMessage("Release");
			}
			else//Collision with other object, don't collide
			{
				//Won't collide thanks to :"Physics.IgnoreLayerCollision(9, 9, true);"
				//Debug.Log("Krockat med ngt annat");
				//collider.enabled=false;
			}
		}
		//m_Colliding=true;
	}

	public void OnCollisionExit()
	{
		//m_Colliding=false;
		collider.enabled=true;
		m_Move=true;
	}

	//public bool IsColliding()
	//{
	//	return m_Colliding;
	//}
}