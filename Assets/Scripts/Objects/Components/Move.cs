using UnityEngine;
using System.Collections;

/* Discription: Move Component
 * Used for moving boxes or different ojects in the gameworld
 * 
 * Created by: Sebastian Olsson 04/04-14
 * Modified by:
 */

public class Move : ObjectComponent 
{
	#region PrivateMemberVariables
	private Vector3 m_OriginalPlayerPosition;
	private Vector3 m_CurrentPlayerPosition;
	private Vector3 m_Offset;
	private GameObject m_Player;
	private float m_DeActivateCounter 			= 5;
	#endregion

	#region PublicMemberVariables
	public string	m_PlayerName				= "Player Controller Example";
	public string	m_Input;
	public float	m_DistanceToObject;
	#endregion

	void Start()
	{
		//Change "Player Controller Example" to whatever Player is called when finished
		m_Player = GameObject.Find (m_PlayerName); 
		m_OriginalPlayerPosition = m_Player.transform.position;
	}

	void Update()
	{
		m_DeActivateCounter++;
		if(m_DeActivateCounter > 10)
		{
			DeActivate();
		}
	}
	
	//Function for moving objects, moves the object with the player
	public override void Interact()
	{
		if (IsActive) 
		{
			m_CurrentPlayerPosition = m_Player.transform.position;
			m_Offset = m_CurrentPlayerPosition - m_OriginalPlayerPosition;

			if((m_Player.transform.position.magnitude - transform.position.magnitude) < m_DistanceToObject ||
			   (m_Player.transform.position.magnitude - transform.position.magnitude) > -m_DistanceToObject)
			{
				transform.position += m_Offset;
			}
			else
			{

			}
			//Debug.Log ("Distance to Object = "+m_DistanceToObject);
			Debug.Log ("mPlayer= "+ (m_Player.transform.position.magnitude - transform.position.magnitude));

			m_OriginalPlayerPosition = m_CurrentPlayerPosition;
		}
	

		if(!IsActive)
		{
			m_OriginalPlayerPosition = m_Player.transform.position;

			m_OriginalPlayerPosition = m_Player.transform.position;

			Activate();
			m_DeActivateCounter = 0;
		}
		else
		{
			DeActivate();
		}
	}
}