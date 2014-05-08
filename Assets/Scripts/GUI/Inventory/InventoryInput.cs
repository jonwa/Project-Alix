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

	void Update () 
	{
		if(Input.GetButtonDown(m_Input))
		{
			WindowStatus status = gameObject.GetComponent<WindowStatus>();
			if(Input.GetButtonDown(m_Input))
			{
				bool isActive = InputManager.RequestShowWindow(gameObject);
				status.Activate((isActive == true) ? true : false); 
			}
		}
	}

	/*if(InventoryData.Toggle && InputManager.Active)
			{ 
				InputManager.Active = false;

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

			InputManager.Reset();*/
}
