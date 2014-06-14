using UnityEngine;
using System.Collections;

public class ChangeScene : TriggerEffect
{
	public int m_LoadLevel;


	override public string Name
	{
		get{ return "TriggerScene"; }
	}

	public void TriggerScene()
	{
		DontDestroyOnLoad(gameObject);
		Application.LoadLevel(m_LoadLevel);
	}

	void OnLevelWasLoaded()
	{
		DestroyImmediate(this);
	}
}
