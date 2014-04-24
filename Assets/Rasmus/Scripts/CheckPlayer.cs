using UnityEngine;
using System.Collections;

public class CheckPlayer : MonoBehaviour 
{
	#region PublicMemberVariables
	public GameObject m_Target1;
	public GameObject m_Target2;
	public float  	  m_DoorHeight = 5.28f;
	public float  	  m_DoorWidth  = 2.64f;
	public float  	  m_FarPlane   = 100f;
	public bool    	  m_House      = false;
	public float 	  m_Distance   = 55.5f;
	#endregion

	#region PrivateMemberVariables
	private GameObject m_TargetToFollow;
	private GameObject m_Player;
	private float MaxView = 100;
	#endregion

	// Use this for initialization
	void Start () 
	{
		m_TargetToFollow = m_Target1;
		m_Player = Camera.main.gameObject;
		GetComponent<Camera>().aspect = m_DoorWidth / m_DoorHeight;
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_Player = Camera.main.gameObject;
		float dist = Vector3.Distance(transform.position, m_TargetToFollow.transform.position);
		//Debug.Log(dist);
		//2.64   F = (1.32/dist) * 100
		//Calculate= Dörrbredd, Delat på avståndet, gånger farplane på kameran.
		float calculate = ((m_DoorWidth/dist) * m_FarPlane);
		if(calculate < MaxView){
			GetComponent<Camera>().fieldOfView = calculate;
		}
		else
		{
			GetComponent<Camera>().fieldOfView = MaxView;
		}

		if(m_House == false)
		{
			transform.position = m_Player.transform.position + new Vector3(m_Distance, 0, 0);
			m_TargetToFollow = m_Target1;
		}
		else
		{
			transform.position = m_Player.transform.position + new Vector3(-m_Distance, 0, 0);
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
		transform.LookAt(m_TargetToFollow.transform.position);
	}

	public void ChangeHouse()
	{
		m_House = !m_House;
	}
}
