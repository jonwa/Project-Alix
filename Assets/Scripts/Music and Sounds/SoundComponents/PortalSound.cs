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
	private GameObject	m_GameObject;
	public float		m_Range;
	private GameObject	m_Player;
	private HouseCall	m_HouseCall;
	private int			m_HouseTarget;
	private Locked		m_LockedPortal;
	private Vector3			m_PortalPosition;
	private Vector3			m_PlayerPosition;
	#endregion
	
	#region PublicMemberVariables
	public string[]	m_Parameters;
	#endregion

	public override void PlaySound()
	{

	}

	void Play()
	{
		Vector3 deltaPosition = new Vector3 ();
		m_PlayerPosition = m_Player.transform.position;
		deltaPosition = m_PlayerPosition - m_PortalPosition;

		m_Range = deltaPosition.magnitude / 100;
		//Debug.Log (Math.Round (m_Range,2));

		if(m_Range > 0.25)
		{
			Evt.stop();
		}
		else if(m_Range == 0.25)
		{
			m_Range = 0.25f;
			Evt.setParameterValue (m_Parameters [0], m_Range);
		}
		else if(m_Range < 0.25)
		{
			Evt.setParameterValue (m_Parameters [0], m_Range);
		}

	}

	void Start () 
	{
		m_PortalPosition = this.transform.position;
		m_Player = Camera.main.transform.parent.gameObject;
		m_HouseCall = Camera.main.GetComponent<HouseCall> ();
		m_GameObject = this.gameObject;
	}
	
	void Update () 
	{
		m_HouseTarget = Camera.main.GetComponent<HouseCall> ().GetTargetHouse();
		//Debug.Log (m_HouseTarget);
		//Might need to change, not sure how m_HouseTarget really works
		if(m_HouseTarget == 0)
		{
			if(getPlaybackState() == PLAYBACK_STATE.STOPPED)
			{
				CacheEventInstance();
				StartEvent();
			}
			Play();
		}

		var attributes = UnityUtil.to3DAttributes (m_GameObject);
		ERRCHECK (Evt.set3DAttributes(attributes));	
	}
}
