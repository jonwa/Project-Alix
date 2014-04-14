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
	private bool   m_Occupied 	= false;
	private string m_spritename = null; 
	#endregion

	public int Slot
	{
		get { return m_Slot;  }
		set { m_Slot = value; }
	}

	public bool Occupied
	{
		get { return m_Occupied;  }
		set { m_Occupied = value; }
	}

	void Start()
	{
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
			GetComponentInChildren<UISprite>().spriteName = item;
			GetComponent<UIButton>().normalSprite 		  = item; 
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
		if(m_Occupied)
		{
			InventoryData.RemoveItem(m_Slot);
			m_Occupied = false;
			Replace(null);
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
