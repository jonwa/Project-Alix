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
	#endregion
	
	#region PublicMemberVariables
	public string	m_Parameter;
	public float	m_Value;
	public int		m_TimesToPlay;
	public string 	m_Input = "Fire1";
	//public string	m_Object;
	#endregion

	public override void PlaySound()
	{
		if(m_TimesToPlay == 0)
		{
			--m_PlayedCounter;
		}
		if(getPlaybackState() != PLAYBACK_STATE.PLAYING && m_Holding && !m_Played && m_PlayedCounter < m_TimesToPlay)
		{
			++m_PlayedCounter;
			m_Played = true;
			Evt.setParameterValue(m_Parameter, m_Value);
			StartEvent ();
		}
		else if(!m_Holding && m_Played)
		{
			m_Played = false;
		}
	}

	void Start () 
	{
		m_Player = Camera.main.transform.parent.gameObject;
		CacheEventInstance ();
	}

	void Update () 
	{
		if(this.gameObject.GetComponent<PickUp>() != null)
		{
			m_Holding = this.gameObject.GetComponent<PickUp>().GetHoldingObject();
		}		
		var attributes = UnityUtil.to3DAttributes (m_Player);
		ERRCHECK (Evt.set3DAttributes(attributes));		
	}
}
