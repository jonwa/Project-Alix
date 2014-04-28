using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
/* Description: Makes the object able to pass through portals
 * 
 * Created by: Jimmy  Date: 2014-04-07
 * Modified by:
 */

public class Portal : ObjectComponent 
{
	#region PublicMemberVariables
	//public int m_PortalId	  		 = 0;
	//public int m_TargetPortalId 	 = 0;
	//public int[] m_TargetPortals	 =  new int[PortalManager.NumberOfStages];
	#endregion

	#region PrivateMemberVariables
	private int				  m_TargetPortalCounter = 0;
	private int				  m_CurrentTargetTime;
	private Transform 		  m_TargetPortal;
	private HashSet<Collider> m_Colliding = new HashSet<Collider>();
	#endregion

	void Awake()
	{
		m_TargetPortal  = transform.parent.GetComponent<PortalPairHandler>().GetRemotePortal(transform.name);
	}

	//Gets the portal that the player should be ported to from this one. And sets
	public Transform  GetTargetPortal()
	{
		return transform.parent.GetComponent<PortalPairHandler>().GetRemotePortal(transform.name);;
	}
	

	//When we collide with the portal we create a duplicate and 
	void OnTriggerEnter(Collider collider)
	{
		if (!m_Colliding.Contains(collider)) 
		{
			m_TargetPortal = transform.parent.GetComponent<PortalPairHandler>().GetRemotePortal(transform.name);
			Vector3 ExtreForward = m_TargetPortal.transform.forward;

			float angle = m_TargetPortal.transform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y;
			collider.gameObject.transform.Rotate(0, 180+angle, 0);

			Quaternion q1  = Quaternion.FromToRotation(transform.up, m_TargetPortal.up);					
			Vector3 newPos = m_TargetPortal.position + q1 * (collider.transform.position - transform.position);
	
			if (collider.rigidbody != null) 
			{
				GameObject o = (GameObject) GameObject.Instantiate(collider.gameObject, newPos, collider.gameObject.transform.rotation);

				o.rigidbody.velocity 		= ((q1 * collider.rigidbody.velocity))*(-1);
				o.rigidbody.velocity 		= Quaternion.AngleAxis(angle, Vector3.up)*o.rigidbody.velocity;
				o.rigidbody.angularVelocity = (collider.rigidbody.angularVelocity);

				collider.gameObject.SetActive(false);
				Destroy(collider.gameObject);
				collider = o.collider;
			}

			m_TargetPortal.GetComponent<Portal>().m_Colliding.Add(collider);

			collider.transform.position = newPos + ExtreForward;
		}
		collider.name = collider.name.Replace("(Clone)","");
	}

	//When we exit a portal we remove the object going through the portal from the hashset
	void OnTriggerExit(Collider collider)
	{
		m_Colliding.Remove(collider);
	}

	public void SetTargetPortal(Transform target)
	{
		m_TargetPortal = target;
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
