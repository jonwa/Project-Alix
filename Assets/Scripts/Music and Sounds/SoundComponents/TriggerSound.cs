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
	private bool m_Played = false;
	#endregion
	
	#region PublicMemberVariables
	public string m_Input;
	public string	m_Object;
	#endregion

	public override void PlaySound()
	{
		if(getPlaybackState() != PLAYBACK_STATE.PLAYING && !m_Played)
		{
			m_Played = true;
			switch(m_Object)
			{
			default:
				break;
			}
			StartEvent ();
		}
		else if(m_Played && Input.GetButtonDown(m_Input) && getPlaybackState() == PLAYBACK_STATE.SUSTAINING)
		{
			m_Played = false;
		}
	}

	void Start () 
	{
		CacheEventInstance ();
	}

	void Update () 
	{
		var attributes = UnityUtil.to3DAttributes (this.gameObject);
		ERRCHECK (Evt.set3DAttributes(attributes));		
	}
}
