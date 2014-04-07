﻿using UnityEngine;
using System.Collections;

/* Interface for the inventory buttons
 * 
 * Created By: Jon Wahlström 2014-04-02
 * Modified By: 
 */

public class InventoryButton : MonoBehaviour 
{
	#region PrivateMemberVariables
	private bool m_Occupied = false; 
	#endregion

	//Called when a button is clicked
	void OnClick()
	{
		Debug.Log ("Inventory button was pressed");
	}
}
