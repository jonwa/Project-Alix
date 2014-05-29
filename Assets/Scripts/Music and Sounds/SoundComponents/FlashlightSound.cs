using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class FlashlightSound : SoundComponent
{
	#region PrivateMemberVariables
	private GameObject	m_Player;
	private FlashLight	m_Flashlight;
	#endregion

	void Start () 
	{
		CacheEventInstance ();
		m_Player = Camera.main.transform.parent.gameObject;
	}

	void Play()
	{
		if(Camera.main.transform.GetComponentInChildren<FlashLight>().ToggleLight && getPlaybackState() != PLAYBACK_STATE.PLAYING)
		{
			StartEvent();
			Camera.main.transform.GetComponentInChildren<FlashLight>().ToggleLight = false;
		}
	}


	void Update () 
	{
		if (Camera.main.transform.GetComponentInChildren<FlashLight> () != null) 
		{
			Play ();
		}

		var attributes = UnityUtil.to3DAttributes (m_Player);
		ERRCHECK (Evt.set3DAttributes(attributes));	
	}
}
