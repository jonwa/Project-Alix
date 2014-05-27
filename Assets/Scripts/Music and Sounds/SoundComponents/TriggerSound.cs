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
	private bool m_Holding = false;
	#endregion
	
	#region PublicMemberVariables
	public string m_Input;
	public string	m_Object;
	#endregion

	public override void PlaySound()
	{
		if(getPlaybackState() != PLAYBACK_STATE.PLAYING && m_Holding && !m_Played)
		{
			m_Played = true;
			switch(m_Object)
			{
			default:
				break;
			}
			StartEvent ();
		}
		else if(!m_Holding && m_Played)
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
		if(this.gameObject.GetComponent<PickUp>() != null)
		{
			m_Holding = this.gameObject.GetComponent<PickUp>().GetHoldingObject();
		}		
		var attributes = UnityUtil.to3DAttributes (this.gameObject);
		ERRCHECK (Evt.set3DAttributes(attributes));		
	}
}
