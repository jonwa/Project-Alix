using UnityEngine;
using System.Collections;

/* Discription: Objectcomponent class for putting the object you are locking at/holding in the inventory
 * 
 * Created by: Robert Datum: 07/04-14
 * Modified by:
 * 
 */
[RequireComponent(typeof(Id))]
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
	private int			m_Id;
	#endregion

	void Start()
	{
		m_Inventory = GameObject.Find(m_InventoryName);
		m_Id = GetComponent<Id>().GetId();
		//m_InventoryIsFull = m_Inventory.gameObject.GetComponent<Inventory>().GetIsfull();
	}
	
	void Update()
	{
		m_DeActivateCounter++;
		if (m_DeActivateCounter > 10) 
		{
			DeActivate ();
		}
	}
	
	//Adds the item to the inventory
	void AddIntoInventory()
	{
		/* Add to inventory/set ID */
		//m_Inventory.gameObject.GetComponent<Inventory>().AddItem(m_Id);
	}

	//Calls for the move to inventory function and then deactivates this item.
	public override void Interact ()
	{
		if(GetIsActive())
		{
			AddIntoInventory();
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