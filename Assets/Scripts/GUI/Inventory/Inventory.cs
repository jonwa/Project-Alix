using UnityEngine;
using System.Collections.Generic;

/* Initializes an inventory containing 5 items by default. 
 * 
 * Created By: Jon Wahlström 2014-04-08
 * Modified By: 
 */

public class Inventory : MonoBehaviour 
{
	#region PublicMemberVariables
	public GameObject m_Template	  = null; 
	public GameObject m_Input		  = null; 
	public UIWidget	  m_Background    = null; 

	public int 		  m_MaxItemSlots  = 0;
	public int 		  m_MaxRows		  = 0;
	public int 		  m_MaxColumns	  = 0; 
	public int 		  m_Spacing		  = 0; 
	public int 		  m_Padding		  = 0; 
	#endregion 

	void Start () 
	{
		if(m_Input == null)	     return;
		if(m_Template == null)   return;
		if(m_Background == null) return;

		InitializeInventory();
	}

	// sets up the inventory with as many items
	// as maxItemSlot. the background can be seen
	// if it contains a UISprite. 
	// NOTE: the background position may not always be correct
	//       it can be fixed in the inspect of the sprite itself. 
	void InitializeInventory()
	{
		int    count = 0; 
		Bounds bound = new Bounds();

		//init background and input management
		//input is used to toggle between visibility
		GameObject background = NGUITools.AddChild(gameObject, m_Background.gameObject);
		GameObject input  	  = NGUITools.AddChild(gameObject, m_Input);
		input.GetComponent<InventoryInput>().InventoryWindow = background;

		for(int y = 0; y < m_MaxRows; ++y)
		{
			for(int x = 0; x < m_MaxColumns; ++x)
			{
				GameObject go   		   = NGUITools.AddChild(background, m_Template);
				go.transform.localPosition = new Vector3(
					m_Padding  + (x + 0.5f) * m_Spacing,
					-m_Padding - (y + 0.5f) * m_Spacing,
					0f);

				bound.Encapsulate(new Vector3(
					m_Padding  * 2f + (x + 1) * m_Spacing,
					-m_Padding * 2f - (y + 1) * m_Spacing, 
					0f));

				InventoryItem slot = go.GetComponent<InventoryItem>();

				if(slot != null)
				{
					slot.Slot = count;
				}

				++count; 
				if(count >= m_MaxItemSlots)
				{
					if(m_Background != null) 
					{
						background.transform.localPosition = new Vector3(-150f, -160f, 0f);
						background.transform.localScale    = bound.size;
					}
					return;
				}

				InventoryData.AddSlot(go);
			}
		}

		if(m_Background != null) 
		{
			background.transform.localPosition = new Vector3(180f, -160f, 0f);
			background.transform.localScale    = bound.size;
		}
	}
}
