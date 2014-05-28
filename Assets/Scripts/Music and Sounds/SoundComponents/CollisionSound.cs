using UnityEngine;
using System.Collections;

/* Discription: CollisionSound
 * Plays a sound X number of times in a 2D space when entering a trigger
 * 
 * Created by: Sebastian Olsson 28-05-14
 * Modified by:
 */

[RequireComponent(typeof(BoxCollider))]
public class CollisionSound : SoundComponent 
{
	#region PrivateMemberVariables
	private int		m_Counter = 0;
	private string						m_PlayerName;
	#endregion
	
	#region PublicMemberVariables
	public int 		m_NumberOfTimes;
	#endregion

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == m_PlayerName ) 
		{
			if(getPlaybackState() != FMOD.Studio.PLAYBACK_STATE.PLAYING)
			{
				if(m_Counter < m_NumberOfTimes)
				{
					++m_Counter;
					StartEvent();
				}
				else if(m_NumberOfTimes == 0)
				{
					StartEvent();
				}
			}
		}
	}

	void Start () 
	{
		m_PlayerName = Camera.main.transform.parent.gameObject.name;
		collider.isTrigger = true;
		CacheEventInstance ();
	}
}
