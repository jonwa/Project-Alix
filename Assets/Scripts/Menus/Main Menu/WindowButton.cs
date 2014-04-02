﻿using UnityEngine;
using System.Collections;

/* A WindowButton 
 * 
 * Created By: Jon Wahlström 2014-04-02
 * Modified By: 
 */

public class WindowButton : MonoBehaviour 
{
	public enum Action{	show, hide, loadScene, exit };

	#region publicMemberVariables
	public string m_SceneName = null;
	public UIPanel m_Window = null; 
	public Action m_Action = Action.show;
	#endregion

	private WindowHandler m_WindowHandler;

	private bool m_LevelFlag = false;
	private bool m_WindowFlag = true;

	void Start()
	{
		m_WindowHandler = WindowHandler.Instance;
	}

	void OnClick()
	{
		switch (m_Action)
		{
		case Action.show:
			if(m_Window != null) 
			{
				m_WindowHandler.Show(m_Window);
			}
			else
				Debug.Log("Please assign window to open");
			break;
		
		case Action.hide:
			m_WindowHandler.Hide();
			break;
		
		case Action.loadScene:
			if(m_SceneName != null) 
			{
				Application.LoadLevel(m_SceneName);
			}
			else
				Debug.Log("Please assign scene to load");
			break; 
		
		case Action.exit:
			Application.Quit();
			break; 
		}
	}
}
