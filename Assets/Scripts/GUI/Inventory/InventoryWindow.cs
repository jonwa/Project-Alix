using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Interface for the inventory background window
 * 
 * Created By: Jon Wahlström 2014-04-02
 * Modified By: 
 */

public class InventoryWindow : MonoBehaviour 
{
	public bool m_Edit = true; 

	void OnClick()
	{



	}

	void Update()
	{
		if(!m_Edit)
		{
			gameObject.GetComponent<BoxCollider>().enabled = false; 
		}
		else
		{
			gameObject.GetComponent<BoxCollider>().enabled = true; 
		}
	}
}
