using UnityEngine;
using System.Collections;

/* 
 * 
 * Created By: Jon Wahlström 2014-04-21
 * Modified By: 
 */

public class Cursor : MonoBehaviour 
{
	#region PublicMemberVariables
	public Texture m_DefaultCrossHair;
	public Texture m_DefaultCursor;
	public GameObject m_DescriptionFab;
	#endregion

	#region PrivateMemberVariables
	private bool m_UsingOculus;
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
		m_UsingOculus 	   = Camera.main.transform.parent.GetComponent<CharacterData>().GetOculus();

		m_DefaultTexture   = m_DefaultCrossHair;
		m_CrossHairTexture = m_DefaultCrossHair;
		m_CursorTexture    = m_DefaultCursor;
		m_DescriptionGO    = m_DescriptionFab;
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
			m_CrossHairTexture   = cursor;
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

	void OnGUI()
	{
		if(m_ShowCrossHair)
		{
			DrawCrossHair();
		}
		else 
		{
			DrawCursor();
		}

		DrawDescription(m_ShowDescription);
	}

	// Draw the cross hair in the center of the screen
	void DrawCrossHair()
	{
		Rect position;
		if(m_UsingOculus == true)
		{
			position = new Rect (Screen.width  * 0.3f - m_CrossHairTexture.width  * 0.5f, 
			                     Screen.height * 0.5f - m_CrossHairTexture.height * 0.5f, 
			                          m_CrossHairTexture.width, 
			                          m_CrossHairTexture.height);
			
			GUI.DrawTexture (position, m_CrossHairTexture);
			
			position = new Rect (Screen.width  * 0.7f - m_CrossHairTexture.width  * 0.5f, 
			                     Screen.height * 0.5f - m_CrossHairTexture.height * 0.5f, 
			                          m_CrossHairTexture.width, 
			                          m_CrossHairTexture.height);

			GUI.DrawTexture (position, m_CrossHairTexture);
		}
		else
		{
			position = new Rect (Screen.width  * 0.5f - m_CrossHairTexture.width  * 0.5f, 
			                          Screen.height * 0.5f - m_CrossHairTexture.height * 0.5f, 
			                          m_CrossHairTexture.width, 
			                          m_CrossHairTexture.height);
			
			GUI.DrawTexture (position, m_CrossHairTexture);
		}
	}

	// Draw the mouse cursor, used whenever e.g. a menu or padlock is visible
	void DrawCursor()
	{
		GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, m_CursorTexture.width, m_CursorTexture.height), m_CursorTexture);
	}

	// Draw a description, part of the hoover effect. Gives the player an description
	// of the object that is hoovered. 
	void DrawDescription(bool show)
	{
		if(m_Description == null) return;
		if(m_DescriptionGO == null) return;

		if(show)
		{
			m_DescriptionGO.GetComponentInChildren<UILabel> ().text = m_Description;
		}
		else
		{
			m_DescriptionGO.GetComponentInChildren<UILabel> ().text = "";
		}
	}
}
