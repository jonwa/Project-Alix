using UnityEngine;
using System.Collections;

public class ShowMe : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Camera.main.GetComponent<CameraFilter>().GetWhatEffect() == 7 && Camera.main.GetComponent<CameraFilter>().GetEffectActive() == true)
		{
			renderer.enabled = true;
		}
		else if(renderer.enabled == true)
		{
			renderer.enabled = false;
		}
	}
}
