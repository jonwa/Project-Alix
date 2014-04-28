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
	public GameObject m_Window = null; 
	public string 	  m_Input  = null; 
	#endregion

	public override void Interact ()
	{
		if(IsActive && Input.GetButtonDown(m_Input))
		{
			m_Window.SetActive(true);
			Camera.main.gameObject.GetComponent<Raycasting>().ShowHover = false; 
			Camera.main.gameObject.GetComponent<FirstPersonCamera>().LockCamera();
		}
		else
		{
			Activate();
		}
	}
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
