using UnityEngine;
using System.Collections;

/* Discription: Generic Drawer Script
 * Adds needed script components for most drawers
 * 
 * Created by: George Barota 2014-05-14
 * Modified by:
 */

public class Drawers : MonoBehaviour
{
	#region PublicMemberVariables
	public string m_MovDirection;
	public float m_MovLimit;
	public float m_MovSpeed;
	public Texture m_HovEffect;
	public Texture m_ClickHovEffect;
	public string m_DescrStr;
	#endregion
	
	void Start()
	{
		NewPushable();
		NewMovLimit();
		NewHover();
	}


	private void NewPushable()
	{
		Pushable newPushComp = (Pushable)gameObject.AddComponent("Pushable");

		newPushComp.m_Input = "Fire1";
		newPushComp.m_MoveSpeed = m_MovSpeed;
		newPushComp.m_HorizontalInput = "Mouse X";
		newPushComp.m_VerticalInput = "Mouse Y";
	}

	private void NewMovLimit()
	{
		MovementLimit newMovLimitComp = (MovementLimit)gameObject.AddComponent("MovementLimit");

		switch(m_MovDirection)
		{
		case "X":
			if(m_MovLimit < 0f)
			{
				newMovLimitComp.m_NegativeX = Mathf.Abs(m_MovLimit);
			}
			else
			{
				newMovLimitComp.m_PositiveX = m_MovLimit;
			}
			break;

		case "Y":
			if(m_MovLimit < 0f)
			{
				newMovLimitComp.m_NegativeY = Mathf.Abs(m_MovLimit);
			}
			else
			{
				newMovLimitComp.m_PositiveY = m_MovLimit;
			}
			break;

		case "Z":
			if(m_MovLimit < 0f)
			{
				newMovLimitComp.m_NegativeZ = Mathf.Abs(m_MovLimit);
			}
			else
			{
				newMovLimitComp.m_PositiveZ = m_MovLimit;
			}
			break;
		}
	}

	private void NewHover()
	{
		HoverEffect newHoverComp = (HoverEffect)gameObject.AddComponent("HoverEffect");

		newHoverComp.m_HoverEffect = m_HovEffect;
		newHoverComp.m_ButtonDownHoverEffect = m_ClickHovEffect;
		newHoverComp.m_Description = m_DescrStr;
	}
}
