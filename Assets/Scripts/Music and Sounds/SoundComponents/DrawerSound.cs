using UnityEngine;
using System.Collections;
using FMOD.Studio;

/* Discription: DrawerSound
 * Play sound when interacting with drawers
 * 
 * Created by: Sebastian Olsson 05/05-14
 * Modified by:
 */
//TODO: Get working with the new sound
public class DrawerSound : SoundComponent 
{
	#region PrivateMemberVariables
	private float 		m_MouseYPosition;
	private bool 		m_Positive 			= false;
	private bool 		m_Negative 			= false;
	private GameObject	m_GameObject;
	#endregion

	#region PublicMemberVariables
	public string		m_Horizontal		= "Mouse Y";
	#endregion

	void Start()
	{
		CacheEventInstance ();
		m_GameObject = this.gameObject;
	}

	void Update()
	{
		var attributes = UnityUtil.to3DAttributes (m_GameObject);
		ERRCHECK (Evt.set3DAttributes(attributes));
	}

	public override void PlaySound()
	{
		m_MouseYPosition = Input.GetAxis(m_Horizontal);

		if(m_MouseYPosition != 0 && getPlaybackState() != FMOD.Studio.PLAYBACK_STATE.PLAYING)
		{
			if(m_MouseYPosition > 0 && !m_Positive)
			{
				//StartEvent();
				m_Positive = true;
				m_Negative = false;
			}
			else if(m_MouseYPosition < 0 && !m_Negative)
			{
				//StartEvent();
				m_Negative = true;
				m_Positive = false;
			}
		}
	}


}
