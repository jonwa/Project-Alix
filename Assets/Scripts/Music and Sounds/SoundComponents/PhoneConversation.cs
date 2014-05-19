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
	#endregion
	
	#region PublicMemberVariables
	#endregion

	void Start () 
	{

	}

	public override void PlaySound()
	{
		m_Answered = this.GetComponent<PhoneSound> ().Answered;
		m_Ringing = this.GetComponent<PhoneSound> ().Ringing;
		if(m_Answered)
		{
			StartEvent();
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
		if(getPlaybackState() == PLAYBACK_STATE.SUSTAINING)
		{
			this.GetComponent<PhoneSound>().Answered = false;
			Evt.stop();
		}
	}
}
