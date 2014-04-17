using UnityEngine;
using System.Collections;

/* Cursur texture, fixed position to the center of the screen
 * 
 * Created By: Martin Eriksson 2014-04-16
 * Modified By: Jon Wahlström 2014-04-16
 */

public class Cursor : MonoBehaviour {


	public Texture m_CrossHair;

	private static Texture m_Default;
	private static Texture m_Cursor;

	void Start()
	{
		// hides the windows cursor
		Screen.showCursor = false;

		m_Cursor = m_CrossHair; 
		m_Default = m_CrossHair;
	}

	public static Texture CrossHair
	{
		set 
		{
			m_Cursor = value;
		}
	}

	public static void Default()
	{
		m_Cursor = m_Default; 
	}

	void OnGUI (){
		Rect pos = new Rect (Screen.width * 0.5f - m_Cursor.width * 0.5f, Screen.height * 0.5f - m_Cursor.height * 0.5f, m_Cursor.width, m_Cursor.height);
		GUI.DrawTexture (pos, m_Cursor);
	}
}
