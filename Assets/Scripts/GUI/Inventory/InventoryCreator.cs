using UnityEngine;
using System.Collections;

/* Initiates the inventory. 
 * 
 * 
 * Created By: Jon Wahlström 2014-04-04
 * Modified By: 
 */

public class InventoryCreator : MonoBehaviour 
{
	#region PublicMemberVariables
	public UIPanel  m_Parent 		  = null;
	public UIButton m_Window		  = null; 
	public UIButton m_Button		  = null;

	public float 	m_WindowPositionX = 0; 
	public float 	m_WindowPositionY = 0; 

	public int 		m_NumberColumns	  = 0;
	public int 		m_NumberRows	  = 0;
	public float    m_ButtonSpacing   = 0f;
	#endregion

	#region PrivateMemberVariables
	private BetterList<GameObject> m_Buttons = new BetterList<GameObject>();

	private int        m_WindowWidth     = 0; 
	private int 	   m_WindowHeight    = 0;
	private float	   m_WindowOutline   = 10f;

	private GameObject m_InventoryWindow = null;
	private GameObject m_InventoryButton = null;
	#endregion
	
	void Start () 
	{
		InitializeHierarky();
		InitializeWindow ();
		InitializeInventoy();
	}

	//Initialization for the object parenting
	void InitializeHierarky()
	{
		m_InventoryWindow 				          = Instantiate(m_Window.gameObject) as GameObject;
		m_InventoryWindow.transform.parent 		  = m_Parent.transform;
		m_InventoryWindow.transform.localScale 	  = new Vector3(1f, 1f, 1f);
		m_InventoryWindow.transform.localPosition = new Vector3 (m_WindowPositionX, 
		                                                         m_WindowPositionY, 
		                                                         0f);
	}

	//Initialization for the inventory window
	void InitializeWindow()
	{
		m_WindowWidth  = (int)((m_NumberColumns * m_Button.GetComponent<UISprite> ().width)  + m_WindowOutline);
		m_WindowHeight = (int)((m_NumberRows    * m_Button.GetComponent<UISprite> ().height) + m_WindowOutline);

		m_InventoryWindow.GetComponent<UISprite> ().width  = m_WindowWidth;
		m_InventoryWindow.GetComponent<UISprite> ().height = m_WindowHeight;
	}

	//Initialization for the inventory layout
	void InitializeInventoy()
	{
		int i 	  = 0; 
		int j 	  = 0;
		for(int x = 0; x < m_NumberRows; ++x)
		{
			for(int y = 0; y < m_NumberColumns; ++y)
			{
				GameObject button 			   = Instantiate(m_Button.gameObject) as GameObject;
				button.transform.parent 	   = m_InventoryWindow.transform;

				//calculated the correct position depending 
				//on the number of columns in both x- and y-axis.
				int xMult = y % m_NumberColumns;
				int yMult = (int)Mathf.Floor(y / m_NumberColumns);

				//this is retarded, but it works.
				//positioning for each button according to 
				//its parent (that is the m_InventoryWindow)
				button.transform.localScale	   = new Vector3(1f, 1f, 1f);
				button.transform.localPosition = 
					new Vector3((xMult * m_ButtonSpacing) - (m_WindowWidth/2) + (button.GetComponent<UISprite>().width/2) + (m_WindowOutline/2), 						
					            (((yMult * m_ButtonSpacing))-(j * m_ButtonSpacing)) + (m_WindowHeight/2) - (button.GetComponent<UISprite>().height/2) - (m_WindowOutline/2),
					            0f);

				m_Buttons.Add(button);
			}

			if((int)Mathf.Floor(x / m_NumberColumns) < 1)
				j += 1;
			else
				j += (int)Mathf.Floor(x / m_NumberColumns) + 1;
		}
	}
}
