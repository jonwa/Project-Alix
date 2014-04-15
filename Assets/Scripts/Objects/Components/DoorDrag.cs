using UnityEngine;
using System.Collections;

/* Discription: Push Component
 * Used to push/pull doors, open Amnesia style
 * 
 * Created by: Sebastian Olsson 2014-04-08
 * Modified by:
 */

[RequireComponent(typeof(Rigidbody))]
public class DoorDrag : ObjectComponent
{
	#region PrivateMemberVariables
	private float		m_DeActivateCounter		= 5;
	private bool		m_UnlockedCamera		= true;
	private float		m_Speed					= 5.0f;
	private float 		m_MouseXPosition;
	private float 		m_MouseYPosition;
	private Transform   m_Camera;
	private GameObject	m_Player;
	private float 		m_Delta;
	#endregion
	
	#region PublicMemberVariables
	public string 		m_PlayerName		= "Player Controller Example";
	public string 		m_HorizontalInput;
	public string 		m_VerticalInput;
	public string 		m_Input;
	public GameObject	m_Target;
	#endregion
	
	void Start () 
	{
		m_Camera = Camera.main.transform;
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


	public override void Interact()
	{
<<<<<<< HEAD

		if(GetIsActive())
=======
		if(IsActive)
>>>>>>> 16d64c211aa03b5ce960dd4671ced0a5ecf540a0
		{
			Vector3 m_RotationAxis;
			m_MouseXPosition = Input.GetAxis(m_HorizontalInput);
			m_MouseYPosition = Input.GetAxis(m_VerticalInput);

			if(m_MouseXPosition != 0 || m_MouseYPosition != 0)
			{
				m_RotationAxis = PlayerForward();
				//Debug.Log(m_Target.transform.rotation.eulerAngles.y);
				m_Target.transform.Rotate(m_RotationAxis,m_Delta);
				//transform.Rotate(m_RotationAxis,m_Delta);
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
			Camera.main.SendMessage("Release");
			DeActivate();
		}
	}

	//Changes m_Delta according to the direction the player is facing
	private Vector3 PlayerForward()
	{
		Vector3 forward = new Vector3();

		if(m_Player.transform.forward.z >= 0.7 && m_Player.transform.forward.x >= -0.7 && m_Player.transform.forward.x <= 0.7)
		{
			forward = new Vector3(0, 1 , 0);
			m_Delta = (m_MouseYPosition + m_MouseXPosition) * m_Speed;
		}
		else if(m_Player.transform.forward.z <= -0.7 && m_Player.transform.forward.x >= -0.7 && m_Player.transform.forward.x <= 0.7)
		{
			forward = new Vector3(0, -1, 0);
			m_Delta = (m_MouseYPosition + -m_MouseXPosition) * m_Speed;
		}
		else if(m_Player.transform.forward.x <= -0.7 && m_Player.transform.forward.z >= -0.7 && m_Player.transform.forward.z <=0.7)
		{
			forward = new Vector3(0, 1, 0);
			m_Delta = (m_MouseYPosition + m_MouseXPosition) * m_Speed;
		}
		else if(m_Player.transform.forward.x >= -0.7 && m_Player.transform.forward.z >= -0.7 && m_Player.transform.forward.z <=0.7)
		{
			forward = new Vector3(0, -1, 0);
			m_Delta = (m_MouseYPosition + -m_MouseXPosition) * m_Speed;
		}
		return forward;
	}
}
