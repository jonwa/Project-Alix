using UnityEngine;
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
	
	public bool Active{get;set;}

	void Start()
	{
		Active = true;
	}

	//contantly checks to see if input button is pressed
	//open or/and close the ingame menu.
	void Update () 
	{
		if(m_ButtonDetection)
		{
			if (Input.GetButtonDown(m_Input))
			{
				if(Active && InputManager.Active)
				{
					InputManager.Active = false;
					Active = false;
					m_Window.SetActive(true);
				}
				else if(Active && !InputManager.Active)
				{
					return;
				}
				else
				{
					InputManager.Active = true;
					Active = true;
					m_Window.SetActive(false);
					WindowHandler.Default(); 
					PlatformWindowHandler.Default();
				}

				InputManager.Reset();
			}
		}
		else
		{
			if(Active)
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
