using UnityEngine;
using System.Collections;
using FMOD.Studio;

/* Discription: TriggerSound
 * For small random sounds that should trigger when you click on them
 * 
 * Created by: Sebastian Olsson 07/05-14
 * Modified by:
 */

public class TriggerSound : SoundComponent
{
	#region PrivateMemberVariables
	private bool 		m_Played = false;
	private bool 		m_Holding = false;
	private GameObject 	m_Player;
	private int			m_PlayedCounter = 0;
	private Inspect		m_Inspect;
	private bool		m_IsInspecting = false;
	#endregion
	
	#region PublicMemberVariables
	public string	m_Parameter;
	public float	m_Value;
	public int		m_TimesToPlay;
	public string 	m_Input = "Fire1";
	#endregion

	void Play()
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
				Evt.setParameterValue(m_Parameter, m_Value);
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
			Play ();
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
				Play();
				
				m_IsInspecting = false;
				this.GetComponent<Inspect>().IsInspecting = false;
			}
			else if(m_Played && getPlaybackState() == PLAYBACK_STATE.SUSTAINING && !m_IsInspecting)
			{
				m_Played = false;
			}
		}

		var attributes = UnityUtil.to3DAttributes (m_Player);
		ERRCHECK (Evt.set3DAttributes(attributes));		
	}
}
