using UnityEngine;
using System.Collections;

/* The cursor used for the game. This can be in 
 * two different states, crosshair and regular mouse pointer
 * This handles the current state of the cursor.
 * 
 * Created By: Jon Wahlström 2014-04-21
 * Modified By: 
 */

public class MenuCursor : MonoBehaviour 
{
	#region PublicMemberVariables
	public Texture m_Cursor;
	#endregion
	
	#region PrivateMemberVariables
	private static string m_Description;
	private static Texture m_DefaultTexture;
	private static Texture m_CrossHairTexture;
	private static Texture m_CursorTexture;
	private static GameObject m_DescriptionGO;
	private static bool m_ShowCrossHair = true;
	private static bool m_ShowDescription = false;
	#endregion
	
	
	void Start()
	{
		Screen.showCursor  = false;
		m_CursorTexture    = m_Cursor;
	}
	
	// In order to deside in what state the cursor should be in
	public static void SetCursor(Texture cursor, string description, bool crosshair)
	{
		if(cursor == null)
		{
			m_CrossHairTexture = m_DefaultTexture;
		}
		else
		{
			m_CrossHairTexture = cursor;
		}
		
		if(string.IsNullOrEmpty(description))
		{
			m_ShowDescription = false;
		}
		else
		{
			m_ShowDescription = true;
			m_Description 	  = description;
		}
		
		m_ShowCrossHair   = crosshair;
	}

	void Update()
	{
		DrawCursor();
	}
	
	void OnGUI()
	{
		DrawCursor();		
	}

	
	// Draw the mouse cursor, used whenever e.g. a menu or padlock is visible
	void DrawCursor()
	{
		GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, m_CursorTexture.width, m_CursorTexture.height), m_CursorTexture);
	}

}