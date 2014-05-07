using UnityEngine;
using System.Collections;

/* Discription: PhoneSound
 * The sound of the phone,
 * 
 * Created by: Sebastian Olsson 07/05-14
 * Modified by:
 */

public class PhoneSound : SoundComponent 
{

	#region PrivateMemberVariables
	private FMOD.Studio.ParameterInstance	m_ActionParameter;
	private bool 							m_Answered = false;
	private float 			m_Action;
	#endregion
	
	#region PublicMemberVariables
	public string[]			m_Parameters;
	public bool				m_StartOnTrigger;
	public string			m_Input = "Fire1";
	#endregion


	void Start () 
	{
		CacheEventInstance();
		if(m_StartOnAwake || m_StartOnTrigger)
		{
			StartEvent();
		}
	}

	public override void PlaySound()
	{
		if(!m_Answered && Input.GetButtonDown(m_Input))
		{
			Debug.Log ("SVARA DÅ");
			m_Action = 0.15f;
			Evt.setParameterValue(m_Parameters[0], m_Action);
			StartEvent();
			Camera.main.SendMessage("Release");
			m_Answered = true;
		}
		else if(m_Answered && Input.GetButtonDown(m_Input))
		{
			Debug.Log ("LÄGG PÅ");
			m_Action = 0.25f;
			Evt.setParameterValue(m_Parameters[0], m_Action);
			StartEvent();
			Camera.main.SendMessage("Release");
			m_Answered = false;
		}
	}

	void Update () 
	{
	
	}
}
