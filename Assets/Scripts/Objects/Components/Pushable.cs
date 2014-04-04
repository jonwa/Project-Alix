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
	private Vector3 m_OriginalMousePosition;
	private Vector3 m_CurrentMousePosition;
	private Vector3 m_Offset;
	private float m_DeActivateCounter			= 5;
	private Vector3 m_Change;
	#endregion
	
	#region PublicMemberVariables
	public string m_Input;
	public float m_Sensitivity					= 2;
	#endregion


	void Start () 
	{
		m_OriginalMousePosition = Input.mousePosition;
	}

	void Update () 
	{
	
	}

	public override void Interact()
	{
		if (GetIsActive()) 
		{

			m_Change = new Vector3(0, 0, Input.GetAxis("Mouse Y"));
			transform.position += m_Change;
		}
		if(Input.GetButton(m_Input))
		{
			if(!GetIsActive())
			{
				m_OriginalMousePosition = Input.mousePosition;
			}
			Activate();
			m_DeActivateCounter = 0;
		}
		else
		{
			DeActivate();
		}
	}

	public void FacingDirection()
	{
		//TODO Write function that knows what direction player is facing for m_Change

	}
}