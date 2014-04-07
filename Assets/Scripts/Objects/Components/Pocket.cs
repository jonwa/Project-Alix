using UnityEngine;
using System.Collections;

/* Discription: Objectcomponent class for putting the object you are locking at in the inventory
 * 
 * Created by: Robert Datum: 07/04-14
 * Modified by:
 * 
 */

public class Pocket : ObjectComponent
{
	#region PublicMemberVariables
	public string		m_Input = "Fire3";
	#endregion
	
	#region PrivateMemberVariables
	private int			m_DeActivateCounter	= 0;
	private bool		m_InventoryIsFull;
	private string		m_InventoryName		= "Inventory Example"; //Change to the real inventory name when finnished		
	private GameObject 	m_Inventory;
	#endregion

	void Start()
	{
		m_Inventory = GameObject.Find(m_InventoryName);
		//m_InventoryIsFull = m_Inventory.gameObject.GetComponents<Inventory>().GetIsfull();
	}
	
	void Update()
	{
		m_DeActivateCounter++;
		if (m_DeActivateCounter > 10) 
		{
			DeActivate ();
		}
	}
	
	//Moves the item to the inventory
	void MoveToInventory()
	{
		/* Add to inventory/set ID */
		//m_Inventory.gameObject.GetComponents<Inventory>().AddItem(getID);
	}

	//Calls for the move to inventory function and then deactivates this item.
	public override void Interact ()
	{
		if(GetIsActive())
		{
			MoveToInventory();
			gameObject.SetActive(false);
			DeActivate();
		}
		
		//Check if we are going to pocket this item.
		if(Input.GetKeyDown(m_Input) /*&& inventory not full*/)
		{
			Activate();
			m_DeActivateCounter = 0;
		}
		else
		{
			DeActivate();
			Debug.Log ("Inventory full");
		}
	}
}