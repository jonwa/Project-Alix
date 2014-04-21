using UnityEngine;
using System.Collections;

/* Discription: Music Trigger
 * Used for changing values when entering a trigger
 * 
 * Created by: Sebastian Olsson 17/04-14
 * Modified by:
 */
[RequireComponent(typeof(BoxCollider))]
public class MusicTrigger : MonoBehaviour 
{

	private bool						m_Entered 		= false;
	private MusicManager 					m_MusicManager;

	public string						m_PlayerName	= "Player Controller Example";
	[Range(0,1)]public float			m_Value;

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
				m_MusicManager.Element0 = m_Value;
				m_Entered = true;
			}
		}
		m_Entered = false;
	}

	//Changes the value of the parameter so the music can change after entering the trigger NOT USED ATM
	float ChangeValue(float p_Value)
	{
		if (p_Value == 0) 
		{
			p_Value = 1;
		}
		else if(p_Value == 1)
		{
			p_Value = 0;
		}
		return p_Value;
	}
}
