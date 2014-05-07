using UnityEngine;
using System.Collections;

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
	private SoundEffect m_SoundEffect;
	#endregion
		
	#region PublicMemberVariables
	public string			m_Input = "Fire1";
	public string[]			m_Parameters;
	public int				m_TapeID;
	#endregion
		
	void Start()
	{
		CacheEventInstance();
		Evt.getParameter(m_Parameters[0], out m_ActionParameter);
	}
		
	public override void PlaySound()
	{
		if(Input.GetButton(m_Input))
		{
			StartEvent ();
		}

	}


}