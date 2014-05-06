using UnityEngine;
using System.Collections;

/*
 * Created By: Jon Wahlström 2014-04-22
 * Modified By:
 */

public class WindowButton : MonoBehaviour {

	public enum Action { NewGame, Show, Continue, Exit };
	
	public GameObject m_Window;
	public string	  m_LevelToLoad;
	public int		  m_Id;
	public Action 	  m_Action = Action.Show;
	
	void OnClick()
	{
		switch(m_Action)
		{
		case Action.NewGame:
			WindowHandler.Default();
			if(!string.IsNullOrEmpty(m_LevelToLoad))
			{
				Application.LoadLevel(m_LevelToLoad);
			}
			break;
		case Action.Show:
			if(m_Window != null)
			{
				WindowHandler.Show(m_Id, m_Window);
			}
		break;	
		
		case Action.Continue:
			InputManager.Active = true;
			m_Window.transform.parent.GetComponent<MenuInput>().Active = true;
			m_Window.SetActive(false);
			WindowHandler.Default();
			PlatformWindowHandler.Default();

			InputManager.Reset();

		break;

		case Action.Exit:
			Application.Quit();
		break;
		}
	}
}
