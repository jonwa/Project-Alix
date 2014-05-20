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
	private FMOD.Studio.EventInstance 		m_Event;
	private FMOD.Studio.ParameterInstance	m_Parameter;
	private string 							m_Path;
	#endregion
	
	#region PublicMemberVariables
	public FMODAsset						m_Asset;
	public bool 							m_StartOnAwake	= true;
	#endregion



	public void Start()
	{
		CacheEventInstance();
		if (m_StartOnAwake) 
		{
			StartEvent();
		}
	}
	
	void Update()
	{
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
	
	public void OnDisable()
	{
		if(m_Event != null)
		{
			m_Event.stop ();
			m_Event.release ();
		}
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
	}

	public void CacheEventInstance(FMODAsset p_Asset)
	{
		if (p_Asset != null)
		{
			m_Event = FMOD_StudioSystem.instance.GetEvent(p_Asset.id);
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
	public FMOD.RESULT ERRCHECK(FMOD.RESULT result)
	{
		FMOD.Studio.UnityUtil.ERRCHECK(result);
		return result;
	}

	public FMOD.Studio.EventInstance Evt
	{
		get{return m_Event;}
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
