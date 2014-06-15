using UnityEngine;
using System;
using System.Collections;
using FMOD.Studio;

/* Discription: SoundEffect, starts a soundeffect on trigger
 * 
 * Created by: Sebastian Olsson: 23-04-2014
 * Modified by: 
 * 
 */

public class SoundEffect : TriggerComponent 
{
	#region PrivateMemberVariables
	private FMOD.Studio.EventInstance 		m_Event;
	private string 							m_Path;
	private bool							m_Started = false;
	private int								m_Counter;
	private GameObject						m_GameObject;
	#endregion

	#region PublicMemberVariables
	public FMODAsset						m_Asset;
	public string[]							m_Parameters;
	public float							m_Value;
	public bool								m_StartOnAwake = false;
	public bool								m_IsPlayer = false;
	#endregion

	override public string Name
	{
		get{ return "PlaySoundEffect"; }
	}

	public float Parameter
	{
		get{return m_Value; }
		set{m_Value = value;}
	}

	void Start()
	{
		CacheEventInstance();
		if(m_StartOnAwake)
		{
			StartEvent();
		}

		if(m_IsPlayer)
		{
			m_GameObject = Camera.main.transform.parent.gameObject;
		}
		else
		{
			m_GameObject = this.gameObject;
		}
	}

	public void PlaySoundEffect()
	{
		if (getPlaybackState() != FMOD.Studio.PLAYBACK_STATE.PLAYING) 
		{
			m_Started = false;
		}
		if (!m_Started) 
		{
			if(m_Parameters.Length != 0)
			{
				m_Event.setParameterValue(m_Parameters[0], m_Value);
			}
			StartEvent();
		}
	}

	void Update()
	{
		if (m_Event != null && m_Event.isValid ()) 
		{
			var attributes = UnityUtil.to3DAttributes (m_GameObject);			
			ERRCHECK (m_Event.set3DAttributes(attributes));			
		} 
		else 
		{
			m_Event = null;
		}

	}

	void OnDisable()
	{
		if(m_Event != null)
		{
			m_Event.stop ();
			m_Event.release ();
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
		m_Started = true;
	}

	//Checks for errors
	FMOD.RESULT ERRCHECK(FMOD.RESULT result)
	{
		FMOD.Studio.UnityUtil.ERRCHECK(result);
		return result;
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
