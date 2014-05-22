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
	public float 		m_ScaleTime			= 30f;
	#endregion

	#region PrivateMemberVariables
	private LayerMask	m_LayerMask = (1 << 0) | (1 << 1) |  (1 << 3) | (1 << 4) | (1 << 5) | (1 << 6) | (1 << 7) | (1 << 9) | (1 << 10) | (1 << 11) |  (1 << 14) | (1 << 15) | (1 << 16);
	private float 		m_DropPointMax = 2.0f;	//Här kan du ändra martin.. 
	private float		m_DropDistance = 2.0f; 
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
				transform.localScale = Vector3.Lerp(transform.localScale, m_OriginalScale, Time.deltaTime * m_ScaleTime);
				if(m_DeActivateCounter == 5)
				{
					Cast();
					transform.position = m_CameraTransform.position + (m_CameraTransform.forward * m_DropDistance);
					rigidbody.velocity   		= Vector3.zero;
					rigidbody.angularVelocity 	= Vector3.zero;
					m_HoldingObject = false;
				}

			}
		}
	}

	public bool GetHoldingObject()
	{
		return m_HoldingObject;
	}

	public override void Interact ()
	{
		Camera.main.GetComponent<Raycasting>().IsPickedUp = true; 
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
		m_HoldingObject = true;
	}

	void Cast()
	{
		RaycastHit hit;
		Ray ray = new Ray(m_CameraTransform.transform.position, m_CameraTransform.transform.forward);
		Debug.DrawRay (ray.origin, ray.direction * m_DropPointMax, Color.magenta);

		if (Physics.Raycast (ray, out hit, m_DropPointMax))
		{
			m_DropDistance = Vector3.Distance(hit.point, m_CameraTransform.position);
			Debug.Log(m_DropDistance);
			m_DropDistance *= 0.88f;
			Debug.Log(m_DropDistance);
		}
		else
		{
			m_DropDistance = m_DropPointMax;
		}
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
