using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class DigbyFoundYou : SoundComponent 
{
	#region PublicMemberVariables
	public string[]		m_Parameters;
	public float 		m_Value;
	public float		m_ScaryTime;
	#endregion
	#region PrivateMemberVariables
	private MusicManager 				m_MusicManager;
	private AmbientSound 				m_AmbientSound;
	private bool						m_JumpScare = false;
	private float						m_Time;
	private float						m_StartTime;
	private float						m_FoundYouLength = 2.5f;
	#endregion
	

	public void Play()
	{
		m_MusicManager = GameObject.FindObjectOfType<MusicManager>() as MusicManager;
		m_AmbientSound = GameObject.FindObjectOfType<AmbientSound> () as AmbientSound;

		if(Evt != null)
		{
			Evt.setParameterValue(m_Parameters[0], m_Value);
			StartEvent ();
		}
		m_JumpScare = true;
		m_StartTime = Time.time;
	}

	void Start () 
	{
		//m_StartTime = Time.time;
		CacheEventInstance ();
	}

	void Update () 
	{
		var attributes = UnityUtil.to3DAttributes (Camera.main.transform.parent.gameObject);			
		ERRCHECK (Evt.set3DAttributes(attributes));		

		if(m_JumpScare)
		{
			if(getPlaybackState() == PLAYBACK_STATE.SUSTAINING)
			{
				m_AmbientSound.TurnOff ();
				m_MusicManager.TurnOff();
				m_Time = Time.time - (m_StartTime + m_FoundYouLength);

				if(m_Time >= m_ScaryTime)
				{
					this.GetComponent<JumpScare>().TriggerScare();
					m_JumpScare = false;
				}
			}
		}
	}
}
