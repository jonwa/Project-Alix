using UnityEngine;
using System.Collections;

///* Discription: Music Options
// * Used for changing the volume of the sound
// * 
// * Created by: Sebastian Olsson 15/04-14
// * Modified by:
// */
//
//public class MusicOptions : MonoBehaviour 
//{
//	[Range(0,10)]
//	public float m_Volume 			= 1.0f;
//
//	private FMOD.Studio.MixerStrip masterBus;
//
//	void Start () 
//	{
//		FMOD.GUID guid;
//		FMOD.Studio.System system = FMOD_StudioSystem.instance.System;
//		ERRCHECK( system.lookupID("bus:/", out guid) );
//		ERRCHECK( system.getMixerStrip(guid, FMOD.Studio.LOADING_MODE.BEGIN_NOW, out masterBus) );
//	}
//
//	void Update () 
//	{
//		ERRCHECK (masterBus.setFaderLevel (m_Volume));
//	}
//
//	FMOD.RESULT ERRCHECK(FMOD.RESULT result)
//	{
//		FMOD.Studio.UnityUtil.ERRCHECK(result);
//		return result;
//	}
//}
