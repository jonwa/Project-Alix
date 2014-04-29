using UnityEngine;
using System.Collections;

/* Allows you to toggle between opened and closed. 
 * Default button, "Inventory", is "b" and can be
 * changed in the Unity Input Management. 
 * 
 * Created By: Jon Wahlström 2014-04-07
 * Modified By: 
 */

public class InventoryInput : MonoBehaviour 
{
	#region PrivateMembrVariables
	private string m_Input = "Inventory"; 
	#endregion

	void Start()
	{

	}

	void Update () 
	{
		ToggleInventoy();
	}
	
	void ToggleInventoy()
	{
		if(Input.GetButtonDown(m_Input))
		{
			if(InventoryData.Toggle && InputManager.Active)
			{ 
				InputManager.Active = false;
				InventoryData.Toggle = false;
				gameObject.GetComponent<UIPlayTween>().Play (false);
				InventoryData.UpdateInventory(); 
			}
			else if(InventoryData.Toggle && !InputManager.Active)
			{
				return;
			}
			else
			{
				InputManager.Active = true;
				InventoryData.Toggle = true;
				gameObject.GetComponent<UIPlayTween>().Play (true);

			}

			InputManager.Reset();
		}
	}
}
