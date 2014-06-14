using UnityEngine;
using System.Collections;

/* Discription: Music Trigger
 * Used for changing values when entering a trigger
 * 
 * Created by: Sebastian Olsson 06-05-14
<<<<<<< HEAD
 * Modified by:
=======
 * Modified by: Sebastian: 21-05-14: Removed bad code
 * 				Seabstian: 28-05-14: Added function to have a sound play just once
>>>>>>> 92beaf40a036c549a2d3df76d99f75233488c66d
 */
[RequireComponent(typeof(BoxCollider))]
public class MusicTrigger : TriggerComponent 
{
	#region PrivateMemberVariables
	private bool						m_Entered 		= false;
	private MusicManager 				m_MusicManager;
<<<<<<< HEAD

	public string						m_PlayerName	= "Player Controller Example";
=======
	private FMOD.Studio.EventInstance 	m_Event;
	private string						m_PlayerName;
	private int							m_TimesEntered = 0;
	#endregion
	#region PublicMemberVariables
>>>>>>> 92beaf40a036c549a2d3df76d99f75233488c66d
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
		m_MusicManager = GameObject.FindObjectOfType<MusicManager>() as MusicManager;
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

	void ChangeValue(string Parameter, float p_Value)
	{
		if(Parameter == "Location")
		{
			m_MusicManager.Element0 = p_Value;
		}
		else if(Parameter == "Progress")
		{
			m_MusicManager.Element1 = p_Value;
		}
		else if(Parameter == "Pause and Death")
		{
			m_MusicManager.Element2 = p_Value;
		}
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
