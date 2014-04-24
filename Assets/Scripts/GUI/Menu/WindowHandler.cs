using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

/*
 * Created By: Jon Wahlström 2014-04-22
 * Modified By: 
 */

public class WindowHandler : MonoBehaviour 
{
	#region PrivateMemberVariables
	private static Stack<GameObject> m_History = new Stack<GameObject>();
	
	private static GameObject m_CurrentWindow;
	private static int 		  m_ParamountID 	= 0; // top level windowID
	private static int 		  m_PreviousID;
	private static int		  m_CurrentID;
	#endregion
	
	public static void Show(int id, GameObject window)
	{	
		m_CurrentWindow = window;
		
		// In order to store the previous windowID we need the
		// stack to be of a size greater than 1.
		if(m_History.Count < 1)
		{
			m_CurrentID = id;
		}		
		else if(m_History.Count >= 1 && id != 0)
		{
			m_PreviousID = m_CurrentID;
		}

		m_CurrentID = id;

		if(id == m_ParamountID)
		{
			foreach(GameObject panel in m_History)
			{
				panel.SetActive(false);
			}
			
			m_History.Clear();
			
			if(m_CurrentWindow != null)
			{
				m_CurrentWindow.SetActive(true);
				m_History.Push(m_CurrentWindow);
			}
		}
		else if(id == m_PreviousID)
		{
			m_History.Pop().SetActive(false);
			m_CurrentWindow.SetActive(true);
			m_History.Push(m_CurrentWindow);
		}
		else
		{	
			m_CurrentWindow.SetActive(true);
			m_History.Push(m_CurrentWindow);
		}
	}

	public static void Default()
	{
		foreach(GameObject panel in m_History)
		{
			panel.SetActive(false);
		}
		m_History.Clear();
		m_CurrentWindow = null;
	}

	void OnLevelWasLoaded(int level)
	{
		m_CurrentWindow = null;
		m_History.Clear();
	}
}
