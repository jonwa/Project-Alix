using UnityEngine;
using System.Collections;
using FMOD.Studio;

/* Discription: DoorSound
 * Play sound when interacting with doors
 * 
 * Created by: Sebastian Olsson 05/05-14
 * Modified by:
 */
public class DoorSound : SoundComponent 
{
	#region PrivateMemberVariables
	private bool			m_Open;
	private bool			m_Closed;
	private float			m_StartRotation;
	private float			m_Rotation;
	private bool			m_Locked;
	private float			m_MouseMovement;
	private float			m_Action;
	private GameObject		m_GameObject;
	private int 			m_StartIterator 	= 0;
	private string			m_Input				= "Fire1";
	#endregion
	
	#region PublicMemberVariables
	[Range(0,5f)]public float m_Margin = 2f;
	public string[]			m_Parameters;
	#endregion

	void Start()
	{
		m_GameObject = this.gameObject;
		CacheEventInstance();
		m_StartRotation = this.transform.eulerAngles.y;
		m_Action = 1;
		Evt.setParameterValue(m_Parameters[0], m_Action);
		StartEvent ();
	}
	
	public override void PlaySound()
	{
		m_Locked = GetComponent<Locked> ().GetLocked ();
		m_MouseMovement = Input.GetAxis ("Mouse Y");
		m_Rotation = this.transform.eulerAngles.y;
		//Debug.Log (getPlaybackState ());

		if(!m_Locked)
		{
			//Debug.Log (getPlaybackState());
			if(m_MouseMovement != 0)
			{
				if(getPlaybackState() == FMOD.Studio.PLAYBACK_STATE.PLAYING)
				{
					if(!m_Open && (m_Rotation > (m_Margin + m_StartRotation)))
					{
						m_Action = 0.05f;
						m_Open = true;
						Evt.setParameterValue(m_Parameters[0], m_Action);
						StartEvent();
					}
					else if(m_Open &&(m_Rotation <= (m_StartRotation + m_Margin)))
					{
						m_Action = 0.15f;
						m_Open = false;
						Evt.setParameterValue(m_Parameters[0], m_Action);
						StartEvent();
					}
				}

			}
			if(getPlaybackState() == FMOD.Studio.PLAYBACK_STATE.SUSTAINING)
			{
				m_Action = 1f;
				Evt.setParameterValue(m_Parameters[0], m_Action);
				Evt.stop();
			}
			if(getPlaybackState() == FMOD.Studio.PLAYBACK_STATE.STOPPED)
			{
				StartEvent();
			}

		}
		else if(m_Locked && Input.GetButtonDown(m_Input))
		{
			m_Action = 0.35f;
			Evt.setParameterValue(m_Parameters[0], m_Action);
			StartEvent();
		}
	}

	void Update()
	{
		var attributes = UnityUtil.to3DAttributes (m_GameObject);
		ERRCHECK (Evt.set3DAttributes(attributes));			
	}
}