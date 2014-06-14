using UnityEngine;
using System.Collections;

/* Opens a padlock window in which the user can choose
 * to enter a code. Can be used for certain puzzles. 
 * 
 * Created By: Jon Wahlström 2014-04-16
 * Modified By: 
 */

public class Padlock : ObjectComponent 
{
	#region PublicMemberVariables
	public GameObject m_Padlock = null; 
	public string 	  m_Input  = null; 
	#endregion

	void Start()
	{
		Camera.main.GetComponent<Raycasting>().Release();
	}

	void Update()
	{
		if(m_Padlock.transform.GetChild(0).gameObject.activeInHierarchy == true)
		{
			Camera.main.GetComponent<Raycasting>().Activate(Camera.main.GetComponent<Raycasting>().InteractingWith);
		}
	}

	public override void Interact ()
	{
		if(m_Padlock == null) return; 

		WindowStatus status = m_Padlock.GetComponent<WindowStatus>();

		if(IsActive && Input.GetButtonDown(m_Input))
		{
			bool isActive = InputManager.RequestShowWindow(m_Padlock);
			status.Activate((isActive == true) ? true : false);
		}
		else
		{
			Camera.main.GetComponent<Raycasting>().Release();
			Activate();
		}
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
