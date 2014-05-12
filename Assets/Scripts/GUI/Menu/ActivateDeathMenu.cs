using UnityEngine;
using System.Collections;

/* Used in order to open the deathmenu when the player dies. 
 * The function Activate can be called for this. 
 * 
 * 
 * Created By: Jon Wahlström 2014-05-12
 * Modified By: 
 */

public class ActivateDeathMenu : MonoBehaviour 
{
	public GameObject _window; 

	public void Activate() 
	{
		WindowStatus status = gameObject.GetComponent<WindowStatus>();
		_window.SetActive(true);	
		bool isActive = InputManager.RequestShowWindow(gameObject);
		status.Activate(isActive);
	}
}
