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
	public enum Action{	Show, Hide, Continue, LoadScene, ExitApp, ExitToMain };

	#region publicMemberVariables
	public string  m_SceneName 	= null;
	public UIPanel m_Window 	= null; 
	public Action  m_Action 	= Action.Show;
	#endregion

	private WindowHandler m_WindowHandler;

	void Start()
	{
		m_WindowHandler = WindowHandler.Instance;
	}
	
	void OnClick()
	{
		switch (m_Action)
		{
		case Action.Show:
			if(m_Window != null) 
			{
				m_WindowHandler.Show(m_Window);
			}
			else
				Debug.Log("Please assign window to open");
			break;
		
		case Action.Hide:
			m_WindowHandler.Hide();
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
