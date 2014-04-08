using UnityEngine;
using System.Collections.Generic;

/*
 *  
 * 
 * Created By: Jon Wahlström 2014-04-08
 * Modified By: 
 */

public class Inventory : MonoBehaviour 
{
	#region PublicMemberVariables
	public GameObject m_Template	  = null; 
	public GameObject m_Input		  = null; 
	public UIWidget	  m_Background    = null; 
	public GameObject m_Root		  = null; 

	public int 		  m_MaxItemSlots  = 0;
	public int 		  m_MaxRows		  = 0;
	public int 		  m_MaxColumns	  = 0; 
	public int 		  m_Spacing		  = 0; 
	public int 		  m_Padding		  = 0; 
	#endregion

	private List<GameObject> m_ItemList = new List<GameObject>(); 

	void Start () 
	{
		if(m_Root == null) 
		{
			return;
		}
		else
		{
			GameObject go = NGUITools.AddChild(m_Root, m_Input);
			go.GetComponent<InventoryInput>().InventoryWindow = gameObject;
		}

		if(m_Template != null)
		{
			InitializeInventory();
		}
	}

	void InitializeInventory()
	{
		int    count = 0; 
		Bounds bound = new Bounds();

		for(int y = 0; y < m_MaxRows; ++y)
		{
			for(int x = 0; x < m_MaxColumns; ++x)
			{
				GameObject go   		   = NGUITools.AddChild(gameObject, m_Template);
				go.transform.localPosition = new Vector3(
					m_Padding  + (x + 0.5f) * m_Spacing,
					-m_Padding - (y + 0.5f) * m_Spacing,
					0f);

				//go.GetComponent<InventoryItem>().Id = count; 

				bound.Encapsulate(new Vector3(
					m_Padding  * 2f + (x + 1) * m_Spacing,
					-m_Padding * 2f - (y + 1) * m_Spacing, 
					0f));

				++count; 
				// Not sure if this even works, 
				// needs to be tested! 
				if(count >= m_MaxItemSlots)
				{
					if(m_Background != null) 
					{
						m_Background.transform.localScale = bound.size;
					}
					return;
				}

				m_ItemList.Add(go);
			}
		}

		if(m_Background != null) 
		{
			m_Background.transform.localScale = bound.size;
		}
	}
}
