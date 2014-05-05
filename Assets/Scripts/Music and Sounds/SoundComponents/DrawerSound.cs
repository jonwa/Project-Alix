using UnityEngine;
using System.Collections;

/* Discription: DrawerSound
 * Play sound when interacting with drawers
 * 
 * Created by: Sebastian Olsson 05/05-14
 * Modified by:
 */

public class DrawerSound : SoundComponent 
{
	#region PrivateMemberVariables
	private float 		m_MouseYPosition;
	private bool 		m_Positive 			= false;
	private bool 		m_Negative 			= false;
	#endregion

	#region PublicMemberVariables
	public string		m_Horizontal		= "Mouse Y";
	#endregion


	public override void PlaySound()
	{
		m_MouseYPosition = Input.GetAxis(m_Horizontal);
		
		if(m_MouseYPosition != 0 && (getSubEventPlaybackState() == FMOD.Studio.PLAYBACK_STATE.STOPPED ||
		                             getSubEventPlaybackState() == FMOD.Studio.PLAYBACK_STATE.SUSTAINING))
		{
			if(m_MouseYPosition > 0 && !m_Positive)
			{
				StartEvent();
				m_Positive = true;
				m_Negative = false;
			}
			else if(m_MouseYPosition < 0 && !m_Negative)
			{
				StartEvent();
				m_Negative = true;
				m_Positive = false;
			}
		}
	}
}
