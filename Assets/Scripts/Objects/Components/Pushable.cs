using UnityEngine;
using System.Collections;

/* Discription: Push Component
 * Used to push/pull drawers, open them Amnesia style
 * 
 * Created by: Sebastian Olsson 2014-04-08
 * Modified by:
 */

public class Pushable : ObjectComponent 
{
	#region PrivateMemberVariables
	private float 		m_MouseXPosition;
	private float 		m_MouseYPosition;
	private Vector3 	m_Delta				= Vector3.zero;
	private float		m_DeActivateCounter	= 5;
	private float		m_MoveSpeed			= 0.1f;
	private bool		m_UnlockedCamera	= true;
	private Transform   m_Camera;
	private GameObject 	m_Player;
	#endregion
	
	#region PublicMemberVariables
	public string 	m_HorizontalInput;
	public string 	m_VerticalInput;
	public string 	m_Input;
	public string 	m_PlayerName			= "Player Controller Example";
	#endregion
	
	
	void Start () 
	{
		m_Camera  = Camera.main.transform;
		m_Player = GameObject.Find (m_PlayerName); 
	}
	
	void Update () 
	{
		if(!IsActive)
		{
			if(m_UnlockedCamera == false)
			{
				m_Camera.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
				m_UnlockedCamera = true;
			}
		}
		else
		{
			m_DeActivateCounter++;
			if(m_DeActivateCounter > 10)
				DeActivate();
		}
	}

	//By checking the players forward we change the axis of the mouse position
	public override void Interact()
	{
		if (IsActive) 
		{
			m_MouseXPosition = Input.GetAxis(m_HorizontalInput);
			m_MouseYPosition = Input.GetAxis(m_VerticalInput);

			PlayerForward();
			transform.position += m_Delta * m_MoveSpeed;
		}
		if(Input.GetButton(m_Input))
		{
			m_Camera.gameObject.GetComponent<FirstPersonCamera>().LockCamera();
			m_UnlockedCamera = false;
			Activate();
			m_DeActivateCounter = 0;
		}
		else
		{
			Camera.main.SendMessage("Release");
			DeActivate();
		}
	}

	private void PlayerForward()
	{
		if(m_Player.transform.forward.z >= 0.7 && m_Player.transform.forward.x >= -0.7 && m_Player.transform.forward.x <= 0.7)
		{
			m_Delta = new Vector3(m_MouseXPosition, 0 , m_MouseYPosition);
		}
		else if(m_Player.transform.forward.z <= -0.7 && m_Player.transform.forward.x >= -0.7 && m_Player.transform.forward.x <= 0.7)
		{
			m_Delta = new Vector3(-m_MouseXPosition, 0, -m_MouseYPosition);
		}
		else if(m_Player.transform.forward.x <= -0.7 && m_Player.transform.forward.z >= -0.7 && m_Player.transform.forward.z <=0.7)
		{
			m_Delta = new Vector3(-m_MouseYPosition, 0, m_MouseXPosition);
		}
		else if(m_Player.transform.forward.x >= -0.7 && m_Player.transform.forward.z >= -0.7 && m_Player.transform.forward.z <=0.7)
		{
			m_Delta = new Vector3(m_MouseYPosition, 0, -m_MouseXPosition);
		}
	}
}