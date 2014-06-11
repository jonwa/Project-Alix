using UnityEngine;
using System.Collections;

/* Used in order to open the deathmenu when the player dies. 
 * The function Activate can be called for this. 
 * 
 * 
 * Created By: Jon Wahlström 2014-05-12
 * Modified By: 
 */

public class ActivateDeathMenu : TriggerComponent 
{
	public GameObject _window; 

	public void ActivateWindow() 
	{
		WindowStatus status = gameObject.GetComponent<WindowStatus>();
		_window.SetActive(true);	
		bool isActive = InputManager.RequestShowWindow(gameObject);
		status.Activate(isActive);
	}

	public void DeactivateWindow() 
	{
		WindowStatus status = gameObject.GetComponent<WindowStatus>();
		_window.SetActive(false);	
		//bool isActive = InputManager.RequestShowWindow(gameObject);
		status.Activate(false);
	}

	override public string Name
	{ get{return"ActivateWindow";}}
	
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
