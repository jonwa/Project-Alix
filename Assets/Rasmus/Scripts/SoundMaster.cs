using UnityEngine;
using System.Collections;

public class SoundMaster : MonoBehaviour 
{
	#region PublicMemberVariables
	public int m_MasterVolume;
	public int m_MusicVolume;
	public int m_SoundEffectVolume;
	public int m_OtherSoundVolume;
	#endregion
	
	#region PrivateMemberVariables
	GameObject[] m_MusicList;
	GameObject[] m_SoundEffects;
	GameObject[] m_OtherSounds;
	private int m_OriginalMasterVolume;
	private int m_OriginalMusicVolume;
	private int m_OriginalSoundEffectVolume;
	private int m_OriginalOtherSoundVolume;
	#endregion

	// Use this for initialization
	void Start () 
	{
		m_OriginalMasterVolume		= m_MasterVolume;
		m_OriginalMusicVolume		= m_MusicVolume;
		m_OriginalSoundEffectVolume	= m_SoundEffectVolume;
     	m_OriginalOtherSoundVolume	= m_OtherSoundVolume;

		m_MusicList    = GameObject.FindGameObjectsWithTag("Music");
		m_SoundEffects = GameObject.FindGameObjectsWithTag("SoundEffect");
		m_OtherSounds  = GameObject.FindGameObjectsWithTag("OtherSound");

		UpdateVolumes();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void SetVolumeMaster(int volume)
	{
		m_MasterVolume=volume;
		UpdateVolumes();
	}
	public void SetVolumeMusic(int volume)
	{
		m_MusicVolume=volume;
		UpdateVolumes();
	}
	public void SetVolumeEffect(int volume)
	{
		m_SoundEffectVolume=volume;
		UpdateVolumes();
	}
	public void SetVolumeOther(int volume)
	{
		m_OtherSoundVolume=volume;
		UpdateVolumes();
	}

	public void SetNewOrignalVolumes(int volumeMaster, int volumeMusic, int volumeEffect, int volumeOther)
	{
		m_OriginalMasterVolume		= volumeMaster;
		m_OriginalMusicVolume		= volumeMusic;
		m_OriginalSoundEffectVolume	= volumeEffect;
		m_OriginalOtherSoundVolume	= volumeOther;
	}

	public void ResetVolumes()
	{
		m_MasterVolume 	    = m_OriginalMasterVolume;
		m_MusicVolume 	    = m_OriginalMusicVolume;
		m_SoundEffectVolume = m_OriginalSoundEffectVolume;
		m_OtherSoundVolume  = m_OriginalOtherSoundVolume;
		UpdateVolumes();
	}

	private void UpdateVolumes()
	{
		for(int i=0; i<m_MusicList.Length; i++)
		{
			m_MusicList[i].audio.volume = (m_MasterVolume/100)*(m_MusicVolume/100);
		}
		for(int i=0; i<m_SoundEffects.Length; i++)
		{
			m_SoundEffects[i].audio.volume = (m_MasterVolume/100)*(m_SoundEffectVolume/100);
		}
		for(int i=0; i<m_OtherSounds.Length; i++)
		{
			m_OtherSounds[i].audio.volume = (m_MasterVolume/100)*(m_OtherSoundVolume/100);
		}
	}
}
