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
	public enum Name{Menu, Inventory, Padlock, Book}; 
	public Name m_Name = Name.Menu; 
	#endregion

	public void Activate(bool status)
	{
		switch(m_Name)
		{
		case Name.Menu:
			transform.GetChild(0).gameObject.SetActive(status);
			break;
		case Name.Inventory:
			//InventoryData.Toggle = status;
			transform.GetChild(0).gameObject.SetActive(status);
			//gameObject.GetComponent<UIPlayTween>().Play (status);
			/*if(status)
			{
				InventoryData.UpdateInventory(); 
			}*/
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
