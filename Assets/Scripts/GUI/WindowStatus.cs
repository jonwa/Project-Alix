using UnityEngine;
using System.Collections;

/* WindowStatus handles the activation and deactivation
 * of GUI components. 
 * 
 * 
 * Created By: Jon Wahlström 2014-05-07
 * Modified By: 
 */

public class WindowStatus : MonoBehaviour 
{
	#region PublicMemberVariables
	public enum Name	 {Menu, Inventory, Padlock, Book}; 
	public Name _Name = Name.Menu; 
	#endregion

	public void Activate(bool status)
	{
		switch(_Name)
		{
		case Name.Menu:

			transform.GetChild(0).gameObject.SetActive(status);
			if(status)
			{
				Time.timeScale = 0f; 
			}
			else
			{
				Time.timeScale = 1f;
			}
			break;
		case Name.Inventory:
			InventoryData.Toggle = status;
			if(status)
				transform.GetChild (0).transform.localPosition = new Vector3 (-0.7f, -0.75f, 0f);
			else
			{
				transform.GetChild (0).transform.localPosition = new Vector3 (-0.7f, -20f, 0f);
			}
			//transform.GetChild(0).gameObject.SetActive(status);
			break;
		case Name.Padlock:
			transform.GetChild(0).gameObject.SetActive(status);
			break;
		case Name.Book:
			transform.GetChild(0).gameObject.SetActive(status);
			break;
		}
	}
}
