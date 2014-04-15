using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortalPairHandler : MonoBehaviour {

	public int m_PortalPairId	 		 = 0;
	public List<int> m_TargetPortalsId		 = new List<int>();		

	private Transform[] m_TargetPortals;// = new List<Transform>();
	// Use this for initialization
	void Start () 
	{
		Debug.Log("SIZE" + m_TargetPortalsId.Count.ToString());
		m_TargetPortals = new Transform[m_TargetPortalsId.Count];
		for(int i=0; i < PortalManager.NumberOfStages-1; i++)
		{
			Debug.Log(i);
			m_TargetPortals[i] = GetTargetPortalPair(m_TargetPortalsId[i]);
		}
	}


	//Gets the portalpair with specefic id;
	Transform  GetTargetPortalPair(int id)
	{
		PortalPairHandler[] portals =  Object.FindObjectsOfType<PortalPairHandler>();
		
		foreach(PortalPairHandler p in portals)
		{
			if(p.m_PortalPairId == id)
			{
				return p.transform;
			}
		}
		return null;
	}

	public Transform GetRemotePortal(string portalName)
	{
		Transform portalPair;
		Debug.Log(PortalManager.GetCurrentTimeStage());
		if(m_TargetPortals[PortalManager.GetCurrentTimeStage()] == null)
		{
			portalPair = GetTargetPortalPair(m_TargetPortalsId[PortalManager.GetCurrentTimeStage()]);
		}
		else
		{
			portalPair = m_TargetPortals[PortalManager.GetCurrentTimeStage()];
		}

		if(portalName == "Portal1")
		{
			return portalPair.GetComponent<PortalPairHandler>().GetSecond();
		}
		else if(portalName == "Portal2")
		{
			return portalPair.GetComponent<PortalPairHandler>().GetFirst();
		}
		return null;
	}

	public Transform GetFirst()
	{
		return transform.FindChild("Portal1");
	}

	public Transform GetSecond()
	{
		return transform.FindChild("Portal2");
	}

//	public Transform GetMyTarget()
//	{
//		
//		return;
//	}


	// Update is called once per frame
	void Update () 
	{
	
	}
}
