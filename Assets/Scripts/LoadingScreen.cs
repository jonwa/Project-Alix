using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour 
{
	public string 			m_LevelToLoad;
	public float 			m_TimeUntilNextLoad = 20f;
	private bool			m_ShowLabel = false;
	private AsyncOperation 	m_Async;
	private float 			m_Loading = 0;
	
	void Start() 
	{
		StartLoading();
	}
	
	void Update () 
	{
		m_TimeUntilNextLoad -= Time.deltaTime;
		float progress = m_Async.progress;
		Debug.Log ("PROGRESS = " + progress);
		Debug.Log ("IS DONE = " + m_Async.isDone);

		if(Input.GetButtonDown("Menu") || m_TimeUntilNextLoad <= 0f)
		{
			if(m_Async.isDone)
			{
				ActivateScene();
			}
			m_ShowLabel = false;
		}

		//Print text about skipping on screen
		if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || Input.anyKeyDown)
		{
			m_ShowLabel = true;
		}
		m_Loading++;
	}

	void OnGUI()
	{
		Rect textArea = new Rect(0,0,Screen.width, Screen.height);
		if(m_ShowLabel)
		{
			GUI.Label(textArea,"To skip press ESC");
		}
	}

	public void StartLoading() 
	{
		//StartCoroutine("load");
		StartCoroutine ("loadLevel");
	}
	
	IEnumerator load() 
	{
		m_Async = Application.LoadLevelAsync(m_LevelToLoad);
		m_Async.allowSceneActivation = false;
		yield return m_Async;
	}

	private IEnumerator loadLevel()
	{
		if(string.IsNullOrEmpty(m_LevelToLoad))
		{
			yield return 0;
		}

		Debug.Log ("ManagerGame: level[" + m_LevelToLoad + "] loading level");

		GameObject go = GameObject.Find ("All");

		if(go != null)
		{
			DestroyImmediate(go);
			Resources.UnloadUnusedAssets();
		}

		AsyncOperation async = Application.LoadLevelAdditiveAsync (m_LevelToLoad);
		yield return async;

		go = new GameObject ("All");

		GameObject.Find (m_LevelToLoad).transform.parent = go.transform;

		Debug.Log ("ManagerGame: level[" + m_LevelToLoad + "] loading complete");
	}
	
	public void ActivateScene() 
	{
		m_Async.allowSceneActivation = true;
	}

}
