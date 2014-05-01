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
	#region PrivateMemberVariables
	private FMOD.Studio.EventInstance 		m_Event;
	private FMOD.Studio.EventInstance 		m_SubEvent;
	private FMOD.Studio.ParameterInstance	m_Parameter;
	private string 							m_Path;
	private bool							m_Started;
	private string							m_PlayerName 	= "Player Controller Example";
	private float 							m_MouseYPosition;
	private bool 							m_Positive 			= false;
	private bool 							m_Negative 			= false;
	#endregion

	#region PublicMemberVariables
	public string 					m_Input				= "Fire1";
	public string					m_Horizontal		= "Mouse Y";
	public FMODAsset				m_Asset;
	[Range(0,1)] public float		m_Location;
	public bool 					m_StartOnAwake	 	= true;
	public bool						m_StartOnTrigger 	= false;
	public string[]					m_SubEvents;
	#endregion

	void Start()
	{
		m_Started = false;

		CacheEventInstance();
		if (m_StartOnAwake) 
		{
			StartEvent();
			if(m_SubEvents != null)
			{
				Debug.Log ("Hejsan");
				StartSubEvent();
			}
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
			m_MouseYPosition = Input.GetAxis(m_Horizontal);

			if(m_MouseYPosition != 0 && (getSubEventPlaybackState() == FMOD.Studio.PLAYBACK_STATE.STOPPED ||
			                             getSubEventPlaybackState() == FMOD.Studio.PLAYBACK_STATE.SUSTAINING))
			{
				if(m_MouseYPosition > 0 && !m_Positive)
				{
					StartEvent();
					m_Positive = true;
					m_Negative = false;
				}
				else if(m_MouseYPosition < 0 && !m_Negative)
				{
					StartEvent();
					m_Negative = true;
					m_Positive = false;
				}
			}
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (!m_Started && m_StartOnTrigger)
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
	
	void OnDisable()
	{
		if(m_SubEvents != null)
		{
			m_SubEvent.stop();
			m_SubEvent.release();
		}
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
	FMOD.RESULT ERRCHECK(FMOD.RESULT result)
	{
		FMOD.Studio.UnityUtil.ERRCHECK(result);
		return result;
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
