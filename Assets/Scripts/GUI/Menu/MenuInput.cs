﻿using UnityEngine;
using System.Collections;

/* Used inorder to open and close the ingame menu
 * with the escape button. Every other times the menu
 * will either be visible or non-visibl.
 * 
 * Created By: Jon Wahlström 2014-04-03
 * Modified By: 
 */

public class MenuInput : MonoBehaviour 
{
	#region PublicMemberVariables
	public GameObject m_Window          = null; 
	public bool 	  m_ButtonDetection = true;
	public string 	  m_Input			= null; 
	#endregion

	#region PrivateMemberVariables
	private bool m_Active = false;
	#endregion


	//get/set the value of m_Active
	public bool Active
	{
		get { return m_Active;  }
		set { m_Active = value; }
	}

	//contantly checks to see if esc button is pressed
	//open or/and close the ingame menu.
	void Update () 
	{
		if(m_ButtonDetection)
		{
			if (Input.GetButtonDown(m_Input))
			{
				m_Active = InputManager.Active;

				if(m_Active)
				{
					m_Window.SetActive(false);
					WindowHandler.Default(); 
				}
				else
				{
					m_Window.SetActive(true);
				}

				InputManager.Reset();
			}
		}
		else
		{
			if(m_Active)
			{
				m_Window.SetActive(true);
				Camera.main.gameObject.GetComponent<Raycasting>().ShowHover = false;
				Camera.main.gameObject.GetComponent<FirstPersonCamera>().LockCamera();
			}
			else
			{
				m_Window.SetActive(false);
				Camera.main.gameObject.GetComponent<Raycasting>().ShowHover = true;
				Camera.main.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
			}
		}
	}
}
