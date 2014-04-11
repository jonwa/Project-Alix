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
	public GameObject m_Window = null; 
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
		if (Input.GetKeyDown(KeyCode.Escape) && !m_Active)
		{
			m_Active = true; 
			m_Window.SetActive(true);

			//freeze the camera position
			Camera.main.gameObject.GetComponent<FirstPersonCamera>().LockCamera();
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && m_Active)
		{
			m_Active = false;
			m_Window.SetActive(false);
			 
			WindowHandler.Default();

			//unfreeze the camera position
			Camera.main.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
		}
	}
}
