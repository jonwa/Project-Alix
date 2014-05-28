﻿using UnityEngine;
using System;
using System.Collections;
using FMOD.Studio;

/* Discription: PortalSound
 * The sound that portals make when you interact with them
 * 
 * Created By: Sebastian Olsson: 15-05-14
 * Modified by: 
 */
//TODO Put in parent to portals
public class PortalSound : SoundComponent
{
	#region PrivateMemberVariables
	private string			m_PlayerName;
	private GameObject		m_Player;
	#endregion
	
	void Start () 
	{
		m_Player = Camera.main.transform.parent.gameObject;
		m_PlayerName = m_Player.name;

		CacheEventInstance ();
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == m_PlayerName )
		{
			Debug.Log ("PLAYOR = " + m_Player);
			if(getPlaybackState() != PLAYBACK_STATE.PLAYING)
			{
				Debug.Log ("PLAYER = " + m_Player);
				CacheEventInstance();
				StartEvent();
				Debug.Log(getPlaybackState());

			}
		} 
	}

	void Update () 
	{
		var attributes = UnityUtil.to3DAttributes (m_Player);
		ERRCHECK (Evt.set3DAttributes(attributes));	
	}
}
