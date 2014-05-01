using UnityEngine;
using System.Collections;

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
