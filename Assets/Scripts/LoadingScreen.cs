using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

	AsyncOperation async;
	float loading = 0;
	GameObject trans;

	// Use this for initialization
	void Start() {
		StartLoading();
		trans = GameObject.FindWithTag ("Progressbar");
	}
	
	// Update is called once per frame
	void Update () {
		float progress = async.progress;
		if(Input.GetButtonDown("Fire2"))
		{
			ActivateScene();
		}
		Debug.Log (progress);
		trans.transform.localScale = new Vector3(progress*11,1,0);
		loading++;
	}
	
	public void StartLoading() {
		StartCoroutine("load");
	}
	
	IEnumerator load() {
		async = Application.LoadLevelAsync("Robert");
		async.allowSceneActivation = false;
		yield return async;
	}
	
	public void ActivateScene() {
		async.allowSceneActivation = true;
	}

}
