using UnityEngine;
using System.Collections;

/* Discription: Objectcomponent class for putting the object you are locking at/holding in the inventory
 * 
 * Created by: Robert Datum: 07/04-14
 * Modified by: Jon Wahlström 2014-04-09
 * 
 */
[RequireComponent(typeof(Id))]
public class Pocket : ObjectComponent
{
	#region PublicMemberVariables
	public string		m_Input = "Pocket";
	#endregion
	
	#region PrivateMemberVariables
	private int			m_DeActivateCounter	= 0;
	private string		m_InventoryName		= "Inventory Example"; //Change to the real inventory name when finished		
	private GameObject 	m_Inventory;
	#endregion

	void Start()
	{
		m_Inventory = GameObject.Find(m_InventoryName);
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
	void AddToInventory()
	{
		InventoryData.AddItem(gameObject);
		Camera.main.GetComponent<Raycasting>().Release();
	}

	//Calls for the move to inventory function and then deactivates this item.
	public override void Interact ()
	{
		if(GetIsActive())
		{
			AddToInventory();
		}
		
		//Check if we are going to pocket this item.
		if(Input.GetButtonDown(m_Input))
		{
			Activate();
			m_DeActivateCounter = 0;
		}
		else
		{
			DeActivate();
		}
	}
}