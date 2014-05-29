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
	private string				m_PlayerName;
	private GameObject			m_Player;
	private PortalChildScript[]	m_PortalChildScripts;
	#endregion

	public PLAYBACK_STATE GetPlayBackState
	{
		get{return getPlaybackState();}
	}

	
	void Start () 
	{
				m_Player = Camera.main.transform.parent.gameObject;
				m_PlayerName = m_Player.name;

<<<<<<< HEAD
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

=======
		CacheEventInstance ();
>>>>>>> ef3d8a91a3ac4b4ae4142cc36cbde87e57623931
	}

	void Update () 
	{
		m_PortalChildScripts = GetComponentsInChildren<PortalChildScript> ();

		foreach(PortalChildScript p in m_PortalChildScripts)
		{
			if(p.Colliding && getPlaybackState() != PLAYBACK_STATE.PLAYING)
			{
				p.Colliding = false;
				StartEvent();
			}
		}

		var attributes = UnityUtil.to3DAttributes (m_Player);
		ERRCHECK (Evt.set3DAttributes(attributes));	
	}
}
