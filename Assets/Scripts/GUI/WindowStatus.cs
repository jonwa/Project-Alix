using UnityEngine;
using System.Collections;

public class WindowStatus : MonoBehaviour 
{
	public enum Name{Menu, Inventory, Padlock, Book}; 
	public Name m_Name = Name.Menu; 

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
