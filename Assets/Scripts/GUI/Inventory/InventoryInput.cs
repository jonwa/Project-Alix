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
	private string 	    m_Input = "Inventory"; 
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
			InventoryData.Toggle = InputManager.Active;

			if(InventoryData.Toggle)
			{ 
				gameObject.GetComponent<UIPlayTween>().Play (true);
			}
			else
			{
				gameObject.GetComponent<UIPlayTween>().Play (false);
				InventoryData.UpdateInventory(); 
			}

			InputManager.Reset();
		}
	}
}
