using UnityEngine;
using System.Collections;

/* Allows you to open a book
 * 
 * Created By: Jon Wahlström 2014-04-16
 * Modified By: 
 */

public class Read : ObjectComponent 
{
	#region publicMemberVariables
	public GameObject m_Book = null;
	public string 	  m_Input  = null; 
	#endregion

	void Update()
	{
		if(m_Book.transform.GetChild(0).gameObject.activeInHierarchy == true)
		{
			Camera.main.GetComponent<Raycasting>().Activate(Camera.main.GetComponent<Raycasting>().InteractingWith);
		}
	}

	public override void Interact ()
	{
		if(m_Book == null) return; 

		WindowStatus status = m_Book.GetComponent<WindowStatus>();
		
		if(IsActive && Input.GetButtonDown(m_Input))
		{
			bool isActive = InputManager.RequestShowWindow(m_Book);
			status.Activate((isActive == true) ? true : false);
		}
		else
		{
			Activate();
		}
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
