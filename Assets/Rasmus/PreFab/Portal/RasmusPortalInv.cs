using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RasmusPortalInv : ObjectComponent 
{
	#region PublicMemberVariables
	public GameObject m_TargetPort;
	public int 		  m_MyHouse;
	#endregion
	
	#region PrivateMemberVariables
	private Transform m_TargetPortal = null;
	private bool 	  m_Locked;
	#endregion
	
	void Start()
	{
		if(m_TargetPort != null)
		{
			m_TargetPortal 		 = m_TargetPort.transform;
		}
		m_Locked = transform.parent.GetComponent<Locked>().GetLocked();
	}
	
	void Update()
	{
	}
	
	//When we collide with the portal we create a duplicate and 
	void OnTriggerEnter(Collider collider)
	{
		m_Locked = transform.parent.GetComponent<Locked>().GetLocked();
		if(m_TargetPortal != null && m_Locked == false)
		{
			Vector3 ExtraForward = m_TargetPortal.transform.up;
			
			float angle = m_TargetPortal.transform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y;
			collider.gameObject.transform.Rotate(0, 180+angle, 0);
			
			Quaternion q1  = Quaternion.FromToRotation(transform.up, m_TargetPortal.up);					
			Vector3 newPos = m_TargetPortal.position + q1 * (collider.transform.position - transform.position);
			
			collider.transform.position = newPos + ExtraForward;
			if(collider.CompareTag("Player"))
			{
				Camera.main.GetComponent<HouseCall>().SetHouseCall(m_TargetPort.GetComponent<RasmusPortalInv>().m_MyHouse);
			}
		}
	}
	
	//When we exit a portal we remove the object going through the portal from the hashset
	//void OnTriggerExit(Collider collider)
	//{
	//	m_Colliding.Remove(collider);
	//}
	
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
