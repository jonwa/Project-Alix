using UnityEngine;
using System.Collections;
using FMOD.Studio;


public class JumpScare : SoundComponent
{
	#region PrivateMemberVariables

	#endregion
	#region PublicMemberVariables

	#endregion

	public void TriggerScare()
	{
		StartEvent ();
	}

	void Start () 
	{
		CacheEventInstance ();
	}
}
