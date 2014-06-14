using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/* Description: Makes the object able to pass through portals, also tales the camera which House the player will be in and sets the targetHouse
 * Made for tripleportals, it now has 2 target portals to choose between
 * 
 * Created by: Rasmus 28/4, made from Jimmy's code
 * Modified by:
 */

public class RasmusPortal2 : ObjectComponent 
{
	#region PublicMemberVariables
	public GameObject m_TargetPort;
	public GameObject m_TargetPort2;
	public int		  m_MyHouse;
	#endregion
	
	#region PrivateMemberVariables
	private Transform 		  m_TargetPortal;
	private HashSet<Collider> m_Colliding = new HashSet<Collider>();
	private RenderTexture	  m_Texture;
	#endregion
	
	void Start()
	{
		m_Texture = transform.parent.transform.parent.GetComponent<PortalTexture>().GetTextureForPortal();
		//m_Texture = new RenderTexture(512,512,24);
		MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
		mr.material = new Material(mr.material);
		mr.material.mainTexture = m_Texture;
		//m_Material = mr.material;
		//Debug.Log("Startar");
	}
	
	void Update()
	{
		m_Texture = transform.parent.transform.parent.GetComponent<PortalTexture>().GetTextureForPortal();
		renderer.material.mainTexture = m_Texture;
		CheckTargetHouse();
		//Camera targetCam = transform.parent.GetComponent<Camera>().camera;
		//targetCam.targetTexture  = m_Texture;
	}

	private void CheckTargetHouse()
	{
		int targetHouse = Camera.main.GetComponent<HouseCall>().GetTargetHouse();
		if(targetHouse == m_TargetPort.GetComponent<RasmusPortal2>().m_MyHouse)
		{
			m_TargetPortal = m_TargetPort.transform;
		}
		else if(targetHouse == m_TargetPort2.GetComponent<RasmusPortal2>().m_MyHouse)
		{
			m_TargetPortal = m_TargetPort2.transform;
		}
		else
		{
			gameObject.SetActive(false);
		}
	}

	//When we collide with the portal we create a duplicate and 
	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.GetComponent<PickUp>() != null && collider.gameObject.GetComponent<PickUp>().GetHoldingObject() == true)
		{
			
		}
		else
		{
			//m_TargetPortal 		 = m_TargetPort.transform;
			Vector3 ExtraForward = m_TargetPortal.transform.up;
			//Debug.Log(m_TargetPortal.transform.up.x + " " + m_TargetPortal.transform.up.y + " " + m_TargetPortal.transform.up.z);
			//if(m_TargetPortal.transform.up.z == 1 || m_TargetPortal.transform.up.z == -1)
			//{
			//	ExtraForward.y = 0;
			//}
			
			float angle = m_TargetPortal.transform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y;
			collider.gameObject.transform.Rotate(0, 180+angle, 0);
			
			Quaternion q1  = Quaternion.FromToRotation(transform.up, m_TargetPortal.up);					
			Vector3 newPos = m_TargetPortal.position + q1 * (collider.transform.position - transform.position);
			
			collider.transform.position = newPos + ExtraForward;
			if(collider.CompareTag("Player"))
			{
				Camera.main.GetComponent<HouseCall>().SetHouseCall(m_TargetPortal.GetComponent<RasmusPortal2>().m_MyHouse);
				Camera.main.GetComponent<HouseCall>().SetTargetHouse(m_MyHouse);

				if(Camera.main.GetComponent<Raycasting>().HoldingInteractingWith() == true && Camera.main.GetComponent<Raycasting>().InteractingWith.GetComponent<PickUp>() != null)
				{
					Camera.main.GetComponent<Raycasting>().InteractingWith.transform.position = newPos + ExtraForward;
				}
			}
		}
	}
	
	//When we exit a portal we remove the object going through the portal from the hashset
	void OnTriggerExit(Collider collider)
	{
		m_Colliding.Remove(collider);
	}
	
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
