using UnityEngine;
using System.Collections;
using FMOD.Studio;

/* Discription: PhoneConversation
 * Plays a Sound when the phone has been answered
 * 
 * Created by: Sebastian Olsson 13/05-14
 * Modified by:
 */

[RequireComponent(typeof(PhoneSound))]
public class PhoneConversation : SoundComponent 
{
	#region PrivateMemberVariables
	private bool 			m_Answered;
	private bool			m_Ringing;
	private GameObject						m_GameObject;
	private bool			m_DonePlaying = false;
	#endregion
	
	#region PublicMemberVariables
	#endregion

	void Start () 
	{
		m_GameObject = this.gameObject;

	}

	public override void PlaySound()
	{
		m_Answered = this.GetComponent<PhoneSound> ().Answered;
		m_Ringing = this.GetComponent<PhoneSound> ().Ringing;
		if(m_Answered && !m_DonePlaying)
		{
			StartEvent();
			m_DonePlaying = true;
		}
		if(!m_Ringing)
		{
			if(Evt != null)
			{
				Evt.stop();
			}
		}
	}
	
	void Update () 
	{
		var attributes = UnityUtil.to3DAttributes (m_GameObject);
		ERRCHECK (Evt.set3DAttributes(attributes));			

		if(getPlaybackState() == PLAYBACK_STATE.SUSTAINING)
		{
			Evt.stop();
		}
	}
}
