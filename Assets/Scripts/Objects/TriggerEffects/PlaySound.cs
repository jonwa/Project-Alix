using UnityEngine;
using System;
using System.Collections;
using FMOD.Studio;


/* Discription: PlaySound, starts a soundeffect on triggering
 * 
 * Created by: Sebastian Olsson: 23-04-2014
 * Modified by: 
 * 
 */

public class PlaySound : TriggerEffect 
{
	private FMOD.Studio.EventInstance 		m_Event;
	private FMOD.Studio.ParameterInstance	m_Parameter;
	private string 							m_Path;
	private bool							m_Started;

	public FMODAsset				m_Asset;
	public bool 					m_StartOnAwake 	= true;
	public bool						m_StartOnTrigger = false;

	override public string Name
	{
		get{ return "PlaySoundEffect"; }
	}
	
	void PlaySoundEffect()
	{
		if (!m_Started) 
		{
			StartEvent();
		}
	}

	void Start()
	{
		m_Started = false;
		CacheEventInstance();
	}
	
	void Update()
	{
		if (m_Event != null && m_Event.isValid ()) 
		{
			var attributes = UnityUtil.to3DAttributes (gameObject);			
			ERRCHECK (m_Event.set3DAttributes(attributes));			
		} 
		else 
		{
			m_Event = null;
		}
	}
	
	public FMOD.Studio.PLAYBACK_STATE getPlaybackState()
	{
		if (m_Event == null || !m_Event.isValid())
			return FMOD.Studio.PLAYBACK_STATE.STOPPED;
		
		FMOD.Studio.PLAYBACK_STATE state = PLAYBACK_STATE.IDLE;
		
		if (ERRCHECK (m_Event.getPlaybackState(out state)) == FMOD.RESULT.OK)
			return state;
		
		return FMOD.Studio.PLAYBACK_STATE.STOPPED;
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
		m_Started = true;
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


	//Overload when saveing data for component.
	public override void Serialize(ref JSONObject jsonObject)
	{
		
	}
	
	//Overload when loading data for component.
	public override void Deserialize(ref JSONObject jsonObject)
	{
		
	}
}
