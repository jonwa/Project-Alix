using UnityEngine;
using System.Collections;

/*
 * 
 * Created By: Jon Wahlström 2014-04-04
 * Modified By: 
 */

public class Inventory : MonoBehaviour 
{
	#region PublicMemberVariables
	public UIPanel  m_Parent 		  = null;
	public UISprite m_Window		  = null; 
	public float 	m_WindowPositionX = -300; 
	public float 	m_WindowPositionY = 500; 

	public int 		m_NumberColumns	  = 5;
	public float    m_ButtonSpacing   = 0.2f;
	public int 		m_NumberSlots	  = 5;

	public UIButton m_Button		  = null;
	public bool 	m_MouseInput	  = true; 
	#endregion

	#region PrivateMemberVariables
	private BetterList<GameObject> m_Buttons = new BetterList<GameObject>();

	private float      m_WindowSizeX; 
	private float 	   m_WindowSizeY;
	private GameObject m_InventoryWindow;

	private float	   m_ButtonPositionX = 0; 
	private float	   m_ButtonPositionY = 0; 
	#endregion
	
	void Start () 
	{
		InitializeHierarky();
		InitializeButtonList ();
		InitializeInventoy();
	}

	void InitializeHierarky()
	{
		
		m_InventoryWindow 				          = Instantiate(m_Window.gameObject) as GameObject;
		m_InventoryWindow.transform.parent 		  = m_Parent.transform;
		m_InventoryWindow.transform.localPosition = new Vector3 (m_WindowPositionX, 
		                                                         m_WindowPositionY, 
		                                                         0f);
		m_InventoryWindow.transform.localScale 	  = new Vector3(1f, 1f, 1f);
	}

	void InitializeButtonList()
	{
		for(int i = 0; i < m_NumberSlots; ++i)
		{
			GameObject button 			   = Instantiate(m_Button.gameObject) as GameObject;
			button.transform.parent 	   = m_InventoryWindow.transform;
			button.transform.localPosition = new Vector3(0f, 0f, 0f);
			m_Buttons.Add(button);
		}
	}

	void InitializeInventoy()
	{
		int j = 0; 
		for(int i = 0; i < m_Buttons.size; ++i)
		{
			int xMult = (int)Mathf.Floor(i / m_NumberColumns);
			int yMult = i % m_NumberColumns;

			m_Buttons[i].gameObject.transform.localPosition = 
				new Vector3(m_ButtonPositionX + (xMult * m_ButtonSpacing), 						
			                m_ButtonPositionY-((yMult * m_ButtonSpacing))-(j * m_ButtonSpacing),
			                0f);	

			m_Buttons[i].gameObject.transform.localScale	= 
				new Vector3(1f, 1f, 1f);
		}

		int  width  = 0; 
		int  height = 0;
		bool once   = true; 
		foreach(GameObject button in m_Buttons)
		{
			width += (int)(button.transform.localPosition.x) + button.GetComponent<UISprite>().width + 10;// + (int)m_ButtonSpacing;
			if(once)
			{
				height = (int)(button.GetComponent<UISprite>().height) + 10;
				once   = false; 
			}
		}
		m_InventoryWindow.GetComponent<UISprite> ().width  = width;
		m_InventoryWindow.GetComponent<UISprite> ().height = height;

	}
}
