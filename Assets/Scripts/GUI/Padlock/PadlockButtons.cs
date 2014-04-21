using UnityEngine;
using System.Collections;

/* A padlock can either choose the next or previous number
 * The actual functionallity is done in PadlockWindow.cs
 * 
 * Created By: Jon Wahlström 2014-04-16
 * Modified By: 
 */

public class PadlockButtons : MonoBehaviour 
{
	#region PublicMemberVariables
	public enum Action { None, Next, Previous, Close };
	public int 		  m_Id 	   = 0; 
	public GameObject m_Window = null; 
	public Action 	  m_Action = Action.None;
	#endregion

	void OnClick()
	{
		switch(m_Action)
		{
		case Action.None:

			break;

		case Action.Next:
			PadlockWindow.NextNumber(m_Id);
			break;

		case Action.Previous:
			PadlockWindow.PreviousNumber(m_Id);
			break;

		case Action.Close:
			if(m_Window == null) return; 

			m_Window.SetActive(false);
			Camera.main.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
			PadlockWindow.Close();
			break;
		}

	}
}
