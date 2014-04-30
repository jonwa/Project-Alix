using UnityEngine;
using System.Collections;

/*
 * 
 * Created By: Jon Wahlstöm 2014-04-08
 * Modified By: 
 */

public class InventoryItem : MonoBehaviour 
{
	#region PrivateMemberVariables
	private int    m_Slot 		= 0; 
	private string m_spritename = null; 
	#endregion

	public int Slot
	{
		get { return m_Slot;  }
		set { m_Slot = value; }
	}

	public bool Occupied{get;set;}

	void Start()
	{
		Occupied = false;
		GetComponentInChildren<UILabel>().enabled = false;
	}

	public void Replace(string item)
	{
		if(item == null)
		{
			GetComponentInChildren<UISprite>().spriteName = "Default";
			GetComponent<UIButton>().normalSprite 		  = "Default";
			m_spritename 								  = null; 
		}
		else
		{
			m_spritename = item;
			ChangeTexture();
		}
	}

	public void DelayedReplace(string item)
	{
		m_spritename = item;
	}

	public void ChangeTexture()
	{
		if(m_spritename != null) 
		{
			GetComponentInChildren<UISprite>().spriteName = m_spritename;
			GetComponent<UIButton>().normalSprite 		  = m_spritename; 
		}
	}

	void OnClick()
	{
		if(Occupied)
		{
			Occupied = false;
			Replace(null);
			InventoryData.RemoveItem(Slot);


			// Shuts down the inventory window
			InputManager.Active = true;
			InventoryData.Toggle = true;
			transform.parent.GetComponent<UIPlayTween>().Play (true);
			InputManager.Reset();
		}
		else
		{
			InventoryData.NonOccupid();
		}
	}

	void OnDrag(Vector2 delta)
	{

	}

	void OnDrop(GameObject go)
	{

	}

	void UpdateCursor()
	{

	}
}
