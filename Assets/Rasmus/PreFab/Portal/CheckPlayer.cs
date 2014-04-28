using UnityEngine;
using System.Collections;

public class CheckPlayer : MonoBehaviour 
{
	#region PublicMemberVariables
	public float  	  m_DoorHeight = 5.28f;
	public float  	  m_DoorWidth  = 2.64f;
	public float  	  m_FarPlane   = 100f;
	private bool      m_MyHouse    = true;
	public float 	  m_DistanceX  = 55.5f;
	public float 	  m_DistanceZ  = 0;
	public GameObject m_Target1    = null;
	public GameObject m_Target2    = null;
	public float      m_Offset     = 1.23f;
	#endregion

	#region PrivateMemberVariables
	private GameObject m_TargetToFollow = null;
	private GameObject m_Player;
	private int 	   m_House 			= 0;
	private float 	   m_MaxView 		= 100;
	#endregion

	// Use this for initialization
	void Start () 
	{
		m_TargetToFollow = m_Target1;
		m_Player = Camera.main.gameObject;
		GetComponent<Camera>().aspect = m_DoorWidth / m_DoorHeight;
		m_DistanceX = m_Target1.transform.position.x - m_Target2.transform.position.x;
		m_DistanceZ = m_Target1.transform.position.z - m_Target2.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//m_Player = Camera.main.gameObject;
		float dist = Vector3.Distance(transform.position, m_TargetToFollow.transform.position);
		//Debug.Log(dist);
		//2.64   F = (1.32/dist) * 100
		//Calculate= Dörrbredd, Delat på avståndet, gånger farplane på kameran.
		float calculate = ((m_DoorWidth/dist) * m_FarPlane);
		if(calculate < m_MaxView){
			GetComponent<Camera>().fieldOfView = calculate;
		}
		else
		{
			GetComponent<Camera>().fieldOfView = m_MaxView;
		}

		if(m_MyHouse == false)
		{
			transform.position = m_Player.transform.position + new Vector3(m_DistanceX, 0, m_DistanceZ);
			m_TargetToFollow = m_Target1;
		}
		else
		{
			transform.position = m_Player.transform.position + new Vector3(-m_DistanceX, 0, -m_DistanceZ);
			m_TargetToFollow = m_Target2;
		}
		//change -55.5f to house * distancebeetweenhouse
		//if(m_House == 0)
		//{
		//	if(m_Player.transform.position.x < 28)
		//	{
		//		transform.position = m_Player.transform.position + new Vector3(55.5f, 0, 0);
		//	}
		//	else
		//	{
		//		transform.position = m_Player.transform.position;
		//	}
		//}
		//else if(m_House == 1)
		//{
		//	if(m_Player.transform.position.x > 28)
		//	{
		//		transform.position = m_Player.transform.position + new Vector3(-55.5f, 0, 0);
		//	}
		//	else
		//	{
		//		transform.position = m_Player.transform.position;
		//	}
		//}
		//if(m_Player.transform.position.x < 28 && m_House == 0)
		//{
		//	transform.position = m_Player.transform.position + new Vector3(55.5f, 0, 0);// + transform.forward*-1;
		//}
		//else if(m_Player.transform.position.x > 28 && m_House == 1)
		//{
		//	transform.position = m_Player.transform.position + new Vector3(-55.5f , 0, 0);// + transform.forward*-1;
		//}
		//else
		//{
		//	transform.position = m_Player.transform.position;
		//}
		UpdateHouse();
		transform.LookAt(m_TargetToFollow.transform.position);
	}

	public void ChangeHouse(int house)
	{
		m_Player.GetComponent<HouseCall>().SetHouseCall(house);
		UpdateHouse();
	}

	public void UpdateHouse()
	{
		m_House = m_Player.GetComponent<HouseCall>().GetHouseCall();
		if(m_House != m_Target1.GetComponent<RasmusPortal>().m_TargetHouse)
		{
			m_MyHouse = true;
		}
		else
		{
			m_MyHouse = false;
		}
	}
}
