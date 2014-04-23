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
	private Vector3		m_OriginalScale;
	private Transform	m_HoldObject;
	private string 		m_InspectInput;
	private bool		m_GotInspect		 = false;
	#endregion
	
	void Start () 
	{
		m_CameraTransform	= Camera.main.transform;
		m_OriginalScale		= transform.lossyScale;
		m_HoldObject		= m_CameraTransform.FindChild("ObjectHoldPosition");
		if(GetComponent<Inspect>())
		{
			m_InspectInput	= gameObject.GetComponent<Inspect>().m_Input;
			m_GotInspect = true;
		}
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
		if(m_HoldingObject == true)
		{

				transform.localScale = m_OriginalScale * m_ChangeSize;
				transform.position = m_HoldObject.transform.position;
				transform.rotation = m_HoldObject.transform.rotation;
		
		}
		else
		{
			m_HoldingObject = false;
			//transform.localScale = m_OriginalScale;
		}
		
		m_DeActivateCounter 		= 0;
		rigidbody.useGravity 		= false;
		MoveToInspectDistance();
		rigidbody.velocity   		= Vector3.zero;
		rigidbody.angularVelocity 	= Vector3.zero;
	}
	
	void MoveToInspectDistance()
	{
		//transform.position	= Vector3.Lerp (transform.position, m_HoldObject.transform.position, Time.deltaTime * m_LerpSpeed / 10.0f);
	
		if(GetComponent<Inspect>())
		{
			GetComponent<Inspect>().OrigionalPosition =  transform.position;
		}
		m_HoldingObject = true;
	}
}
