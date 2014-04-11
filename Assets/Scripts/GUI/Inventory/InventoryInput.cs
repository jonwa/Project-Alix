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
	private string 	   m_ToggleButton = "Inventory"; 
	private GameObject m_Window	      = null; 
	#endregion

	public GameObject InventoryWindow
	{
		get { return m_Window;  }
		set { m_Window = value; }
	}

	void Start()
	{
		m_Window.gameObject.SetActive(false);
		Camera.main.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
	}

	void Update () 
	{
		ToggleInventoy();
	}
	
	void ToggleInventoy()
	{
		if(Input.GetButtonDown(m_ToggleButton))
		{
			if(InventoryData.Toggle)
			{ 
				Camera.main.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
				InventoryData.Toggle = false; 
				m_Window.gameObject.SetActive(false);
			}
			else
			{
				Camera.main.gameObject.GetComponent<FirstPersonCamera>().LockCamera();
				InventoryData.Toggle = true; 
				m_Window.gameObject.SetActive(true);

				InventoryData.UpdateInventory(); 
			}
		}
	}
}
