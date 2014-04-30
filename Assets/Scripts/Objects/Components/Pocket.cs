using UnityEngine;
using System.Collections;

/* Discription: Objectcomponent class for putting the object you are locking at/holding in the inventory
 * 
 * Created by: Robert Datum: 07/04-14
 * Modified by: Jon Wahlström 2014-04-11
 * 
 */
[RequireComponent(typeof(Id	 ))]
[RequireComponent(typeof(Name))]
public class Pocket : ObjectComponent
{
	#region PublicMemberVariables
	public string m_Input = "Pocket";
	#endregion
	
	#region PrivateMemberVariables
	private int   m_DeActivateCounter	= 0;
	#endregion

	void Start()
	{
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
		//TODO: Check to see if an object is already picked up? 
		// 		Check to see if the inventory is full?

		InventoryData.AddItem(gameObject, false);
		Camera.main.GetComponent<Raycasting>().Release();
	}

	//Calls for the move to inventory function and then deactivates this item.
	public override void Interact ()
	{
		if(IsActive)
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

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}