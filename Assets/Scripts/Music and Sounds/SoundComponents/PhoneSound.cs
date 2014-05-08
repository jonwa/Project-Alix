using UnityEngine;
using System.Collections;
using FMOD.Studio;

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
	private float 							m_Action;
	private GameObject						m_GameObject;
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
			m_Action = 0.05f;
			Evt.setParameterValue(m_Parameters[0], m_Action);
			StartEvent();
		}
		else
		{
			m_Action = 0f;
			Evt.setParameterValue(m_Parameters[0], m_Action);
			StartEvent();
		}
		m_GameObject = this.gameObject;
	}

	public override void PlaySound()
	{

		if(!m_Answered && Input.GetButtonDown(m_Input))
		{
			Debug.Log ("SVARA DÅ");
			m_Action = 0.15f;
			Evt.setParameterValue(m_Parameters[0], m_Action);
			Camera.main.SendMessage("Release");
			m_Answered = true;
		}
		else if(m_Answered && Input.GetButtonDown(m_Input))
		{
			Debug.Log ("LÄGG PÅ");
			m_Action = 0.25f;
			Evt.setParameterValue(m_Parameters[0], m_Action);
			Camera.main.SendMessage("Release");
			m_Answered = false;
		}

	}

	void Update () 
	{		

		var attributes = UnityUtil.to3DAttributes (m_GameObject);
		ERRCHECK (Evt.set3DAttributes(attributes));			

		if(getPlaybackState() == FMOD.Studio.PLAYBACK_STATE.SUSTAINING)
		{
			m_Action = 0.0f;
			Evt.setParameterValue(m_Parameters[0], m_Action);
			StartEvent();
		}
	}
}
