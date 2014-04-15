using UnityEngine;
using System.Collections;

/* Should be places on a menu button
 * A WindowButton has differend modes
 * 	show - transition from one part of the menu to another
 *  hide - returns to the previous window shown
 *  loadScene - loads the scene assigned 
 *  exit - Shuts down the application
 * 
 * WindowButtons calls, when clicked, a function from WindowHandler.cs 
 * depending on which mode is active
 * 
 * Created By: Jon Wahlström 2014-04-02
 * Modified By: 
 */

public class WindowButton : MonoBehaviour 
{
	#region PublicMemberVariables
	public enum Action{	None, Show, Hide, Continue, LoadScene, ExitApp, ExitToMain };

	public string 	  m_SceneName 	 = null;
	public GameObject m_Window 	     = null; 
	public Action  	  m_Action 		 = Action.None;
	#endregion

	//Called when a menu button is pressed
	//Depending on the button settings
	//either of the cases will be chosed.
	void OnClick()
	{
		switch (m_Action)
		{
		case Action.None:

			break;
		case Action.Show:
			if(m_Window != null) 
			{
				WindowHandler.Show(m_Window);
			}
			else
				Debug.Log("Please assign window to open");
			break;
		
		case Action.Hide:
			WindowHandler.Hide();
			break;
		
		case Action.Continue:
			m_Window.SetActive(false);
			WindowHandler.Default();
			m_Window.transform.parent.GetComponent<MenuInput>().Active = false;

			//TODO: Add respawn ? 

			break; 

		case Action.LoadScene:
			if(m_SceneName != null) 
			{
				Application.LoadLevel(m_SceneName);
			}
			else
				Debug.Log("Please assign scene to load");
			break; 
		
		case Action.ExitToMain:
			if(m_SceneName != null)
			{
				Application.LoadLevel(m_SceneName);
			}
			else
				Debug.Log("Please assign scene to load, in this case type the main menu scene name");
			break;

		case Action.ExitApp:
			Application.Quit();
			break; 
		}
	}


}
