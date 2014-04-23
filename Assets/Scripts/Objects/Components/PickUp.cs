using UnityEngine;
using System.Collections;


/* Discription: Class for picking up an object and holding in front of you
 * 
 * Created By: Rasmus 04/04
 * Modified by: Sebastian 22-04-2014 : Changed so pickup put the object in the bottom right corner 
 */
//TODO: Add so dempending on FOV the object will have the same position
//: Fix Interact

[RequireComponent(typeof(Gravity))]
[RequireComponent(typeof(Rigidbody))]
public class NewPickUp : ObjectComponent 
{
	#region PublicMemberVariables
	public float m_Sensitivity 			  	= 20.0f;
	public float m_InspectionViewDistance 	= 2.0f;
	public float m_LerpSpeed			  	= 10f;
	public string m_Input				  	= "Fire1";
	[Range(0, 1)]public float m_ChangeSize	= 0.80f;
	public float m_ScaleTime			  	= 30f;
	#endregion
	
	#region PrivateMemberVariables
	private Transform   m_CameraTransform;
	private int			m_DeActivateCounter;
	private bool 		m_HoldingObject		 = false;
	private bool 		m_Move				 = true;
	private Vector3		m_OriginalScale;
	private Transform	m_HoldObject;
	#endregion
	
	void Start () 
	{
		m_CameraTransform = Camera.main.transform;
		m_OriginalScale = transform.lossyScale;
	}
	
	void Update () 
	{		
		m_DeActivateCounter++;
		if(m_DeActivateCounter >= 5)
		{
			Physics.IgnoreLayerCollision(9, 9, false);
			transform.localScale = Vector3.Lerp(transform.localScale, m_OriginalScale, Time.deltaTime * m_ScaleTime);
			m_HoldingObject = false;
		}
		
	}
	
	public override void Interact ()
	{
		if(m_HoldingObject == true && m_Move == true)
		{
			transform.localScale = m_OriginalScale * m_ChangeSize;
			m_HoldObject = m_CameraTransform.FindChild("ObjectHoldPosition");
			transform.position = m_HoldObject.transform.position;
			transform.rotation = m_HoldObject.transform.rotation;
		}
		else
		{
			transform.localScale = m_OriginalScale;
		}
		
		m_DeActivateCounter 		= 0;
		rigidbody.useGravity 		= false;
		MoveToInspectDistance(true);
		rigidbody.velocity   		= Vector3.zero;
		rigidbody.angularVelocity 	= Vector3.zero;
	}
	
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
		{
<<<<<<< HEAD
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
=======
			m_HoldingObject = true;
>>>>>>> 3940a689e665ddfa21cc47153f575d347ecbe045
		}
	}
}
