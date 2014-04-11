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
	public int m_PortalId	  		 = 0;
	public int m_TargetPortalId 	 = 0;
	public int[] m_TargetPortals	 =  new int[PortalManager.NumberOfStages];
	#endregion

	#region PrivateMemberVariables
	private int				  m_CurrentTargetTime;
	private Transform 		  m_TargetPortal;
	private HashSet<Collider> m_Colliding = new HashSet<Collider>();
	#endregion

	void Awake()
	{
		m_TargetPortals = new int[PortalManager.NumberOfStages];
	}

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

			collider.transform.position = newPos;
		}
		collider.name = collider.name.Replace("(Clone)","");
	}

	//When we exit a portal we remove the object going through the portal from the hashset
	void OnTriggerExit(Collider collider)
	{
		m_Colliding.Remove(collider);
	}

}
