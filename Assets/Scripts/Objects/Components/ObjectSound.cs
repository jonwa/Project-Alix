using UnityEngine;
using System;
using System.Collections;
using FMOD.Studio;

/* Discription: Object Sound
 * Used to play sounds in a 3D space
 * 
 * Created by: Sebastian Olsson 15/04-14
 * Modified by:
 */

//TODO: Om man går in i en trigger om och om igen så ska inte ljudet spelas om det redan körs.
//		Kolla parametrarna med ljudläggarna, vad de vill ha samt vad för ljudeffekter som ska finnas i spelet.

[RequireComponent(typeof(BoxCollider))]
public class ObjectSound : ObjectComponent 
{
	private FMOD.Studio.EventInstance 		m_Event;
	private FMOD.Studio.ParameterInstance	m_Parameter;
	private string 							m_Path;
	private bool							m_Started;
	private string							m_PlayerName = "Player Controller Example";
	
	public FMODAsset				m_Asset;
	[Range(0,1)] public float		m_Location;
	public bool 					m_StartOnAwake 	= true;
	public bool						m_StartOnTrigger = false;


	void Start()
	{
		m_Started = false;

		CacheEventInstance();
		if (m_StartOnAwake) 
		{
			StartEvent();
		}
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

	public override void Interact ()
	{
		if (!m_Started) 
		{
			StartEvent();
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (m_Started && m_StartOnTrigger)
		{
			if(collider.gameObject.name == m_PlayerName)
			{
				if(getPlaybackState() == FMOD.Studio.PLAYBACK_STATE.STOPPED)
				{
					StartEvent();
				}
			}
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

	void OnDisable()
	{
		m_Event.stop ();
		m_Event.release ();
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

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
