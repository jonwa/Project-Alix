using UnityEngine;
using System.Collections;

public class InventoryActivity : MonoBehaviour 
{
	private Inventory m_Inventory = null;
	private GameObject[] m_Items;

	public Inventory InventoryBag
	{
		set { m_Inventory = value; }
	}

	void Start ()
	{
		m_Items = new GameObject[m_Inventory.m_MaxItemSlots];
			
	}

	void Update () 
	{
	
	}
}
