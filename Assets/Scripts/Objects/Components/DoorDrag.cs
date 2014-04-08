using UnityEngine;
using System.Collections;

/* Discription: Push Component
 * Used to push/pull doors, open Amnesia style
 * 
 * Created by: Sebastian Olsson 2014-04-08
 * Modified by:
 * TODO: Check forward on doors
 */

public class DoorDrag : ObjectComponent
{
	#region PrivateMemberVariables
	private float 		m_MouseXPosition;
	private float 		m_MouseYPosition;
	private float		m_DeActivateCounter	= 5;
	private float		m_Speed				= 5.0f;
	private bool		m_Closed 			= true;
	private bool		m_UnlockedCamera	= true;
	private Transform   m_Camera;
	#endregion
	
	#region PublicMemberVariables
	public string 		m_HorizontalInput;
	public string 		m_VerticalInput;
	public string 		m_Input;
	public GameObject	m_Target;
	#endregion
	
	void Start () 
	{
		m_Camera  = Camera.main.transform;
	}
	
	void Update () 
	{		
		if(!GetIsActive())
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
		if(GetIsActive())
		{
			float m_Delta;
			m_MouseXPosition = Input.GetAxis(m_HorizontalInput);
			m_MouseYPosition = Input.GetAxis(m_VerticalInput);

			if(m_MouseXPosition > 0 || m_MouseYPosition > 0)
			{
				Debug.Log ("Större än");
				m_Delta = (m_MouseYPosition + m_MouseXPosition) * m_Speed;
				m_Target.transform.Rotate(0,-m_Delta, 0);
			}
			else if(m_MouseXPosition < 0 || m_MouseYPosition < 0)
			{
				Debug.Log ("Mindre än");
				m_Delta = (m_MouseYPosition + m_MouseXPosition) * m_Speed;
				m_Target.transform.Rotate(0,-m_Delta, 0);
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
}
