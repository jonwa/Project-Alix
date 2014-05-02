using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

/* Should be placed on the Load and Save object in menu hierarchy
 * Handles the names for each slot. 
 * 
 * Created By: Jon Wahlström 2014-05-01
 * Modified By: 
 */

public class SaveLoadGameButtonData : MonoBehaviour 
{
	#region PublicMemberVariables
	public GameObject   m_AutoSave;
	public GameObject[] m_SlotNames;
	#endregion

	public int SlotID{get; set;}

	public string SlotName
	{
		get{ return m_SlotNames[SlotID].GetComponent<UILabel>().text; }
		set{ m_SlotNames[SlotID].GetComponentInChildren<UILabel>().text = value; }
	}

	void Start()
	{
		SetExistingSaves();
	}

	void SetExistingSaves()
	{
		List<string> names = new List<string>();
		names = GameData.FileNames;

		if(names.Count > 0)
		{
			int i = 0;

			if(names[0].Contains("autoSave_"))
			{
				m_AutoSave.GetComponentInChildren<UILabel>().text = names[0];
				++i;
			}
			
			foreach(GameObject go in m_SlotNames)
			{
				if(i < names.Count)
				{
					go.GetComponentInChildren<UILabel>().text = names[i];
					++i;
				}
			}
		}
	}
}
