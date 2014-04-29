using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using FMOD.Studio;

/* Discription: Music Managers
 * Managing the Music with FMOD
 * 
 * Created by: Sebastian Olsson 15/04-14
 * Modified by:
 */
//TODO: Rensa scriptet på skit, skriv ett smidigt sätt att lägga till parametrar vid behov.

public class MusicManager : MonoBehaviour 
{
	#region PrivateMemberVariables
	private FMOD.Studio.EventInstance 		m_Event;
	private FMOD.Studio.ParameterInstance	m_LocationParameter;
	private FMOD.Studio.ParameterInstance	m_ProgressParameter;
	private bool 							m_Started		= false;
	private string 							m_Path;
	#endregion

	#region PublicMemberVariables
	[Range(0,1)] public float				m_Element0;
	[Range(0,1)] public float 				m_Element1;
	public bool 							startEventOnAwake	= true;
	public FMODAsset						m_Asset;
	public string[]							m_Parameters;
	#endregion

	#region ParameterSetAndGetFunktions
	public float Element0
	{
		set{ m_Element0 = value; }
		get{ return m_Element0; }
	}

	public float Element1
	{
		set{ m_Element1 = value; }
		get{ return m_Element1; }
	}
	#endregion
	
	void Start()
	{
		CacheEventInstance();
		if (startEventOnAwake)
		{
			StartEvent();
		}
		m_Event.getParameter(m_Parameters[0], out m_LocationParameter);
		m_Event.getParameter (m_Parameters [1], out m_ProgressParameter);

		m_LocationParameter.setValue (m_Element0);
		m_ProgressParameter.setValue (m_Element1);
	}

	void Update()
	{
		m_LocationParameter.setValue (m_Element0);
		m_ProgressParameter.setValue (m_Element1);
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
