using UnityEngine;
using System.Collections;

/* A security camera follows the players movement. 
 * It follows the players movement which gives the 
 * illusion that someone is watching the player
 * 
 * NOTE: 
 * 	- Needs a rotation limit!!!
 * 
 * Created By: Jon Wahlström 2014-04-21
 * Modified By: 
 */

public class SecurityCamera : MonoBehaviour 
{
	#region PublicMemberVariables
	public string m_PlayerName = null; 
	#endregion

	#region PrivateMemberVariables
	private GameObject m_Player = null; 
	#endregion

	void Start()
	{
		if(m_PlayerName == null) return;

		m_Player = GameObject.Find (m_PlayerName) as GameObject; 

		if (m_Player == null) return; 
	}
	
	void FixedUpdate () 
	{
		transform.LookAt (m_Player.transform.position);
	}
}
