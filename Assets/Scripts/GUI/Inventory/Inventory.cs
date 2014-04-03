using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour 
{
	#region publicMemberVariables
	public UIButton m_Slot 			= null;
	public UISprite m_Window 		= null;
	public int 		m_NumberSlots 	= 10;
	public int 		m_NumberRows	= 1;
	#endregion

	#region privateMemberVariables
	private BetterList<UIButton> m_Buttons = new BetterList<UIButton>();
	#endregion
	
	void Start () {

	}
}
