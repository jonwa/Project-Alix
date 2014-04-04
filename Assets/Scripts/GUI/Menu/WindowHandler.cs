using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* WindowHandler either show or hide a window. The functions
 * are called from WindowButton.cs whenever a button is pressed. 
 * 
 * Created By: Jon Wahlström 2014-04-02
 * Modified By: 
 */

public class WindowHandler : MonoBehaviour 
{
	#region PublicMemberVariables
	public GameObject 				  m_InitialWindow = null;		
	#endregion

	#region PrivatMemberVariables
	private static Stack<GameObject> m_History 	     = new Stack<GameObject>(); 
	private static GameObject 	   	 m_CurrentWindow = null;
	private static GameObject		 m_DefaultWindow = null; 
	#endregion

	void Start()
	{
		if(m_InitialWindow != null)
		{
			m_DefaultWindow = m_InitialWindow;
			Debug.Log ("HEJHEJHEJ");
			m_CurrentWindow = m_InitialWindow; 
			m_CurrentWindow.gameObject.SetActive(true); 
			m_History.Push(m_CurrentWindow);
		}
	}

	public static void Default()
	{
		Clear();
		m_CurrentWindow = m_DefaultWindow; 
		m_CurrentWindow.gameObject.SetActive(true); 
		m_History.Push(m_CurrentWindow);
	}

	public static void Show(GameObject window)
	{
		if(m_History.Count > 0)
		{
			m_History.Peek().gameObject.SetActive (false);
		}

		m_CurrentWindow = window;
		m_CurrentWindow.gameObject.SetActive (true);


		m_History.Push (m_CurrentWindow);
	}

	public static void Hide()
	{
		if(m_History.Count > 1)
		{
			m_History.Pop().gameObject.SetActive(false);
			m_CurrentWindow = m_History.Peek();
			m_CurrentWindow.SetActive(true);
		}
	}

	static void Clear()
	{
		foreach(GameObject window in m_History)
		{
			window.SetActive(false);
		}
		m_History.Clear();
	}

	void OnLevelWasLoaded(int level)
	{
		m_CurrentWindow = null; 
		m_History.Clear ();
	}
}
