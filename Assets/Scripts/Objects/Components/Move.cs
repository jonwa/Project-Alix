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
	public string m_PlayerName					= "Player Controller Example";
	public string m_Input;
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
		if (GetIsActive()) 
		{
			m_CurrentPlayerPosition = m_Player.transform.position;
			m_Offset = m_CurrentPlayerPosition - m_OriginalPlayerPosition;
			transform.position += m_Offset;
			m_OriginalPlayerPosition = m_CurrentPlayerPosition;
		}
		if(Input.GetButton(m_Input))
		{
			if(!GetIsActive())
			{
				m_OriginalPlayerPosition = m_Player.transform.position;
			}
			Activate();
			m_DeActivateCounter = 0;
		}
		else
		{
			DeActivate();
		}
	}
}