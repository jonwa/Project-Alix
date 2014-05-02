﻿using UnityEngine;
using System.Collections;

/* Allows you to open a book
 * 
 * Created By: Jon Wahlström 2014-04-16
 * Modified By: 
 */

public class Read : ObjectComponent 
{
	#region publicMemberVariables
	public GameObject m_Window = null;
	public string 	  m_Input  = null; 
	#endregion

	void Update()
	{
		if(m_Window.activeInHierarchy == true)
		{
			InventoryData.NonOccupid();
		}
	}

	public override void Interact ()
	{
		if(m_Window == null) return; 

		if(IsActive && Input.GetButtonDown(m_Input))
		{
			m_Window.SetActive(true);
			Camera.main.GetComponent<Raycasting>().ShowHover = false; 
			Camera.main.GetComponent<FirstPersonCamera>().LockCamera();
		}
		else
		{
			Activate();
		}
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
