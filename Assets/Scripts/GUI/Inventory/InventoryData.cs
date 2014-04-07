using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

/*
 * 
 * Created By: Jon Wahlström 2014-04-07
 * Modified By: 
 */

public class InventoryData : MonoBehaviour 
{
	#region PublicMemberVariables
	public BetterList<GameObject> m_InventoryButtons = new BetterList<GameObject>(); 
	public GameObject			  m_InventoryWindow	 = null; 
	#endregion

	public GameObject InventoryWindow
	{
		get { return m_InventoryWindow == null ? null : m_InventoryWindow;  }
		set { m_InventoryWindow = value; }
	}

	public BetterList<GameObject> InventoryButtons
	{
		get { return m_InventoryButtons == null ? null : m_InventoryButtons;  }
		set { m_InventoryButtons = value; }
	}
}
