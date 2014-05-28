using UnityEngine;
using System.Collections;

/* Discription: Music Trigger
 * Used for changing values when entering a trigger
 * 
 * Created by: Sebastian Olsson 06-05-14
 * Modified by: Sebastian: 21-05-14: Removed bad code
 * 				Seabstian: 28-05-14: Added function to have a sound play just once
 */

[RequireComponent(typeof(BoxCollider))]
public class MusicTrigger : TriggerComponent 
{
	#region PrivateMemberVariables
	private bool						m_Entered 		= false;
	private MusicManager 				m_MusicManager;
	private FMOD.Studio.EventInstance 	m_Event;
	private string						m_PlayerName;
	private int							m_TimesEntered = 0;
	#endregion
	#region PublicMemberVariables
	[Range(0,1)]public float			m_Value;
	public string						m_Parameter;
	public bool							m_IsTrigger;
	#endregion

	override public string Name
	{
		get{return"TriggerMusic";}
	}

	void TriggerMusic()
	{
		if(m_IsTrigger)
		{
			ChangeValue (m_Parameter, m_Value);
		}
	}

	void Start () 
	{
		collider.isTrigger = true;
		m_PlayerName = Camera.main.transform.parent.gameObject.name;
		m_MusicManager = GameObject.FindObjectOfType<MusicManager>() as MusicManager;
		m_Event = m_MusicManager.GetEvent;
	}

	void MusicParameter()
	{
		ChangeValue (m_Parameter, m_Value);
	}

	void OnTriggerEnter(Collider collider)
	{
		if(!m_IsTrigger)
		{
			if (collider.gameObject.name == m_PlayerName ) 
			{
				if(!m_Entered)
				{
					ChangeValue(m_Parameter, m_Value);
					m_Entered = true;
				}
			}
		}
	}

	void ChangeValue(string p_Parameter, float p_Value)
	{
		m_MusicManager.SetParameterValue(p_Parameter, p_Value);
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
