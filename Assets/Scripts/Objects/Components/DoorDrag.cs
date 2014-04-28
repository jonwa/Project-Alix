using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	private float			m_DeActivateCounter		= 5;
	private bool			m_UnlockedCamera		= true;
	private bool			m_IsRotating			= false;
	private float			m_Speed					= 5.0f;
	private float 			m_MouseXPosition;
	private float 			m_MouseYPosition;
	private Transform   	m_Camera;
	private GameObject		m_Player;
	private float 			m_Delta;
	private Vector3 		m_RotationAxis;
	private List<Transform> 	m_Colliders = new List<Transform> ();
	#endregion
	
	#region PublicMemberVariables
	public string 		m_PlayerName		= "Player Controller Example";
	public string 		m_HorizontalInput;
	public string 		m_VerticalInput;
	public string 		m_Input;
	public float		m_ShoveSpeed;
	#endregion
	
	void Start () 
	{
		m_Camera = Camera.main.transform;
		m_Player = GameObject.Find (m_PlayerName);
		//int children = transform.childCount;
		//for(int i = 0; i < children; i++)
		//{
		//	Transform trans = transform.GetChild(i);
		//	Debug.Log(transform.GetChild(i));
		//	Debug.Log(trans);
		//	m_Colliders.Add(trans);
		//}
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
			//if(m_IsRotating)
			//{
			//
			//	if(m_Colliders[0].GetComponent<BoxCollider>().bounds.Intersects(m_Player.GetComponent<CapsuleCollider>().bounds) && m_Colliders[0].gameObject.activeInHierarchy)
			//	{
			//
			//		m_Colliders[1].gameObject.SetActive(false);
			//
			//
			//		Debug.Log("Hit 1");
			//		m_ShoveSpeed = m_Player.GetComponent<Rigidbody>().velocity.magnitude;
			//		if(m_ShoveSpeed > 0){
			//			m_ShoveSpeed *= -1;
			//		}
			//		m_Colliders[1].GetComponent<BoxCollider>().enabled = false;
			//	}
			//	else if(m_Colliders[1].GetComponent<BoxCollider>().bounds.Intersects(m_Player.GetComponent<CapsuleCollider>().bounds) && m_Colliders[1].gameObject.activeInHierarchy)
			//	{
			//		m_Colliders[0].gameObject.SetActive(false);
			//
			//
			//		Debug.Log("Hit 2");
			//		m_ShoveSpeed = m_Player.GetComponent<Rigidbody>().velocity.magnitude;
			//		m_ShoveSpeed *= -1;
			//		if(m_ShoveSpeed < 0){
			//			m_ShoveSpeed *= -1;
			//		}
			//		m_Colliders[0].GetComponent<BoxCollider>().enabled = false;
			//	}
			//	transform.Rotate(m_RotationAxis, m_ShoveSpeed, Space.Self);
			//}
		}
		else
		{
			m_DeActivateCounter++;
			if(m_DeActivateCounter > 10)
			{
				DeActivate();
			}
		}
		//if(m_Colliders[0].GetComponent<BoxCollider>().bounds.Intersects(m_Player.GetComponent<CapsuleCollider>().bounds) || m_Colliders[1].GetComponent<BoxCollider>().bounds.Intersects(m_Player.GetComponent<CapsuleCollider>().bounds))
		//{
		//	m_IsRotating = true;
		//}
		//else
		//{
		//	m_IsRotating = false;
		//	m_Colliders[0].gameObject.SetActive(true);
		//	m_Colliders[1].gameObject.SetActive(true);
		//}
	}


	public override void Interact()
	{
		if(IsActive)
		{
			m_RotationAxis = PlayerForward();
			m_MouseXPosition = Input.GetAxis(m_HorizontalInput);
			m_MouseYPosition = Input.GetAxis(m_VerticalInput);

			if(m_MouseXPosition != 0 || m_MouseYPosition != 0)
			{
				transform.Rotate(m_RotationAxis,m_Delta,Space.Self);

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

	public void ReleaseDoor()
	{
		Camera.main.SendMessage("Release");
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}

}
