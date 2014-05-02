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
	[Range(0,1)] public float m_MusicVolume 	= 1.0f;
	[Range(0,1)] public float m_SoundVolume		= 1.0f;
	#endregion

	private FMOD.Studio.MixerStrip masterBus;
	private FMOD.Studio.MixerStrip musicBus;
	private FMOD.Studio.MixerStrip soundBus;

	void Start () 
	{
		FMOD.GUID masterGuid;
		FMOD.Studio.System masterSystem = FMOD_StudioSystem.instance.System;
		ERRCHECK( masterSystem.lookupID("bus:/", out masterGuid) );
		ERRCHECK( masterSystem.getMixerStrip(masterGuid, FMOD.Studio.LOADING_MODE.BEGIN_NOW, out masterBus) );

		FMOD.GUID musicGuid;
		FMOD.Studio.System musicSystem = FMOD_StudioSystem.instance.System;
		ERRCHECK (musicSystem.lookupID ("bus:/Music", out musicGuid));
		ERRCHECK (musicSystem.getMixerStrip (musicGuid, FMOD.Studio.LOADING_MODE.BEGIN_NOW, out musicBus));		
		
		FMOD.GUID soundGuid;
		FMOD.Studio.System soundSystem = FMOD_StudioSystem.instance.System;
		ERRCHECK (soundSystem.lookupID ("bus:/Sound", out soundGuid));
		ERRCHECK (soundSystem.getMixerStrip (soundGuid, FMOD.Studio.LOADING_MODE.BEGIN_NOW, out soundBus));		
	}

	void Update () 
	{
		ERRCHECK(masterBus.setFaderLevel(m_MasterVolume));
		//ERRCHECK (musicBus.setFaderLevel (m_MusicVolume));
		//Debug.Log (soundBus);
		//ERRCHECK(soundBus.setFaderLevel(m_SoundVolume));
	}

	FMOD.RESULT ERRCHECK(FMOD.RESULT result)
	{
		FMOD.Studio.UnityUtil.ERRCHECK(result);
		return result;
	}
}
