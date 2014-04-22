using UnityEngine;
using System.Collections;

/*
 * Created By: Jon Wahlström 2014-04-22
 * Modified By:
 */

public class WindowButton : MonoBehaviour {

	public enum Action { show, hide, exit };
	
	public GameObject m_Window;
	public int m_Id;
	public Action m_Action = Action.show;
	
	void OnClick()
	{
		switch(m_Action)
		{
		case Action.show:
			if(m_Window != null)
			{
				WindowHandler.Show(m_Id, m_Window);
			}
		break;	
		
		case Action.exit:
			Application.Quit();
		break;
		}
	}
}
