using UnityEngine;
using System.Collections;

public class CheckPlayer2 : MonoBehaviour 
{
	#region PublicMemberVariables
	public GameObject m_Target1    = null;
	public GameObject m_Target2    = null;
	public GameObject m_Target3    = null;
	#endregion
	
	#region PrivateMemberVariables
	private int 	   m_TargetInt;
	private float  	   m_FarPlane;
	private float  	   m_DoorHeight;
	private float  	   m_DoorWidth;
	private float      m_DoorDepth;
	private GameObject m_TargetToFollow;
	private GameObject m_Player;
	private int 	   m_House;
	private float 	   m_MaxView 		= 100;
	#endregion
	
	// Use this for initialization
	void Start () 
	{
		m_TargetToFollow = m_Target1;
		m_Player         = Camera.main.gameObject;
		m_DoorHeight     = m_Target1.transform.collider.bounds.size.y;
		m_DoorWidth      = m_Target1.transform.collider.bounds.size.x;
		m_DoorDepth      = m_Target1.transform.collider.bounds.size.z;
		m_FarPlane       = GetComponent<Camera>().farClipPlane;
		m_TargetInt      = m_Player.GetComponent<HouseCall>().GetTargetHouse();
		
		//Debug.Log(m_DoorHeight + " " + m_DoorWidth + " " + m_DoorDepth);
		if(m_DoorWidth > 0.1)
		{
			GetComponent<Camera>().aspect = m_DoorWidth/m_DoorHeight;
		}
		else
		{
			GetComponent<Camera>().aspect = m_DoorDepth/m_DoorHeight;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		CalculateFieldOfView();
		MoveCamera();

		UpdateHouse();
		transform.LookAt(m_TargetToFollow.transform.position);
		//if(Input.GetKeyDown("t"))
		//{
		//	//NextTargetHouse();
		//}
	}

	private void CalculateFieldOfView()
	{
		float dist = Vector3.Distance(transform.position, m_TargetToFollow.transform.position);
		float calculate;
		//Calculate= Dörrbredd, Delat på avståndet, gånger farplane på kameran.
		if(m_DoorWidth > 0.1)
		{
			calculate = ((m_DoorWidth/dist) * m_FarPlane);
		}
		else
		{
			calculate = ((m_DoorDepth/dist) * m_FarPlane);
		}

		if(calculate < m_MaxView){
			GetComponent<Camera>().fieldOfView = calculate;
		}
		else
		{
			GetComponent<Camera>().fieldOfView = m_MaxView;
		}
	}

	private void MoveCamera()
	{
		m_TargetInt = m_Player.GetComponent<HouseCall>().GetTargetHouse();

		if(m_TargetInt == m_Target1.GetComponent<RasmusPortal2>().m_MyHouse)
		{
			m_TargetToFollow = m_Target1;
		}
		else if(m_TargetInt == m_Target2.GetComponent<RasmusPortal2>().m_MyHouse)
		{
			m_TargetToFollow = m_Target2;
		}
		else if(m_TargetInt == m_Target3.GetComponent<RasmusPortal2>().m_MyHouse)
		{
			m_TargetToFollow = m_Target3;
		}
		int playerInt = m_Player.GetComponent<HouseCall>().GetHouseCall();
		Transform playerTransform = m_Target1.transform;
		if(playerInt == m_Target1.GetComponent<RasmusPortal2>().m_MyHouse)
		{
			playerTransform = m_Target1.transform;
		}
		else if(playerInt == m_Target2.GetComponent<RasmusPortal2>().m_MyHouse)
		{
			playerTransform = m_Target2.transform;
		}
		else if(playerInt == m_Target3.GetComponent<RasmusPortal2>().m_MyHouse)
		{
			playerTransform = m_Target3.transform;
		}
		Vector3 differenceVector = m_TargetToFollow.transform.position - playerTransform.position;

		transform.position = m_Player.transform.position + new Vector3(differenceVector.x, 0, differenceVector.z);
	}
	
	public void UpdateHouse()
	{
		m_House = m_Player.GetComponent<HouseCall>().GetHouseCall();
		//if(m_House != m_Target1.GetComponent<RasmusPortal2>().m_TargetHouse)
		//{
		//	m_MyHouse = true;
		//}
		//else
		//{
		//	m_MyHouse = false;
		//}
	}
}
