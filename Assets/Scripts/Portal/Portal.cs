using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Description: Makes the object able to pass through portals
 * 
 * Created by: Jimmy  Date: 2014-04-07
 * Modified by:
 */

public class Portal : ObjectComponent 
{
	#region PublicMemberVariables'
	public int m_PortalId	  = 0;
	public int m_TargetPortalId = 0;
	#endregion
	#region PrivateMemberVariables
	private Transform 		  m_TargetPortal;
	private HashSet<Collider> m_Colliding = new HashSet<Collider>();
	#endregion

	//Gets the portal that the player should be ported to from this one. And sets
	void  GetTargetPortal()
	{
		Portal[] portals =  Object.FindObjectsOfType<Portal>();

		foreach(Portal p in portals)
		{
			if(p.m_PortalId == m_TargetPortalId)
			{
				m_TargetPortal = p.transform;
			}
		}

	}

	//When we collide with the portal we create a duplicate and 
	void OnTriggerEnter(Collider collider)
	{
		if (!m_Colliding.Contains(collider)) 
		{
			if(m_TargetPortal == null)
			{
				GetTargetPortal(); 
			}

			Quaternion q1 = Quaternion.FromToRotation(transform.up, m_TargetPortal.up);
			Quaternion q2 = Quaternion.FromToRotation(-transform.up, m_TargetPortal.up);
			
			Vector3 newPos = m_TargetPortal.position + q2 * (collider.transform.position - transform.position);// + OtherEnd.transform.up * 2;;
			
			if (collider.rigidbody != null) 
			{
				GameObject o = (GameObject) GameObject.Instantiate(collider.gameObject, newPos, collider.transform.localRotation);
				o.rigidbody.velocity = q2 * collider.rigidbody.velocity;
				o.rigidbody.angularVelocity = collider.rigidbody.angularVelocity;
				collider.gameObject.SetActive(false);
				Destroy(collider.gameObject);
				collider = o.collider;
			}

			//Calc rotation
			Vector3 targetFwd = m_TargetPortal.forward;
			Vector3 cFwd	  = collider.transform.forward;
			collider.transform.forward = Vector3.Reflect(cFwd, targetFwd);


			m_TargetPortal.GetComponent<Portal>().m_Colliding.Add(collider);
			
			collider.transform.position = newPos;
			
			Vector3 fwd = collider.transform.forward;
			
			if (collider.rigidbody == null) 
			{
				collider.transform.LookAt(collider.transform.position + q2 * fwd, m_TargetPortal.transform.forward);
			}

		}
		collider.name = collider.name.Replace("(Clone)","");
	}

	//When we exit a portal we remove the object going through the portal from the hashset
	void OnTriggerExit(Collider collider)
	{
		m_Colliding.Remove(collider);
	}

}
