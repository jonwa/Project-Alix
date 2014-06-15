using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour 
{
//	public string 			m_LevelToLoad = "BugFixSga";
//	public float 			m_TimeUntilNextLoad = 20f;
//	private bool			m_ShowLabel = false;
//	private AsyncOperation 	m_Async;
//	private float 			m_Loading = 0;
//	
//	void Start() 
//	{
//		StartLoading();
//	}
//	
//	void Update () 
//	{
//		m_TimeUntilNextLoad -= Time.deltaTime;
//		float progress = m_Async.progress;
//
//		if(Input.GetButtonDown("Menu") || m_TimeUntilNextLoad <= 0f)
//		{
//			ActivateScene();
//			m_ShowLabel = false;
//		}
//
//		//Print text about skipping on screen
//		if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || Input.anyKeyDown)
//		{
//			m_ShowLabel = true;
//		}
//		m_Loading++;
//	}
//
//	void OnGUI()
//	{
//		Rect textArea = new Rect(0,0,Screen.width, Screen.height);
//		if(m_ShowLabel)
//		{
//			GUI.Label(textArea,"To skip press ESC");
//		}
//	}
//
//	public void StartLoading() 
//	{
//		StartCoroutine("load");
//	}
//	
//	IEnumerator load() 
//	{
//		m_Async = Application.LoadLevelAsync(m_LevelToLoad);
//		m_Async.allowSceneActivation = false;
//		yield return m_Async;
//	}
//	
//	public void ActivateScene() 
//	{
//		m_Async.allowSceneActivation = true;
//	}
	private float m_Time;
	private float m_StartTime;
	private float 			m_TimeUntilNextLoad = 40f;
	private bool			m_ShowLabel = false;



	void Start()
	{
		m_StartTime = Time.time;
	}

	void Update()
	{
		m_Time = Time.time - m_StartTime;

		if(m_Time > m_TimeUntilNextLoad || Input.GetButtonDown("Menu"))
		{
			Application.LoadLevel("BugFixSga");
			m_ShowLabel = false;
		}
	
		//Print text about skipping on screen
		if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0 || Input.anyKeyDown)
		{
			m_ShowLabel = true;
		}
	}

	void OnGUI()
	{
		Rect textArea = new Rect(0,0,Screen.width, Screen.height);
		if(m_ShowLabel)
		{
			GUI.Label(textArea,"To skip press ESC");
		}
	}

}
