using UnityEngine;
using System.Collections;

/* Choices you may want to do while reading 
 * a book in the game. Calls a function in
 * the BookWindow class that performs the action
 * 
 * Created By: Jon Wahlström 2014-04-16
 * Modified By:  
 */

public class BookButtons : MonoBehaviour 
{
	#region publicMemberVariables
	public enum Action{	None, Next, Previous, Close };

	public GameObject m_Window = null; 
	public Action  	  m_Action = Action.None;
	#endregion

	void OnClick()
	{
		switch (m_Action)
		{
		case Action.None:
			break;

		case Action.Next:
			BookWindow.NextPage();
			break;

		case Action.Previous:
			BookWindow.PreviousPage();
			break;

		case Action.Close:
			if(m_Window == null) return;
			m_Window.SetActive(false);
			Camera.main.gameObject.GetComponent<Raycasting>().ShowHover = true;
			Camera.main.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
			BookWindow.Close();
			break;
		}
	}
}
