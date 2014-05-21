using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using FMOD.Studio;

/* Discription: Music Managers
 * Managing the Music with FMOD, has full controll over the music
 * 
 * Created by: Sebastian Olsson 15/04-14
 * Modified by:
 */

public class MusicManager : MonoBehaviour 
{
	#region PrivateMemberVariables
	private FMOD.Studio.EventInstance 		m_Event;
	private bool 							m_Started		= false;
	private string 							m_Path;
	#endregion

	#region PublicMemberVariables
	[Range(0,1)] public float				m_Location;
	[Range(0,1)] public float 				m_Progress;
	[Range(0,1)] public float 				m_PauseAndDeath;
	public bool 							startEventOnAwake	= true;
	public FMODAsset						m_Asset;
	public string[]							m_Parameters;
	#endregion

	public FMOD.Studio.EventInstance GetEvent
	{
		get{ return m_Event; }
	}

	public void SetParameterValue(string p_Name, float p_Value)
	{
		m_Event.setParameterValue (p_Name, p_Value);
	}

	void Start()
	{
		CacheEventInstance();
		m_Event.setParameterValue (m_Parameters [0], m_Location);
		m_Event.setParameterValue (m_Parameters [1], m_Progress);
		m_Event.setParameterValue (m_Parameters [2], m_PauseAndDeath);

		if (startEventOnAwake)
		{
			StartEvent();
		}
	}

	void Update()
	{
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
			FMOD.Studio.UnityUtil.LogError("No asset or path specified for Event Emitter");
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
			FMOD.Studio.UnityUtil.LogError("Event retrieval failed: " + m_Path);
		}
		
		m_Started = true;
	}

	public FMOD.Studio.ParameterInstance getParameter(string name)
	{
		FMOD.Studio.ParameterInstance param = null;
		ERRCHECK(m_Event.getParameter(name, out param));
		
		return param;
	}

	FMOD.RESULT ERRCHECK(FMOD.RESULT result)
	{
		FMOD.Studio.UnityUtil.ERRCHECK(result);
		return result;
	}
}
