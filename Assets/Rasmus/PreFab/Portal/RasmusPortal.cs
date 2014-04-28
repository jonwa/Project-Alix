using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/* Description: Makes the object able to pass through portals
 * 
 * Created by: Rasmus 24/4, made from Jimmy's code
 * Modified by:
 */

public class RasmusPortal : ObjectComponent 
{
	#region PublicMemberVariables
	public GameObject m_TargetPort;
	public int		  m_TargetHouse;
	#endregion
	
	#region PrivateMemberVariables
	private Transform 		  m_TargetPortal;
	private HashSet<Collider> m_Colliding = new HashSet<Collider>();
	private RenderTexture	  m_Texture;
	#endregion

	void Start()
	{
		m_Texture = transform.parent.GetComponent<PortalTexture>().GetTextureForPortal();
		//m_Texture = new RenderTexture(512,512,24);
		MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
		mr.material = new Material(mr.material);
		mr.material.mainTexture = m_Texture;
		//m_Material = mr.material;
		//Debug.Log("Startar");
	}

	void Update()
	{
		m_Texture = transform.parent.GetComponent<PortalTexture>().GetTextureForPortal();
		renderer.material.mainTexture = m_Texture;
		//Camera targetCam = transform.parent.GetComponent<Camera>().camera;
		//targetCam.targetTexture  = m_Texture;
	}

	//When we collide with the portal we create a duplicate and 
	void OnTriggerEnter(Collider collider)
	{
		m_TargetPortal 		 = m_TargetPort.transform;
		Vector3 ExtraForward = m_TargetPortal.transform.up;
		
		float angle = m_TargetPortal.transform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y;
		collider.gameObject.transform.Rotate(0, 180+angle, 0);
		
		Quaternion q1  = Quaternion.FromToRotation(transform.up, m_TargetPortal.up);					
		Vector3 newPos = m_TargetPortal.position + q1 * (collider.transform.position - transform.position);
		
		collider.transform.position = newPos + ExtraForward;
		if(collider.CompareTag("Player"))
		{
			transform.parent.GetComponent<PortalTexture>().ChangeHouse(m_TargetHouse);
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
