using UnityEngine;
using System.Collections;

/* Handles the inputs from any of the GUI components
 * This should be attached to the UI root
 * 
 * Created By: Jon Wahlström 2014-04-25
 * Modified By: 
 */

public class InputManager : MonoBehaviour 
{
	public static bool Active{get;set;}

	public static void Reset()
	{
		Active = !Active;
		if(Active)
		{
			Camera.main.gameObject.GetComponent<Raycasting>().ShowHover = false;
			Camera.main.gameObject.GetComponent<FirstPersonCamera>().LockCamera();
		}
		else if(!Active)
		{
			Camera.main.gameObject.GetComponent<Raycasting>().ShowHover = true;
			Camera.main.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
		}
	}
}
