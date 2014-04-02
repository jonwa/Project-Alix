using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* 
 * 
 * Created By: Jon Wahlström 2014-04-02
 * Modified By: 
 */

public class WindowHandler : MonoBehaviour 
{
	#region privatMemberVariables
	private static WindowHandler m_Instance = null;
	private static object m_Lock = new object();

	private Stack<UIPanel> m_History = new Stack<UIPanel>(); 
	private UIPanel m_CurrentWindow;
	private UIPanel m_InitialWindow;
	#endregion

	public static WindowHandler Instance
	{
		get
		{
			if(m_Instance == null)
			{
				GameObject go = new GameObject("_UIWindow");
				m_Instance = go.AddComponent<WindowHandler>();
				DontDestroyOnLoad(go);
			}
			return m_Instance;
		}
	}

	void Start()
	{
		m_InitialWindow = GameObject.Find("Main").GetComponent<UIPanel>();
		m_InitialWindow.gameObject.SetActive(true);
		m_CurrentWindow = m_InitialWindow;
		m_History.Push(m_CurrentWindow);
	}
	
	public void Show(UIPanel window)
	{
		m_History.Peek().gameObject.SetActive(false);
	
		m_CurrentWindow = window; 
		m_CurrentWindow.gameObject.SetActive(true);
		m_History.Push(m_CurrentWindow);
	}

	public void Hide()
	{
		if (m_History.Count > 1) 
		{
			m_History.Pop().gameObject.SetActive(false);
			m_CurrentWindow = m_History.Peek();
			m_CurrentWindow.gameObject.SetActive(true);
		}
	}
}
