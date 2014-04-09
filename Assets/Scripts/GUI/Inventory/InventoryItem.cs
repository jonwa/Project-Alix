using UnityEngine;
using System.Collections;

/*
 * 
 * Created By: Jon Wahlstöm 2014-04-08
 * Modified By: 
 */

public class InventoryItem : MonoBehaviour 
{
	public Inventory m_Inventory;
	public int 	     m_Slot; 

	void Start()
	{
		GetComponentInChildren<UILabel>().text = (m_Slot + 1).ToString();
	}

	void Replace(string item)
	{

	}
	
	void OnClick()
	{

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
