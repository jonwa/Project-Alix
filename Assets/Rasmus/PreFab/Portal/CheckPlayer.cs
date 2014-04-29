using UnityEngine;
using System.Collections;

public class CheckPlayer : MonoBehaviour 
{
	#region PublicMemberVariables

	private float  	  m_FarPlane;
	private bool      m_MyHouse    = true;
	public GameObject m_Target1    = null;
	public GameObject m_Target2    = null;
	//public float      m_Offset     = 1.23f;
	#endregion

	#region PrivateMemberVariables
	private float  	   m_DoorHeight;
	private float  	   m_DoorWidth;
	private float 	   m_DistanceX;
	private float 	   m_DistanceZ;
	private GameObject m_TargetToFollow = null;
	private GameObject m_Player;
	private int 	   m_House 			= 0;
	private float 	   m_MaxView 		= 100;
	#endregion

	// Use this for initialization
	void Start () 
	{
		m_TargetToFollow = m_Target1;
		m_Player         = Camera.main.gameObject;
		m_DoorHeight     = m_Target1.transform.collider.bounds.size.y;
		m_DoorWidth      = m_Target1.transform.collider.bounds.size.x;
		m_DistanceX 	 = m_Target1.transform.position.x - m_Target2.transform.position.x;
		m_DistanceZ 	 = m_Target1.transform.position.z - m_Target2.transform.position.z;
		m_FarPlane       = GetComponent<Camera>().farClipPlane;

		GetComponent<Camera>().aspect = m_DoorWidth/m_DoorHeight;
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
