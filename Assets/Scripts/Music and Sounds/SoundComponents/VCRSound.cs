using UnityEngine;
using System.Collections;

/* Discription: VCRSound
 * Not working
 * 
 * Created by: Sebastian Olsson: 06-05-2014
 * Modified by: 
 */

[RequireComponent(typeof(SoundEffect))]
public class VCRSound : SoundComponent 
{
	#region PrivateMemberVariables
	private FMOD.Studio.ParameterInstance	m_ActionParameter;
	private SoundEffect m_SoundEffect;
	#endregion
		
	#region PublicMemberVariables
	public string			m_Input = "Fire1";
	public string[]			m_Parameters;
	#endregion
		
	void Start()
	{
		CacheEventInstance();
		//Evt.getParameter(m_Parameters[0], out m_ActionParameter);

		m_SoundEffect = gameObject.GetComponent<SoundEffect> ();
	}
		
	public override void PlaySound()
	{

		StartEvent ();
	}


}