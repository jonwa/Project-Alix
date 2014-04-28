using UnityEngine;
using System.Collections;

/* 
 * 
 * Created By: Jon Wahlström 2014-04-22
 * Modified By: 
 */

public class LoadGameButton : MonoBehaviour 
{
	#region PublicMemberVariables
	public UILabel m_InputText = null;
	#endregion

	void OnClick()
	{
		string input = m_InputText.text.ToString ();
		
		if(!string.IsNullOrEmpty(input))
		{
			GameData.Load(input);
		}
	}
}
