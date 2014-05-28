using UnityEngine;
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
	private bool			m_Colliding;
	#endregion

	public PLAYBACK_STATE GetPlayBackState
	{
		get{return getPlaybackState();}
	}

	
	void Start () 
	{
		m_Player = Camera.main.transform.parent.gameObject;
		m_PlayerName = m_Player.name;

		CacheEventInstance ();

	}

	void Update () 
	{
		m_Colliding = GetComponentInChildren<PortalChildScript> ().Colliding;
		if(m_Colliding && getPlaybackState() != PLAYBACK_STATE.PLAYING)
		{
			GetComponentInChildren<PortalChildScript> ().Colliding = false;
			StartEvent();
		}

		var attributes = UnityUtil.to3DAttributes (m_Player);
		ERRCHECK (Evt.set3DAttributes(attributes));	
	}
}
