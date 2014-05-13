using UnityEngine;
using System;
using System.Collections;
using FMOD.Studio;

public class MenuSound : MonoBehaviour 
{
	public FMODAsset m_Asset;
	private FMOD.Studio.EventInstance 		m_Event;
	private string 							m_Path;

	void Start()
	{
		CacheEventInstance ();

	}

	void CacheEventInstance()
	{
		if (m_Asset != null)
		{
			m_Event = FMOD_StudioSystem.instance.GetEvent(m_Asset.id);
			
		}
		else if (!String.IsNullOrEmpty(m_Path))
		{
			m_Event = FMOD_StudioSystem.instance.GetEvent(m_Path);
		}
		else
		{
			FMOD.Studio.UnityUtil.LogError("No Asset/path for the Event");
		}
	}

	public void StartEvent()
	{		
		if (m_Event == null || !m_Event.isValid())
		{
			CacheEventInstance();
		}
		
		if (m_Event != null && m_Event.isValid())
		{
			ERRCHECK(m_Event.start());
		}
		else
		{
			FMOD.Studio.UnityUtil.LogError("Event failed: " + m_Path);
		}
	}

	//Checks for errors
	FMOD.RESULT ERRCHECK(FMOD.RESULT result)
	{
		FMOD.Studio.UnityUtil.ERRCHECK(result);
		return result;
	}

	void OnHover(bool status)
	{
		if(status)
		{
			Debug.Log("Hover");
			StartEvent();
		}
	}

	void OnClick()
	{
		StartEvent ();
	}
}
