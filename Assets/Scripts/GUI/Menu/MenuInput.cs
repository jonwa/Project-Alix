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

	//contantly checks to see if input button is pressed
	//open or/and close the ingame menu.
	void Update () 
	{
		// ingame menu 
		if(m_ButtonDetection)
		{
			WindowStatus status = gameObject.GetComponent<WindowStatus>();
			if(Input.GetButtonDown(m_Input))
			{
				bool isActive = InputManager.RequestShowWindow(gameObject);
				status.Activate((isActive == true) ? true : false);
			}
		}
		// death menu
		else
		{
			/*if(Active)
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
			}*/
		}
	}
}
