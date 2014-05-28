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

public class PortalSound : SoundComponent
{
	#region PrivateMemberVariables
	private string			m_PlayerName;
	private GameObject		m_Player;
	#endregion
	
	void Start () 
	{
		m_PlayerName = Camera.main.transform.parent.gameObject.name;
		m_Player = Camera.main.transform.parent.gameObject;
		CacheEventInstance ();
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == m_PlayerName )
		{
			Debug.Log (getPlaybackState());
			if(getPlaybackState() != PLAYBACK_STATE.PLAYING)
			{
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
