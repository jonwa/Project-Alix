using UnityEngine;
using System.Collections;

/* Discription: Push Component
 * Used to push/pull door or drawers, open them Amnesia style
 * 
 * Created by: Sebastian Olsson 2014-04-04
 * Modified by:
 */

public class Pushable : ObjectComponent 
{
	#region PrivateMemberVariables
	private float m_MouseXPosition;
	private float m_MouseYPosition;
	private Vector3 m_Delta						= Vector3.zero;
	private float m_DeActivateCounter			= 5;
	private GameObject m_Player;
	#endregion
	
	#region PublicMemberVariables
	public string m_HorizontalInput;
	public string m_VerticalInput;
	public string m_Input;
	public string m_PlayerName					= "Player Controller Example";
	#endregion


	void Start () 
	{
		m_Player = GameObject.Find (m_PlayerName); 
	}

	void Update () 
	{
	
	}

	public override void Interact()
	{
		if (GetIsActive()) 
		{
			m_MouseXPosition = Input.GetAxis(m_HorizontalInput);
			m_MouseYPosition = Input.GetAxis(m_VerticalInput);

			rigidbody.AddForce(1,2,3);

			m_Delta = new Vector3(m_MouseXPosition, 0 , m_MouseYPosition);
			Debug.Log ("Forward 4= " + m_Player.transform.forward);
			transform.position += m_Delta;
		}
		if(Input.GetButton(m_Input))
		{
			Activate();
			m_DeActivateCounter = 0;
		}
		else
		{
			DeActivate();
		}
	}
}