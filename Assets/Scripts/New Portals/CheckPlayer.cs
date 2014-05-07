using UnityEngine;
using System.Collections;

/*Decides where the camera should be placed so it will lock at the right Targetportal

Made by: Rasmus 29/04
 */

public class CheckPlayer : MonoBehaviour 
{
	#region PublicMemberVariables
	public GameObject m_Target1    = null;
	public GameObject m_Target2    = null;
	#endregion

	#region PrivateMemberVariables
	private int 	   m_TargetInt;
	private float  	   m_FarPlane;
	private float  	   m_DoorHeight;
	private float  	   m_DoorWidth;
	private float      m_DoorDepth;
	private GameObject m_TargetToFollow;
	private GameObject m_Player;
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
		if(m_Player != Camera.main.gameObject)
		{
			m_Player = Camera.main.gameObject;
		}

		CalculateFieldOfView();
		MoveCamera();
		transform.LookAt(m_TargetToFollow.transform.position);
	}

	private void CalculateFieldOfView()
	{
		float dist = Vector3.Distance(transform.position, m_TargetToFollow.transform.position);
		//Calculate= Dörrbredd, Delat på avståndet, gånger farplane på kameran.
		float calculate;
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
		if(m_TargetInt == m_Target1.GetComponent<RasmusPortal>().m_MyHouse)
		{
			m_TargetToFollow = m_Target1;
		}
		else if(m_TargetInt == m_Target2.GetComponent<RasmusPortal>().m_MyHouse)
		{
			m_TargetToFollow = m_Target2;
		}
		int playerInt = m_Player.GetComponent<HouseCall>().GetHouseCall();
		Transform playerTransform = m_Target1.transform;
		if(playerInt == m_Target1.GetComponent<RasmusPortal>().m_MyHouse)
		{
			playerTransform = m_Target1.transform;
		}
		else if(playerInt == m_Target2.GetComponent<RasmusPortal>().m_MyHouse)
		{
			playerTransform = m_Target2.transform;
		}
		Vector3 differenceVector = m_TargetToFollow.transform.position - playerTransform.position;
		
		transform.position = m_Player.transform.position + new Vector3(differenceVector.x, differenceVector.y, differenceVector.z);
	}
}
