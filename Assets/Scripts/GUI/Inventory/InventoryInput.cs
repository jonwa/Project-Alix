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
			if(InventoryData.Toggle)
			{ 
				Camera.main.gameObject.GetComponent<Raycasting>().ShowHover = true;
				Camera.main.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
				gameObject.GetComponent<UIPlayTween>().Play (true);
				InventoryData.Toggle = false; 
			}
			else
			{
				Camera.main.gameObject.GetComponent<Raycasting>().ShowHover = false;
				Camera.main.gameObject.GetComponent<FirstPersonCamera>().LockCamera();
				gameObject.GetComponent<UIPlayTween>().Play (false);
				InventoryData.Toggle = true; 

				InventoryData.UpdateInventory(); 
			}
		}
	}
}
