using UnityEngine;
using System.Collections;
using FMOD.Studio;

/* Discription: VCRSound
 * Not working
 * 
 * Created by: Sebastian Olsson: 06-05-2014
 * Modified by: 
 */

public class VCRSound : SoundComponent 
{
	#region PrivateMemberVariables
	private FMOD.Studio.ParameterInstance	m_ActionParameter;
	private GameObject						m_GameObject;
	#endregion
		
	#region PublicMemberVariables
	public string			m_Input = "Fire1";
	public string[]			m_Parameters;
	#endregion

	void Start()
	{
		CacheEventInstance();
		Evt.getParameter(m_Parameters[0], out m_ActionParameter);
		m_GameObject = this.gameObject;

	}
		
	public override void PlaySound()
	{
		StartEvent ();
	}

	void Update()
	{
		var attributes = UnityUtil.to3DAttributes (m_GameObject);
		ERRCHECK (Evt.set3DAttributes(attributes));	
	}


}