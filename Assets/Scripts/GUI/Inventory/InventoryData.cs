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
	public string m_PlayerName = "Player Controller Example";
	#endregion

	#region PrivateMemberVariables
	private static List<GameObject> m_Slots		   = new List<GameObject>();
	private static GameObject[] 	m_Items		   = null;
	private static int 				m_MaxItemSlots = 0; 
	private static GameObject		m_Player	   = null;
	#endregion

	public static bool Toggle{get;set;}

	public static InventoryData instance; 
	void Start ()
	{
		instance = this; 

		Toggle 		   = false;
		m_MaxItemSlots = m_MaxItems;
		m_Items        = new GameObject[m_MaxItems];
		m_Player 	   = GameObject.Find(m_PlayerName);
		gameObject.transform.localPosition = new Vector3 (-0.7f, -20f, 0f);
	}

	//Initializes the List of empty slots. 
	//called from Inventory.cs
	public static void AddSlot(GameObject slot)
	{
		m_Slots.Add(slot);
	}

	//add a object to the inventory, called from Pocket.cs
	public static void AddItem(GameObject go, bool swap)
	{
		Debug.Log ("AddItem start");
		if(!swap)
		{
			Camera.main.GetComponent<Raycasting>().InteractingWith = null; 
		}

		foreach(GameObject itemSlot in m_Slots)
		{
			
			Debug.Log("For each");
			InventoryItem slot = itemSlot.GetComponent<InventoryItem>();
			if(!slot.Occupied)
			{
				Debug.Log("!slot.Occupied");
				Name name = go.GetComponent<Name>();

				if(name == null) return;

				slot.Occupied 	   = true;
				m_Items[slot.Slot] = go;
				go.SetActive(false);
				Camera.main.GetComponent<Raycasting>().Release();

				if(Toggle)
				{
					Debug.Log("Toggle == true");
					slot.Replace(name.ObjectName);
				}
				else
				{
					Debug.Log("Toggle == false");
					slot.DelayedReplace(name.ObjectName);
				}
				UpdateInventory();
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

			if(m_Player != null) 
			{
				FirstPersonController controller = m_Player.GetComponent<FirstPersonController>();
				Inspect    inspect 				 = go.GetComponent<Inspect>();
				PickUp     pickup				 = go.GetComponent<PickUp>();
				Raycasting raycast				 = Camera.main.GetComponent<Raycasting>();

				if(pickup)
				{
					if(raycast.InteractingWith != null)
					{
						AddItem(raycast.InteractingWith, true);
						raycast.InteractingWith = go; 
					}
					raycast.Activate(go);
				}
			}
		}
	}

	//updates the information for each slot in
	//the inventory as it gets active
	public static void UpdateInventory()
	{
		if(m_Slots.Count > 0)
		{
			foreach(GameObject item in m_Slots)
			{
				InventoryItem slot = item.GetComponent<InventoryItem>();
				slot.ChangeTexture();
			}
		}
	}
}
