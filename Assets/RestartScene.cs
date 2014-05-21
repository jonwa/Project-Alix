using UnityEngine;
using System.Collections;

public class RestartScene : MonoBehaviour 
{
	public string levelName = "Robert - Copy";
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("m")) 
		{
			Application.LoadLevel(levelName);
		}
	}
}