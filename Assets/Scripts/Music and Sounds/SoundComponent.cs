using UnityEngine;
using System.Collections;
using System;
using FMOD.Studio;

/* Discription: SoundComponent
 * Base class for the sound components
 * 
 * Created by: Sebastian Olsson 05/05-14
 * Modified by:
 */

public abstract class SoundComponent : ObjectComponent 
{
	#region PrivateMemberVariables
	private string 							m_Path;
	#endregion
	
	#region PublicMemberVariables
	public FMOD.Studio.EventInstance 	m_Event;
	public FMOD.Studio.EventInstance 	m_SubEvent;
	public FMODAsset					m_Asset;
	public bool 						m_StartOnAwake	 	= true;
	public string[]						m_SubEvents;
	#endregion

	public virtual void Start()
	{
		CacheEventInstance();
		if (m_StartOnAwake) 
		{
			StartEvent();
			if(m_SubEvents != null)
			{
				StartSubEvent();
			}
		}
	}
	
	public virtual void Update()
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

	public virtual void PlaySound()
	{
		
	}

	public override void Interact()
	{
		PlaySound ();
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
	
	public FMOD.Studio.PLAYBACK_STATE getSubEventPlaybackState()
	{
		if (m_SubEvent == null || !m_SubEvent.isValid())
			return FMOD.Studio.PLAYBACK_STATE.STOPPED;
		
		FMOD.Studio.PLAYBACK_STATE state = PLAYBACK_STATE.IDLE;
		
		if (ERRCHECK (m_SubEvent.getPlaybackState(out state)) == FMOD.RESULT.OK)
		{
			return state;
		}
		
		
		return FMOD.Studio.PLAYBACK_STATE.STOPPED;
	}
	
	public void OnDisable()
	{
		if(m_SubEvents != null)
		{
			m_SubEvent.stop();
			m_SubEvent.release();
		}
		m_Event.stop ();
		m_Event.release ();
	}
	
	public void CacheEventInstance()
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
		
		if(m_SubEvents != null)
		{
			m_Event.createSubEvent(m_SubEvents[0], out m_SubEvent);
		}
		//m_Started = true;
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
			if(m_SubEvents != null)
			{
				StartSubEvent();
			}
		}
		else
		{
			FMOD.Studio.UnityUtil.LogError("Event failed: " + m_Path);
		}
	}
	
	public void StartSubEvent()
	{
		if(m_SubEvent != null && m_SubEvent.isValid())
		{
			ERRCHECK (m_SubEvent.start ());
		}
		else
		{
			FMOD.Studio.UnityUtil.LogError("SubEvent failed: " + m_Path);
		}
		
	}
	
	//Checks for errors
	public FMOD.RESULT ERRCHECK(FMOD.RESULT result)
	{
		FMOD.Studio.UnityUtil.ERRCHECK(result);
		return result;
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
