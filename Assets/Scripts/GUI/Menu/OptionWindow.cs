using UnityEngine;
using System.Collections;

/* In order to have different option windows within the option folder
 * in the menus such as audio, graphics etc. 
 * Used to show the selected window on click and hide the rest of the windows. 
 * 
 * Created By: Jon Wahlström 2014-05-05
 */

public class OptionWindow : MonoBehaviour 
{
	#region PublicMemberVariables
	public GameObject m_Show; 
	public GameObject m_Hide;
	#endregion

	void OnClick()
	{
		m_Show.SetActive (true);
		m_Hide.SetActive (false);
	}
}
