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
	private bool							m_Ringing = false;
	private float 							m_Action;
	private GameObject						m_GameObject;
	#endregion
	
	#region PublicMemberVariables
	public string[]			m_Parameters;
	public string			m_Input = "Fire1";
	#endregion

	public FMODAsset Asset
	{
		get{ return m_Asset; }
	}

	public bool Ringing
	{
		get{return m_Ringing;}
		set{m_Ringing = value;}
	}

	public bool Answered
	{
		get{return m_Answered;}
		set{m_Answered = value;}
	}

	public void Play()
	{
		if(Evt != null)
		{
			Debug.Log("RINGRING");
			CacheEventInstance();
			StartEvent ();
		}
	}

	void Start () 
	{
		CacheEventInstance();
		if(m_StartOnAwake)
		{
			m_Ringing = true;
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
		if(m_Ringing)
		{
			if(!m_Answered && Input.GetButtonDown(m_Input))
			{
				m_Action = 0.15f;
				Evt.setParameterValue(m_Parameters[0], m_Action);
				Camera.main.SendMessage("Release");
				m_Answered = true;
			}
			else if(m_Answered && Input.GetButtonDown(m_Input))
			{
				m_Action = 0.25f;
				Evt.setParameterValue(m_Parameters[0], m_Action);
				Camera.main.SendMessage("Release");
				m_Answered = false;
				m_Ringing = false;
			}
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
