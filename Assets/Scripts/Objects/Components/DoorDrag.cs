using UnityEngine;
using System.Collections;

/* Discription: Push Component
 * Used to push/pull doors, open Amnesia style
 * 
 * Created by: Sebastian Olsson 2014-04-08
 * Modified by:
 * TODO: Add so that the player can push the door
 * TODO: Clean up script
 */

public class DoorDrag : ObjectComponent
{
	#region PrivateMemberVariables
	private float 		m_MouseXPosition;
	private float 		m_MouseYPosition;
	private float		m_DeActivateCounter		= 5;
	private float		m_Speed					= 5.0f;
	private bool		m_UnlockedCamera		= true;
	private Transform   m_Camera;
	private GameObject	m_Player;
	private float 		m_Delta;
	private Vector3		m_CurrentPlayerPosition;
	#endregion
	
	#region PublicMemberVariables
	public string 		m_HorizontalInput;
	public string 		m_VerticalInput;
	public string 		m_Input;
	public GameObject	m_Target;
	public bool			m_Closed			= true;
	public string 		m_PlayerName		= "Player Controller Example";
	#endregion
	
	void Start () 
	{
		m_Camera = Camera.main.transform;
		m_Player = GameObject.Find (m_PlayerName); 
		m_CurrentPlayerPosition = m_Player.transform.position;
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

	void OnCollisionStay()
	{
		float playerSpeed = m_Player.GetComponent<FirstPersonController>().m_MovementSpeed;
		Debug.Log ("Hejsan Collision");

		this.transform.parent.RotateAround (transform.parent.position, Vector3.up, -playerSpeed);
	}

	public override void Interact()
	{
		if(IsActive)
		{
			Vector3 m_RotationAxis;
			m_MouseXPosition = Input.GetAxis(m_HorizontalInput);
			m_MouseYPosition = Input.GetAxis(m_VerticalInput);

			//Upplåst
			if(m_Closed == true)
			{
				if(m_Target.transform.rotation.y != 0)
				{
					Debug.Log("Större än 0! = " + m_Target.transform.rotation.y);
					m_Closed = false;

				}
			}
			else
			{

			}

			if(m_MouseXPosition != 0 || m_MouseYPosition != 0)
			{
				m_RotationAxis = PlayerForward();
				m_Target.transform.Rotate(m_RotationAxis,m_Delta);

			}
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
			DeActivate();
		}
	}

	//Works Okej, but far far far from perfect
	private Vector3 PlayerForward()
	{
		Vector3 forward = new Vector3();

		if(m_Player.transform.forward.z >= 0.7 && m_Player.transform.forward.x >= -0.7 && m_Player.transform.forward.x <= 0.7)
		{
			forward = new Vector3(0, 1 , 0);
			m_Delta = (m_MouseYPosition + m_MouseXPosition) * m_Speed;
			Debug.Log ("Forward 1 = " + forward);
		}
		else if(m_Player.transform.forward.z <= -0.7 && m_Player.transform.forward.x >= -0.7 && m_Player.transform.forward.x <= 0.7)
		{
			forward = new Vector3(0, -1, 0);
			m_Delta = (m_MouseYPosition + -m_MouseXPosition) * m_Speed;
			Debug.Log ("Forward 2 = " + forward);
		}
		else if(m_Player.transform.forward.x <= -0.7 && m_Player.transform.forward.z >= -0.7 && m_Player.transform.forward.z <=0.7)
		{
			forward = new Vector3(0, 1, 0);
			m_Delta = (m_MouseYPosition + m_MouseXPosition) * m_Speed;
			Debug.Log ("Forward 3 = " + forward);
		}
		else if(m_Player.transform.forward.x >= -0.7 && m_Player.transform.forward.z >= -0.7 && m_Player.transform.forward.z <=0.7)
		{
			forward = new Vector3(0, -1, 0);
			m_Delta = (m_MouseYPosition + -m_MouseXPosition) * m_Speed;
			Debug.Log ("Forward 4 = " + forward);
		}
		return forward;
	}

}
