using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour 
{
	public string m_LevelToLoad = "Main6";
	public float m_TimeUntilNextLoad = 20f;
	private bool	m_ShowLabel = false;

	AsyncOperation async;
	float loading = 0;



	//GameObject trans;

	// Use this for initialization
	void Start() 
	{
		StartLoading();
		//trans = GameObject.FindWithTag ("Progressbar");
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_TimeUntilNextLoad -= Time.deltaTime;
		float progress = async.progress;

		if(Input.GetButtonDown("Menu") || m_TimeUntilNextLoad <= 0f)
		{
			ActivateScene();
			m_ShowLabel = false;
		}

		//Print text about skipping on screen
		if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || Input.anyKeyDown)
		{
			m_ShowLabel = true;
		}
		//trans.transform.localScale = new Vector3(progress*11,1,0);
		loading++;
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
		StartCoroutine("load");
	}
	
	IEnumerator load() 
	{
		async = Application.LoadLevelAsync(m_LevelToLoad);
		async.allowSceneActivation = false;
		yield return async;
	}
	
	public void ActivateScene() 
	{
		async.allowSceneActivation = true;
	}

}
