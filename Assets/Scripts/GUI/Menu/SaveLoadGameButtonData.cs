using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

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

		int i = 0;

		if(names[0].Contains("autoSave_"))
		{
			m_AutoSave.GetComponentInChildren<UILabel>().text = names[0];
			++i;
		}
		
		foreach(GameObject go in m_SlotNames)
		{
			go.GetComponentInChildren<UILabel>().text = names[i];
			++i;
		}
	}
}
