using UnityEngine;
using System.Collections;

/* Discription: Music Trigger
 * Used for changing values when entering a trigger
 * 
 * Created by: Sebastian Olsson 06-05-14
 * Modified by:
 */
[RequireComponent(typeof(BoxCollider))]
public class MusicTrigger : MonoBehaviour 
{

	private bool						m_Entered 		= false;
	private MusicManager 				m_MusicManager;

	public string						m_PlayerName	= "Player Controller Example";
	[Range(0,1)]public float			m_Value;
	public string						m_Parameter;

	void Start () 
	{
		collider.isTrigger = true;
		m_MusicManager = GameObject.FindObjectOfType<MusicManager>() as MusicManager;
	}

	//Need to change when layout is known and how the music track looks
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == m_PlayerName) 
		{
			if(!m_Entered)
			{
				ChangeValue(m_Parameter, m_Value);
				m_Entered = true;
			}
		}
		m_Entered = false;
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
}
