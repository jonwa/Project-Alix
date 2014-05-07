using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Handles the inputs from any of the GUI components
 * This should be attached to the UI root
 * 
 * Created By: Jon Wahlström 2014-04-25
 * Modified By: 
 */

public class InputManager : MonoBehaviour 
{
	private static bool Active{get;set;}
	private static GameObject m_Current = null;

	void Start()
	{
		Active = false;
	}

	public static bool RequestShowWindow(GameObject window)
	{
		if(m_Current != null && Active)
		{
			m_Current.GetComponent<WindowStatus>().Activate(false);
			m_Current = null;
			Active = false; 
			Camera.main.gameObject.GetComponent<Raycasting>().ShowHover = true;
			Camera.main.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
		}
		else
		{
			m_Current = window;
			Active = true;
			
			Camera.main.gameObject.GetComponent<Raycasting>().ShowHover = false;
			Camera.main.gameObject.GetComponent<FirstPersonCamera>().LockCamera();
		}

		return Active;
	}
}
