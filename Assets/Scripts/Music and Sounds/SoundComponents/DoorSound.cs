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
	private FMOD.Studio.ParameterInstance m_ActionParameter;
	private bool	m_Open;
	private float	m_StartRotation;
	private float	m_Rotation;
	private bool	m_Locked;
	private float	m_MouseMovement;
	private float	m_Action;
	#endregion
	
	#region PublicMemberVariables
	public string[] m_Parameters;
	[Range(0,0.1f)]public float m_Margin = 0.075f;
	#endregion

	void Start()
	{
		m_StartRotation = transform.rotation.y;
		if(m_Parameters != null)
		{
			m_Event.getParameter (m_Parameters[0], out m_ActionParameter);
		}
	}

	public override void PlaySound()
	{
		m_Locked = GetComponent<Locked> ().GetLocked ();
		m_MouseMovement = Input.GetAxis ("Mouse Y");
		m_Rotation = transform.rotation.y;
		if(!m_Locked)
		{
			if(m_MouseMovement != 0)
			{
				Debug.Log (m_Rotation);
				Debug.Log (m_StartRotation);
				if(m_MouseMovement > 0 && !m_Open && m_Rotation < m_Margin)
				{
					m_Action = 0.5f;
					m_Open = true;
					StartEvent();
				}
				else if(m_MouseMovement < 0 && m_Open && (m_StartRotation + m_Margin > m_Rotation))
				{
					m_Action = 0.15f;
					m_Open = false;
					StartEvent();
				}

			}
		}

	}
}