using UnityEngine;
using System.Collections;

/* Each save slot needs a individual ID in order to set the 
 * input name to the button
 * 
 * Created By: Jon Wahlström 2014-05-01
 * Modified By: 
 */

public class SaveGameButtonID : MonoBehaviour 
{
	#region PublicMemberVariables
	public int m_Id;
	#endregion

	void OnClick()
	{
		GameObject parent = transform.parent.gameObject; 
		parent.GetComponent<SaveLoadGameButtonData>().SlotID = m_Id;
	}
}
