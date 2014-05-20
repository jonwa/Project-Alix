﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;

public class AudioStack : SoundComponent
{
	#region PrivateMemberVariables
	private MoviePlayer			m_Movie;
	private GameObject			m_GameObject;
	private bool				m_Played = false;
	private Stack<FMODAsset>	m_SoundStack = new Stack<FMODAsset>();
	private FMODAsset			m_SoundAsset;
	private PLAYBACK_STATE		m_PlaybackState;
	private int					m_Counter;
	#endregion
	
	#region PublicMemberVariables
	public List<FMODAsset>	m_Assets;
	public string[]			m_Parameters;
	public float[]			m_ParameterValues;
	#endregion

	public int Counter
	{
		get{return m_Counter;}
	}

	void PlayMovieSound()
	{
		Evt.stop ();
		if(m_SoundStack.Count != 0)
		{

			m_SoundAsset = m_SoundStack.Pop();
			CacheEventInstance(m_SoundAsset);
			if(m_Parameters != null && m_ParameterValues != null)
			{
				Evt.setParameterValue(m_Parameters[m_SoundStack.Count], m_ParameterValues[m_SoundStack.Count]);	
			}
			++m_Counter;
			StartEvent();
			m_Played = true;
		}
	}

	public void Play()
	{
		PlayMovieSound ();
	}

	void Start () 
	{
		m_Counter = 0;
		if(m_StartOnAwake)
		{
			CacheEventInstance();
			StartEvent();
		}

		foreach(FMODAsset asset in m_Assets)
		{
			m_SoundStack.Push(asset);
		}

		m_GameObject = this.gameObject;
	}

	void Update () 
	{
		if(m_SoundStack.Count != 0 && m_Played)
		{
			Evt.getPlaybackState(out m_PlaybackState);

			if(m_PlaybackState == PLAYBACK_STATE.SUSTAINING)
			{
				PlayMovieSound();
			}
		}

		var attributes = UnityUtil.to3DAttributes (m_GameObject);
		ERRCHECK (Evt.set3DAttributes(attributes));
	}
}
