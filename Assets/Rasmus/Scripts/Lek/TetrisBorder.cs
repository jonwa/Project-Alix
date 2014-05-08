using UnityEngine;
using System.Collections;

public class TetrisBorder : MonoBehaviour 
{
	public GameObject m_BlockControl;
	public int 		  m_Edge;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	//public void OnTriggerEnter(Collider collider)
	//{
	//	if(collider.GetComponent<SingleBlock>() != null && collider.GetComponent<SingleBlock>().GetFalling() == true)
	//	{
	//		m_BlockControl.GetComponent<BlockControl>().HitEdge(m_Edge);
	//	}
	//}
	//public void OnTriggerExit(Collider collider)
	//{
	//	if(collider.GetComponent<SingleBlock>() != null && collider.GetComponent<SingleBlock>().GetFalling() == true)
	//	{
	//		m_BlockControl.GetComponent<BlockControl>().LeaveEdge();
	//	}
	//}
}
