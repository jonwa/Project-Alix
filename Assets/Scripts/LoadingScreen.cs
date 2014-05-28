using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

	public string m_LevelToLoad = "Main5";
	public float m_TimeUntilNextLoad = 20f;

	AsyncOperation async;
	float loading = 0;



	//GameObject trans;

	// Use this for initialization
	void Start() {
		StartLoading();
		//trans = GameObject.FindWithTag ("Progressbar");
	}
	
	// Update is called once per frame
	void Update () {
		m_TimeUntilNextLoad -= Time.deltaTime;
		float progress = async.progress;
		if(Input.GetButtonDown("Fire2") || m_TimeUntilNextLoad <= 0f)
		{
			ActivateScene();
		}
		Debug.Log (progress);
		//trans.transform.localScale = new Vector3(progress*11,1,0);
		loading++;
	}
	
	public void StartLoading() {
		StartCoroutine("load");
	}
	
	IEnumerator load() {
		async = Application.LoadLevelAsync(m_LevelToLoad);
		async.allowSceneActivation = false;
		yield return async;
	}
	
	public void ActivateScene() {
		async.allowSceneActivation = true;
	}

}
