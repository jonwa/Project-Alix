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
	public int 	  m_MaxItems   = 5;
	public string m_PlayerName;
	#endregion

	#region PrivateMemberVariables
	private static List<GameObject> m_Slots		   = new List<GameObject>();
	private static GameObject[] 	m_Items		   = null;
	private static bool 			m_Toggle	   = false; 
	private static int 				m_MaxItemSlots = 0; 
	private static GameObject		m_Player	   = null; 
	#endregion

	void Start ()
	{
		m_MaxItemSlots = m_MaxItems;
		m_Items        = new GameObject[m_MaxItems];

		if(m_PlayerName != null)
		{
			m_Player   = GameObject.Find(m_PlayerName) as GameObject;
		}
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
				Name name = go.GetComponent<Name>();

				if(name == null) return;

				slot.Occupied 	   = true;
				m_Items[slot.Slot] = go;

				if(m_Toggle)
				{
						slot.Replace(name.ObjectName);
				}
				else
				{
					slot.DelayedReplace(name.ObjectName);
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

			//this might need to be changed, simply reposition the origional pos of
			//the pocketed object as the object is unpocketed. 
			if(m_Player != null) 
			{
				FirstPersonController controller = m_Player.GetComponent<FirstPersonController>();
				Inspect    inspect 				 = go.GetComponent<Inspect>();
				PickUp     pickup				 = go.GetComponent<PickUp>();
				Raycasting raycast				 = Camera.main.GetComponent<Raycasting>();

				if(pickup)
				{
					raycast.Activate(go);
				}
				else 
					if(inspect)
				{
					inspect.OrigionalPosition = controller.Position; 
				}
			}
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
}
