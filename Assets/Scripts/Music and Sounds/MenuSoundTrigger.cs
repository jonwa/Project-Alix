using UnityEngine;
using System;
using System.Collections;
using FMOD.Studio;

/* Discription: MenuSound
 * Sounds for menus and other UI
 * 
 * Created By: Sebastian Olsson, Jon Wahlström: 14-05-14
 * Modified by: 
 */

public class MenuSoundTrigger : MonoBehaviour 
{
	public FMODAsset m_Asset;
	public string	m_SoundType;
	private FMOD.Studio.EventInstance 		m_Event;
	private string 							m_Path;
	private GameObject					m_GameObject;
	private bool						m_Padlock = false;
	private bool						m_Book = false;
	
	void Start()
	{
		m_GameObject = GameObject.Find ("Object_Padlock_model");

		CacheEventInstance ();
		switch(m_SoundType)
		{
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

	void Update()
	{
		var attributes = UnityUtil.to3DAttributes (m_GameObject);
		ERRCHECK (m_Event.set3DAttributes(attributes));
	}

	void OnClick()
	{
		if(m_Padlock)
		{
			if(this.gameObject.GetComponent<PadlockTrigger>() != null)
			{
				bool locked = this.gameObject.GetComponent<PadlockTrigger>().Locked;
				if(!locked)
				{
					m_Event.setParameterValue("Outcome", 0.05f);
					StartEvent ();
				}
				else
				{
					m_Event.setParameterValue("Outcome", 0.15f);
					StartEvent ();
				}
			}
		}
		if(m_Book)
		{
			m_Event.setParameterValue("Action", 0.15f);
			StartEvent();
		}
	}
}