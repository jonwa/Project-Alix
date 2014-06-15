using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Discription: Push Component
 * Used to push/pull doors, open Amnesia style
 * 
 * Created by: Sebastian Olsson 2014-04-08
 * Modified by: Jimmy 2014-04-30
 */

public class DoorDrag : ObjectComponent
{
	#region PrivateMemberVariables
	private float				m_DeActivateCounter		= 5;
	private bool				m_UnlockedCamera		= true;
	private float 				m_MouseYPosition;
	private Transform   		m_Camera;
	private GameObject			m_Player;
	private float 				m_Delta;
	private Vector3 			m_RotationAxis;
	private Vector3 			m_ObjectGeneralForward;
	#endregion
	
	#region PublicMemberVariables
	public float		m_Speed				= 60.0f;
	public string 		m_VerticalInput;
	public string 		m_Input;
	#endregion
	
	void Start () 
	{
		m_Camera = Camera.main.transform;
		m_Player = Camera.main.transform.parent.gameObject;

	}
	
	void Update () 
	{	
		if(!IsActive)
		{

			m_ObjectGeneralForward = ClosestDirection(transform.forward);
			//m_ObjectGeneralRight	 = ClosestDirection(transform.right);

			if(m_UnlockedCamera == false)
			{
				m_Camera.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
				m_UnlockedCamera = true;
			}

			m_DeActivateCounter++;
			if(m_DeActivateCounter > 10)
			{
				DeActivate();
			}
		}
		else
		{
			if(Camera.main.GetComponent<Raycasting>().m_Distance < Vector3.Distance(Camera.main.transform.position, transform.position))
			{
				Camera.main.GetComponent<Raycasting>().Release();
				m_Camera.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
			}
		}
		
	}


	public override void Interact()
	{
		if(IsActive)
		{
			m_RotationAxis = PlayerForward();
			m_MouseYPosition = Input.GetAxis(m_VerticalInput);

			if(m_MouseYPosition != 0)
			{
				if(gameObject.GetComponent<RotationLimit>())
				{
					m_Delta = gameObject.GetComponent<RotationLimit>().CheckRotation(m_Delta, "y");
				}

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
			Camera.main.GetComponent<Raycasting>().Release();
			DeActivate();
		}
	}

	//Calculates the general direction of a vector v
	Vector3 ClosestDirection(Vector3 v) 
	{
		//Vector3[] compass = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
		Vector3[] compass = { new Vector3(-1,0,1), Vector3.forward, new Vector3(1,0,1), new Vector3(-1,0,-1), Vector3.back, new Vector3(1,0,-1), Vector3.left, Vector3.right };
		float maxDot = -Mathf.Infinity;
		Vector3 ret = Vector3.zero;
		
		foreach(Vector3 dir in compass) 
		{
			float t = Vector3.Dot(v, dir);
			if (t > maxDot) 
			{
				ret = dir;
				maxDot = t;
			}
		}
		return ret;
	}

	//Changes m_Delta according to the direction the player is facing
	private Vector3 PlayerForward()
	{
		Vector3 forward = ClosestDirection(m_Player.transform.forward);

		if(forward == m_ObjectGeneralForward)
		{
			//Debug.Log("forward");
			m_Delta = ((-m_MouseYPosition)*m_Speed)*Time.deltaTime;
		}
		else if(forward == -m_ObjectGeneralForward)
		{
			//Debug.Log("backwards");
			m_Delta = ((m_MouseYPosition)*m_Speed)*Time.deltaTime;
		}

		//Vector3 ret = new Vector3();
		//if(forward == Vector3.forward)
		//{
		//	ret = new Vector3(0, -1 , 0);
		//	m_Delta = ((m_MouseYPosition ) * m_Speed)*Time.deltaTime;
		//}
		//else if(forward == Vector3.back)
		//{
		//	ret = new Vector3(0, 1 , 0);
		//	m_Delta = ((m_MouseYPosition ) * m_Speed)*Time.deltaTime;
		//}
		//else if(forward == Vector3.left)
		//{
		//	ret = new Vector3(0, 1 , 0);
		//	m_Delta = ((-m_MouseYPosition ) * m_Speed)*Time.deltaTime;
		//}
		//else if(forward == Vector3.right)
		//{
		//	ret = new Vector3(0, -1 , 0);
		//	m_Delta = ((m_MouseYPosition ) * m_Speed)*Time.deltaTime;
		//}



		return new Vector3(0,1,0);
	}

	public void ReleaseDoor()
	{
		Camera.main.SendMessage("Release");
	}

	public virtual string Name
	{
		get
		{
			return "DoorDrag";
		}
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}

}
