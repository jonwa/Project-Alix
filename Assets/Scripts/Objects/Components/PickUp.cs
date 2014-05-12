using UnityEngine;
using System.Collections;


/* Discription: Class for picking up an object and holding in front of you
 * 
 * Created By: Rasmus 04/04
 * Modified by: Sebastian 23-04-2014 : Changed so pickup put the object in the bottom right corner 
 */
//TODO: Fix Interact

[RequireComponent(typeof(Gravity))]
[RequireComponent(typeof(Rigidbody))]
public class PickUp : ObjectComponent 
{
	#region PublicMemberVariables
	[Range(0, 2)]public float m_ChangeSize	= 0.80f;
	public float m_ScaleTime			  	= 30f;
	public float m_DropPoint				= 10f;
	#endregion
	
	#region PrivateMemberVariables
	private Transform   m_CameraTransform;
	private int			m_DeActivateCounter;
	private bool 		m_HoldingObject		 = false;
	private Vector3		m_OriginalScale;
	private Transform	m_HoldObject;
	private bool 		isInspecting = false;
	#endregion
	
	void Start () 
	{
		m_CameraTransform	= Camera.main.transform;
		m_OriginalScale		= transform.lossyScale;
		m_HoldObject		= m_CameraTransform.FindChild("ObjectHoldPosition");
		m_HoldingObject 	= false;
	}
	
	void Update () 
	{	
		m_DeActivateCounter++;
		if(m_DeActivateCounter >= 5)
		{
			if((m_OriginalScale-transform.localScale).magnitude > 0.001f)
			{
				Physics.IgnoreLayerCollision(9, 9, false);
				transform.localScale = Vector3.Lerp(transform.localScale, m_OriginalScale, Time.deltaTime * m_ScaleTime);
				transform.position = m_CameraTransform.parent.transform.position + (m_CameraTransform.parent.transform.forward * m_DropPoint);
				m_HoldingObject = false;
			}
		}
	}
	
	public override void Interact ()
	{
		if(gameObject.GetComponent<Inspect>())
		{		
			isInspecting = gameObject.GetComponent<Inspect>().IsInspecting;
		}
		if(m_HoldingObject && !isInspecting)
		{
			transform.localScale = m_OriginalScale * m_ChangeSize;
			transform.position = m_HoldObject.transform.position;
			transform.rotation = m_HoldObject.transform.rotation;
	
			m_DeActivateCounter 		= 0;
			rigidbody.velocity   		= Vector3.zero;
			rigidbody.angularVelocity 	= Vector3.zero;
			rigidbody.useGravity 		= false;
		}
		MoveToInspectDistance();
	}
	
	void MoveToInspectDistance()
	{	
		if(GetComponent<Inspect>() && !isInspecting)
		{
			GetComponent<Inspect>().OriginalPosition = transform.position;
		}
		m_HoldingObject = true;
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
