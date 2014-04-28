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
	public int 		  m_Width		  = 40; 
	public int 		  m_Height	      = 40; 
	public int 		  m_MaxRows		  = 0;
	public int 		  m_MaxColumns	  = 0; 
	public float 	  m_Spacing		  = 0f; 
	public float 	  m_Padding		  = 0f; 
	#endregion 

	void Start () 
	{
		if(m_Input == null)	     return;
		if(m_Template == null)   return;

		InitializeInventory();
	}

	// sets up the inventory with as many items
	// as maxItemSlot. the background can be seen
	// if it contains a UISprite. 
	void InitializeInventory()
	{
		int    count = 0; 
		Bounds bound = new Bounds();

		BackgroundSettings();
		for(int y = 0; y < m_MaxRows; ++y)
		{
			for(int x = 0; x < m_MaxColumns; ++x)
			{
				GameObject go = NGUITools.AddChild(gameObject, m_Template);

				UISprite sprite = go.GetComponent<UISprite> () as UISprite;

				int width  = sprite.width;
				int height = sprite.height; 
				go.transform.localPosition = new Vector3 ( width * (x + 0.5f) * m_Spacing, -(height * ( y + 0.5f ) * m_Padding), 0f);

				InventoryItem slot = go.GetComponent<InventoryItem>();

				if(slot != null)
				{
					slot.Slot = count;
				}

				++count; 

				InventoryData.AddSlot(go);
			}
		}
	}

	void BackgroundSettings()
	{
		UISprite sprite = gameObject.GetComponent<UISprite> () as UISprite;
		
		#region Sprite size
		// width and height of sprite
		int width  = sprite.width;
		int height = sprite.height; 
		
		// width and height of the buttons
		int theWidth  = (int)(m_MaxColumns * m_Width  * m_Spacing); 
		int theHeight = (int)(m_MaxRows    * m_Height * m_Padding); 

		// set the sprite size depending on theWidth and theHeight
		if(theWidth > width || theHeight > height)
		{
			sprite.width  = theWidth;
			sprite.height = theHeight;
		}
		#endregion
	}
}
