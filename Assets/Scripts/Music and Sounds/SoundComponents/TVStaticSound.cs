using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class TVStaticSound : SoundComponent
{
	#region PrivateMemberVariables
	private GameObject	m_GameObject;
	#endregion
	
	#region PublicMemberVariables

	#endregion

	public override void PlaySound()
	{

	}

	void Start () 
	{
		m_GameObject = this.gameObject;
		CacheEventInstance ();

		if(m_StartOnAwake)
		{
			StartEvent();
		}
	}

	void Update () 
	{
		var attributes = UnityUtil.to3DAttributes (m_GameObject);
		ERRCHECK (Evt.set3DAttributes(attributes));		
	}
}