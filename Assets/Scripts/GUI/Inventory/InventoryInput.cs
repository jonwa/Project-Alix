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
	private string m_ToggleButton = "Inventory"; 
	private bool   m_Toggle 	  = true; 

	private GameObject m_Window	  = null; 
	#endregion

	public GameObject InventoryWindow
	{
		get { return m_Window;  }
		set { m_Window = value; }
	}

	void Update () 
	{
		ToggleInventoy();
	}
	
	void ToggleInventoy()
	{
		if(Input.GetButtonDown(m_ToggleButton))
		{
			if(m_Toggle)
			{ 
				m_Window.gameObject.SetActive(false);
				m_Toggle = false;
			}
			else
			{
				m_Window.gameObject.SetActive(true);
				m_Toggle = true; 
			}
		}
	}
}
