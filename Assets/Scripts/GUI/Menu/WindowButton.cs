using UnityEngine;
using System.Collections;

/*
 * Created By: Jon Wahlström 2014-04-22
 * Modified By:
 */

public class WindowButton : MonoBehaviour {

	public enum Action { Show, Continue, Exit };
	
	public GameObject m_Window;
	public int m_Id;
	public Action m_Action = Action.Show;
	
	void OnClick()
	{
		switch(m_Action)
		{
		case Action.Show:
			if(m_Window != null)
			{
				WindowHandler.Show(m_Id, m_Window);
			}
		break;	
		
		case Action.Continue:
			m_Window.SetActive(false);
			WindowHandler.Default();
			m_Window.transform.parent.GetComponent<MenuInput>().Active = false;
			Camera.main.gameObject.GetComponent<Raycasting>().ShowHover = true; 
			Camera.main.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
		break;

		case Action.Exit:
			Application.Quit();
		break;
		}
	}
}
