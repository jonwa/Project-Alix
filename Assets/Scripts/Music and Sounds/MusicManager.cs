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

public class MusicManager : MonoBehaviour 
{
	private FMOD.Studio.EventInstance 		m_Event;
	private FMOD.Studio.ParameterInstance	m_ParameterLocation;
	private FMOD.Studio.ParameterInstance	m_ParameterCombat;
	private bool 							m_Started 	= false;
	private string 							m_Path;

	[Range(0,1)] public float		m_Location;
	[Range(0,1)] public float 		m_Combat;
	public bool 					startEventOnAwake 	= true;
	public FMODAsset				m_Asset;
	public string[]					m_Parameters;

	public float Location
	{
		set{ m_Location = value; }
		get{ return m_Location; }
	}

	public void hej(){
		}

	public float Combat
	{
		set{ m_Combat = value; }
		get{ return m_Combat; }
	}

	void Start()
	{
		CacheEventInstance();
		if (startEventOnAwake)
		{
			StartEvent();
		}

		m_Event.getParameter(m_Parameters[0], out m_ParameterLocation);
		m_Event.getParameter(m_Parameters[1], out m_ParameterCombat);

		m_ParameterLocation.setValue (m_Location);
		m_ParameterCombat.setValue (m_Combat);
	}

	void Update()
	{
		m_ParameterLocation.setValue (m_Location);
		m_ParameterCombat.setValue (m_Combat);
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
			m_Event = FMOD_StudioSystem.instance.getEvent(m_Asset.id);
			
		}
		else if (!String.IsNullOrEmpty(m_Path))
		{
			m_Event = FMOD_StudioSystem.instance.getEvent(m_Path);
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
		
		// Attempt to release as oneshot
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
