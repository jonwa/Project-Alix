using UnityEngine;
using System.Collections;

/* Discription: Push Component
 * Used to push/pull drawers, open them Amnesia style
 * 
 * Created by: Sebastian Olsson 2014-04-08
 * Modified by: Robert Siik 2014-04-17 : Added compability with MovementLimit
 */

public class Pushable : ObjectComponent 
{
	#region PrivateMemberVariables
	private float 		m_MouseXPosition;
	private float 		m_MouseYPosition;
	private Vector3 	m_PlayerDirection	= Vector3.zero;
	private float		m_DeActivateCounter	= 5;

	private bool		m_UnlockedCamera	= true;
	private Transform   m_Camera;
	private GameObject 	m_Player;
	#endregion
	
	#region PublicMemberVariables
	public string 	m_HorizontalInput;
	public string 	m_VerticalInput;
	public string 	m_Input;
	public float	m_MoveSpeed			= 1f;
	#endregion
	
	public Vector3 Delta
	{
		get {return m_PlayerDirection;}
	}

	void Start () 
	{
		m_Camera  = Camera.main.transform;
		m_Player  = m_Camera.transform.parent.gameObject; 
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
			PlayerForward();
			Vector3 targetPosition = transform.localPosition + (m_PlayerDirection * (m_MoveSpeed * Time.deltaTime));
			if(gameObject.GetComponent<MovementLimit>())
			{
				targetPosition = gameObject.GetComponent<MovementLimit>().CheckPosition(targetPosition);
			}
			transform.localPosition = targetPosition;
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

	//Calculates the general direction of a vector v
	Vector3 ClosestDirection(Vector3 v) 
	{
		Vector3[] compass = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
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

	private void PlayerForward()
	{
		Vector3 playerGeneralForward = ClosestDirection(m_Player.transform.forward);
		Vector3 objectGeneralForward = ClosestDirection(transform.forward);
		Vector3 objectGeneralRight	 = ClosestDirection(transform.right);
		m_MouseXPosition = Input.GetAxis(m_HorizontalInput);
		m_MouseYPosition = Input.GetAxis(m_VerticalInput);

		if(playerGeneralForward == objectGeneralForward)
		{
			m_PlayerDirection = new Vector3(m_MouseXPosition, 0, m_MouseYPosition);
		}
		else if(playerGeneralForward == -objectGeneralForward)
		{
			m_PlayerDirection = new Vector3(m_MouseXPosition, 0, -m_MouseYPosition);
		}
		else if(playerGeneralForward == objectGeneralRight)
		{
			m_PlayerDirection = new Vector3(m_MouseYPosition, 0, -m_MouseXPosition);
		}
		else if(playerGeneralForward == -objectGeneralRight)
		{
			m_PlayerDirection = new Vector3(m_MouseYPosition, 0, m_MouseXPosition);
		}
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}

}