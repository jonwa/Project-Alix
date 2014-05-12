using UnityEngine;
using System.Collections;

/* Discription: DoorSound
 * Play sound when interacting with doors
 * 
 * Created by: Sebastian Olsson 05/05-14
 * Modified by:
 */
//TODO: Rotate 90 does not work, still need to add door drag sounds
public class DoorSound : SoundComponent 
{
	#region PrivateMemberVariables
	private bool							m_Open;
	private float							m_StartRotation;
	private float							m_Rotation;
	private bool							m_Locked;
	private float							m_MouseMovement;
	public float							m_Action;
	private int 							m_StartIterator 	= 0;
	private FMOD.Studio.ParameterInstance	m_ActionParameter;
	#endregion
	
	#region PublicMemberVariables
	[Range(0,5f)]public float m_Margin = 2f;
	public string[]			m_Parameters;
	#endregion

	void Start()
	{
		CacheEventInstance();
		Evt.getParameter(m_Parameters[0], out m_ActionParameter);

		m_StartRotation = this.transform.eulerAngles.y;
	}
	
	public override void PlaySound()
	{
		m_Locked = GetComponent<Locked> ().GetLocked ();
		m_MouseMovement = Input.GetAxis ("Mouse Y");
		m_Rotation = this.transform.eulerAngles.y;

		if(!m_Locked)
		{
			//Debug.Log (getPlaybackState());
			if(m_MouseMovement != 0)
			{
				if(m_Open && (m_Rotation < m_StartRotation + m_Margin))
				{
					m_Action = 0.15f;
					m_Open = false;
				}
				if(!m_Open && (m_Rotation > m_Margin + m_StartRotation))
				{
					m_Action = 0.05f;
					m_Open = true;
				}
				m_ActionParameter.setValue(m_Action);
				if(getPlaybackState() != FMOD.Studio.PLAYBACK_STATE.PLAYING)
				{
					StartEvent();
				}
				Debug.Log (getPlaybackState());
			}
		}

	}
}