using UnityEngine;
using System.Collections;

/* 
 * 
 * Created By: Jon Wahlström 2014-04-22
 * Modified By: 
 */

public class SaveGameButton : MonoBehaviour 
{
	#region PublicMemberVariables
	public UILabel m_InputText = null;
	#endregion

	void OnClick()
	{
		string input = m_InputText.text.ToString ();

		if(!string.IsNullOrEmpty(input) || input != "- EMPTY SLOT")
		{
			Debug.Log(input);
			GameObject parent = transform.parent.gameObject; 
			GameObject parentsParent = parent.transform.parent.gameObject;
			parentsParent.GetComponent<SaveLoadGameButtonData>().SlotName = input;

			GameData.Save(input);
		}
		else
		{
			//m_WarningText.text = "Please assign a name...";
		}

		m_InputText.text = "ENTER YOUR NAME";
	}
}
