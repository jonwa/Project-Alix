using UnityEngine;
using System.Collections;

/*
 * 
 * Created By: Jon Wahlström 2014-04-04
 * Modified By: 
 */

public class SaveLoadHandler : MonoBehaviour 
{
	#region PublicMemberVariables
	public UIButton m_Slot 	      = null; 
	public int		m_NumberSlots = 3;
	#endregion
	
	#region PrivateMemberVariables
	private int m_ButtonPositionX = 0;
	private int m_ButtonPositionY = 0; 
	#endregion

	// Add functionallity to overload the button name

	void Start()
	{
		InitializeSlots ();
	}
	
	void InitializeSlots()
	{
		int j = 1; 
		for(int i = 0; i < m_NumberSlots; ++i)
		{
			GameObject button 	           				  = Instantiate(m_Slot.gameObject) as GameObject; 
			button.transform.parent        				  = transform; 
			m_ButtonPositionY 						      += m_Slot.GetComponent<UISprite>().height;
			
			button.transform.localPosition 				  = new Vector3(m_ButtonPositionX, j * m_ButtonPositionY + 5f, 0f);
			button.transform.localScale    				  = new Vector3(1f, 1f, 1f);

			// Get name from JSON file if game is saved!
			button.GetComponentInChildren<UILabel>().text = "Empty Load Slot";
		}
	}
}