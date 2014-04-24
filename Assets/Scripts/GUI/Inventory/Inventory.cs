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
				GameObject go   		   = NGUITools.AddChild(gameObject, m_Template);



				go.transform.localPosition = new Vector3(
						m_Padding  + (x + 0.5f) * m_Spacing,
						m_Padding  + (x + 0.5f) * m_Spacing,
						0f);

				ButtonSettings(go, (x) * m_Spacing, (y) * m_Spacing);

				
				/*

				InventoryItem slot = go.GetComponent<InventoryItem>();

				if(slot != null)
				{
					slot.Slot = count;
				}

				++count; 

				InventoryData.AddSlot(go);*/
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
		int theWidth  = m_MaxColumns * m_Spacing; 
		int theHeight = m_MaxRows 	 * m_Padding; 

		// set the sprite size depending on theWidth and theHeight
		if(theWidth > width || theHeight > height)
		{
			sprite.width  = theWidth + 20;
			sprite.height = theHeight + 20;
		}
		#endregion

		#region Anchor calculation (this)
		sprite.bottomAnchor.target   = transform;
		sprite.topAnchor.target 	 = transform;
		sprite.rightAnchor.target    = transform;
		sprite.leftAnchor.target     = transform;

		sprite.bottomAnchor.absolute = 15;
		sprite.rightAnchor.absolute  = -8;

		int topAbs  = sprite.bottomAnchor.absolute + sprite.height;
		int leftAbs = sprite.rightAnchor.absolute  - sprite.width;

		sprite.topAnchor.absolute  = topAbs;
		sprite.leftAnchor.absolute = leftAbs;
		#endregion
	}

	void ButtonSettings(GameObject go, int offsetX, int offsetY)
	{
		UISprite sprite = go.GetComponent<UISprite>() as UISprite;

		sprite.width  = 40; 
		sprite.height = 40; 

		Debug.Log("Sprite width: " + sprite.width);
		Debug.Log("Sprite height: " + sprite.height);

		Debug.Log("offsetY: " + offsetY);
		Debug.Log("offsetX: " + offsetX);

		sprite.topAnchor.target 	 = transform;
		sprite.bottomAnchor.target	 = transform;
		sprite.leftAnchor.target     = transform;
		sprite.rightAnchor.target    = transform;

		sprite.UpdateAnchors();

		sprite.topAnchor.absolute    = -10;
		sprite.leftAnchor.absolute   = 10;
		sprite.bottomAnchor.absolute = 10;
		sprite.rightAnchor.absolute  = -10;

	}
}
