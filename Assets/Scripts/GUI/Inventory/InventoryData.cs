using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

/* Keeps all data needed for the inventory
 * pure static class that is used to add/remove items
 * and also serialize/deserialize the data
 * 
 * Created By: Jon Wahlström 2014-04-09
 * Modified By: 
 */

public class InventoryData : MonoBehaviour
{
	#region PublicMemberVariables
	public int 	 m_MaxItems    = 5;
	public string m_PlayerName = null; 
	#endregion

	#region PrivateMemberVariables
	private static List<GameObject>  m_Slots		= new List<GameObject>();
	private static GameObject[] 	 m_Items		= null;
	private static GameObject 		 m_Player 		= null; 
	private static bool 			 m_Toggle		= false; 
	private static int 				 m_MaxItemSlots = 0; 
	#endregion

	void Start ()
	{
		m_MaxItemSlots = m_MaxItems;
		m_Items        = new GameObject[m_MaxItems];
		m_Player       = GameObject.Find(m_PlayerName);
	}

	public static bool Toggle
	{
		get { return m_Toggle;  }
		set { m_Toggle = value; }
	}

	//Initializes the List of empty slots. 
	//called from Inventory.cs
	public static void AddSlot(GameObject slot)
	{
		m_Slots.Add(slot);
	}

	//add a object to the inventory, called from Pocket.cs
	public static void AddItem(GameObject go)
	{
		foreach(GameObject itemSlot in m_Slots)
		{
			InventoryItem slot = itemSlot.GetComponent<InventoryItem>();
			if(!slot.Occupied)
			{
				go.SetActive(false);
			
				slot.Occupied 	   = true;
				m_Items[slot.Slot] = go;

				if(m_Toggle)
				{
					slot.Replace(slot.Slot.ToString());
					// TODO: slot.Replace(go.GetComponent<Name>().Name);
				}
				else
				{
					slot.DelayedReplace(slot.Slot.ToString());
					// TODO: slot.Replace(go.GetComponent<Name>().Name);
				}
				break;
			}
		}
	}

	//Remove a selected object from the inventory
	//called from InventoryItem.cs
	public static void RemoveItem(int item)
	{
		if(item < m_MaxItemSlots)
		{
			GameObject go = m_Items[item];
			m_Items[item] = null;

			go.SetActive(true);
			SetPosition(go);
		}
	}

	//updates the information for each slot in
	//the inventory as it gets active
	public static void UpdateInventory()
	{
		foreach(GameObject item in m_Slots)
		{
			InventoryItem slot = item.GetComponent<InventoryItem>();
			slot.ChangeTexture();
		}
	}

	//as an object is unpocketed, its position is 
	//set to the players position
	private static void SetPosition(GameObject go)
	{
		go.transform.position = m_Player.transform.position; 
	}

	public static void Serialize(){}
	public static void Deserialize(){}
}
