using UnityEngine;
using System.Collections;
using System;
using FMOD.Studio;

/* Discription: TriggerSound
 * For small random sounds that should trigger when you click on them
 * 
 * Created by: Sebastian Olsson 07/05-14
 * Modified by:
 */

public class TriggerSound : TriggerEffect
{
	#region PrivateMemberVariables
	private FMOD.Studio.EventInstance 		m_Event;
	private string 							m_Path;
	private bool 		m_Played = false;
	private bool 		m_Holding = false;
	private GameObject 	m_Player;
	private int			m_PlayedCounter = 0;
	private Inspect		m_Inspect;
	private bool		m_IsInspecting = false;
	#endregion
	
	#region PublicMemberVariables
	public FMODAsset						m_Asset;
	public string	m_Parameter;
	public float	m_Value;
	public int		m_TimesToPlay;
	public string 	m_Input = "Fire1";
	#endregion

	override public string Name
	{
		get{ return "PlayTrigger"; }
	}

	void PlayTrigger()
	{
		if(m_TimesToPlay == 0)
		{
			--m_PlayedCounter;
		}
		if(getPlaybackState() != PLAYBACK_STATE.PLAYING && m_PlayedCounter < m_TimesToPlay)
		{
			++m_PlayedCounter;
			m_Played = true;
			if(m_Parameter != null)
			{
				m_Event.setParameterValue(m_Parameter, m_Value);
			}
			StartEvent ();
		}
	}

	void Start () 
	{
		m_Player = Camera.main.transform.parent.gameObject;
		CacheEventInstance ();
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.name == m_Player.name)
		{
			PlayTrigger ();
		}
	}

	void Update () 
	{
		if(this.GetComponent<Inspect>() != null)
		{
			m_IsInspecting = this.GetComponent<Inspect> ().IsInspecting;
			if(m_IsInspecting && !m_Played)
			{
				m_Played = true;
				PlayTrigger();
				
				m_IsInspecting = false;
				this.GetComponent<Inspect>().IsInspecting = false;
			}
			else if(m_Played && getPlaybackState() == PLAYBACK_STATE.SUSTAINING && !m_IsInspecting)
			{
				m_Played = false;
			}
		}

		var attributes = UnityUtil.to3DAttributes (m_Player);
		ERRCHECK (m_Event.set3DAttributes(attributes));		
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
