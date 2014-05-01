using UnityEngine;
using System.Collections;

/* Discription: Music Options
 * Used for changing the volume of the sound
 * 
 * Created by: Sebastian Olsson 15/04-14
 * Modified by:
 */

public class MusicOptions : MonoBehaviour 
{
	#region PublicVariableMembers
	[Range(0,1)] public float m_MasterVolume 	= 1.0f;
	[Range(0,1)] public float m_SoundVolume		= 1.0f;
	#endregion

	private FMOD.Studio.MixerStrip masterBus;
	private FMOD.Studio.MixerStrip soundBus;

	void Start () 
	{
		FMOD.GUID masterGuid;
		FMOD.Studio.System masterSystem = FMOD_StudioSystem.instance.System;
		ERRCHECK( masterSystem.lookupID("bus:/", out masterGuid) );
		ERRCHECK( masterSystem.getMixerStrip(masterGuid, FMOD.Studio.LOADING_MODE.BEGIN_NOW, out masterBus) );

		FMOD.GUID soundGuid;
		FMOD.Studio.System soundSystem = FMOD_StudioSystem.instance.System;
		ERRCHECK (soundSystem.lookupID ("bus:/", out soundGuid));
		ERRCHECK (soundSystem.getMixerStrip (soundGuid, FMOD.Studio.LOADING_MODE.BEGIN_NOW, out soundBus));		
	}

	void Update () 
	{
		ERRCHECK(masterBus.setFaderLevel(m_MasterVolume));
		//Debug.Log (soundBus);
		//ERRCHECK(soundBus.setFaderLevel(m_SoundVolume)); Hitta rätt namn till den
	}

	FMOD.RESULT ERRCHECK(FMOD.RESULT result)
	{
		FMOD.Studio.UnityUtil.ERRCHECK(result);
		return result;
	}
}
