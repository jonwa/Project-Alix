using UnityEngine;
using System;
using System.Collections;
using FMOD.Studio;

public class MenuSound : MonoBehaviour 
{
	public FMODAsset m_Asset;
	public string	 m_MenuType;
	public string[]	 m_Parameters;

	private FMOD.Studio.EventInstance 	m_Event;
	private string 						m_Path;
	private bool						m_Menu = false;
	private bool						m_Padlock = false;
	private bool						m_Book = false;

	void Start()
	{
		CacheEventInstance ();
		switch(m_MenuType)
		{
		case "Menu":
			m_Menu = true;
			break;
		case "Padlock":
			m_Padlock = true;
			break;
		case "Book":
			m_Book = true;
			break;
		}
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
			if(m_Menu)
			{
				if(m_Parameters.Length != 0)
				{
					m_Event.setParameterValue(m_Parameters[0], 0.05f);
				}
				StartEvent();
			}
		}
	}

	void OnClick()
	{
		if(m_Menu || m_Book || m_Padlock)
		{
			if(m_Menu && m_Parameters.Length != 0)
			{
				m_Event.setParameterValue(m_Parameters[0], 0.15f);
			}
			StartEvent ();
		}
		if(m_Padlock)
		{
			if(this.gameObject.GetComponent<PadlockTrigger>() != null)
			{
				bool isLocked = this.gameObject.GetComponent<PadlockTrigger>().Locked;
				if(!isLocked)
				{
					StartEvent ();
				}
			}
		}
	}
}
