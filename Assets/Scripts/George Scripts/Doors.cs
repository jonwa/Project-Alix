using UnityEngine;
using System.Collections;

/* Discription: Generic Door Script
 * Adds needed script components for simple doors
 * 
 * Created by: George Barota 2014-05-14
 * Modified by:
 */

public class Doors : MonoBehaviour
{
	#region PublicMemberVariables
	public float m_RotSpeed;
	public string m_RotAxis;
	public float m_RotFwdLim;
	public float m_RotBckLim;
	public float m_RotLockLim;
	public Texture m_HovEffect;
	public Texture m_ClickHovEffect;
	public string m_DescrStr;
	#endregion

	void Start()
	{
		NewDoorDrag();
		NewRotationLimit();
		NewHover();
	}


	private void NewDoorDrag()
	{
		DoorDrag newDoorDrag = (DoorDrag)gameObject.AddComponent("DoorDrag");

		newDoorDrag.m_Input = "Fire1";
		newDoorDrag.m_VerticalInput = "Mouse Y";
		newDoorDrag.m_Speed = m_RotSpeed;
	}

	private void NewRotationLimit()
	{
		RotationLimit newRotationLimit = (RotationLimit)gameObject.AddComponent("RotationLimit");

		newRotationLimit.m_LockedLimit = m_RotLockLim;

		switch(m_RotAxis)
		{
		case "X":
			newRotationLimit.m_NegativeX = m_RotFwdLim;
			newRotationLimit.m_PositiveX = m_RotBckLim;
			break;
		case "Y":
			newRotationLimit.m_NegativeY = m_RotFwdLim;
			newRotationLimit.m_PositiveY = m_RotBckLim;
			break;
		case "Z":
			newRotationLimit.m_NegativeZ = m_RotFwdLim;
			newRotationLimit.m_PositiveZ = m_RotBckLim;
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
