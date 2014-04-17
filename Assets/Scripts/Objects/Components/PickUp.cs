using UnityEngine;
using System.Collections;


/* Discription: Class for picking up an object and holding in front of you
 * 
 * Created By: Rasmus 04/04
 */

[RequireComponent(typeof(Gravity))]
[RequireComponent(typeof(Rigidbody))]
public class PickUp : ObjectComponent
{
	#region PublicMemberVariables
	public float m_Sensitivity 			  = 20.0f;
	public float m_InspectionViewDistance = 2.0f;
	public float m_LerpSpeed			  = 10f;
	public string m_Input				  = "Fire1";
	#endregion

	#region PrivateMemberVariables
	private Transform   m_CameraTransform;
	private int			m_DeActivateCounter;
	private int			m_CollidedWall		 = 0;
	private bool 		m_HoldingObject		 = false;
	private bool 		m_Move				 = true;
	//private bool 		m_Colliding=false;
	#endregion
	
	
	void Start()
	{
		m_CameraTransform = Camera.main.transform;
		m_CameraTransform  = Camera.main.transform;
	}
	
	void Update()
	{
		//Turn on everything again if objects stops being pickup
		m_DeActivateCounter++;
		if(m_DeActivateCounter > 10)
		{
			Physics.IgnoreLayerCollision(9, 9, false);
			//rigidbody.useGravity=true;
			m_HoldingObject = false;
			//Color test=renderer.material.color;
			//test.a=1.0f;
			//renderer.material.color = test;
		}
		if(m_CollidedWall > 0)
		{
			m_CollidedWall--;
		}
	}

	//Moves the object towards the camera
	void MoveToInspectDistance(bool shouldInspect)
	{
		if(m_CameraTransform == null)
		{
			m_CameraTransform = Camera.main.transform;
		}
		Vector3 cameraPosition 		 = m_CameraTransform.position;
		float   cameraObjectDistance = Vector3.Distance(cameraPosition, transform.position);
		
		if(cameraObjectDistance-0.3 >= m_InspectionViewDistance)
		{ //Move object closer to camera
			Vector3 targetPosition;
			Vector3 cameraForward = m_CameraTransform.forward.normalized;
			

			cameraForward *= m_InspectionViewDistance;
			targetPosition = cameraPosition+cameraForward;
			if(gameObject.GetComponent<MovementLimit>())
			{
				targetPosition = gameObject.GetComponent<MovementLimit>().CheckPosition(targetPosition);
			}
			transform.position = Vector3.Lerp(transform.position, targetPosition, m_LerpSpeed/10.0f);

			if(GetComponent<Inspect>())
			{
				GetComponent<Inspect>().OrigionalPosition =  transform.position;
			}
		}
		else
		{//When the object is close to the camera
			m_HoldingObject = true;
		}
	}

	public override void Interact ()
	{
		//Debug.Log(m_CameraTransform.forward.x);
		if(m_CollidedWall == 0)
		{
			//Color test=renderer.material.color;
			//test.a=0.5f;
			//renderer.material.color = test;
			//float alpha=0.5f;
			//renderer.material.color.a = alpha;
			m_DeActivateCounter = 0;

			//Object is close enough and allowed to move
			if(m_HoldingObject == true && m_Move == true)
			{
				Vector3 cameraPosition  = m_CameraTransform.position;
				Vector3 cameraForward   = m_CameraTransform.forward.normalized;
				Vector3 targetPosition;
					

				//cameraForward  			*= m_InspectionViewDistance;
				//targetPosition 			= cameraPosition+cameraForward;
				//transform.position 		= Vector3.Lerp(transform.position, targetPosition, m_LerpSpeed/10f);

				cameraForward *= m_InspectionViewDistance;
				targetPosition = cameraPosition+cameraForward;
				if(gameObject.GetComponent<MovementLimit>())
				{
					targetPosition = gameObject.GetComponent<MovementLimit>().CheckPosition(targetPosition);
				}

				//transform.position = targetPosition;
				//transform.position = Vector3.Lerp(transform.position, targetPosition, m_LerpSpeed/10f);
				transform.position = targetPosition;
				//transform.rotation = m_CameraTransform.rotation;

			}
			//Used to stop the object rotating/fallen while holding
			rigidbody.useGravity 		= false;
			MoveToInspectDistance(true);
			rigidbody.velocity   		= Vector3.zero;
			rigidbody.angularVelocity 	= Vector3.zero;
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
				m_Move 		   = false;
				m_CollidedWall = 40;
				//Debug.Log("Krockat med vägg");
				Camera.main.SendMessage("Release");
			}
			else//Collision with other object, don't collide
			{
				//Debug.Log("Krockat med ngt");
			}
		}
		//m_Colliding=true;
	}

	public void OnCollisionExit()
	{
		//m_Colliding=false;
		collider.enabled = true;
		m_Move			 = true;
	}

	//public bool IsColliding()
	//{
	//	return m_Colliding;
	//}
}