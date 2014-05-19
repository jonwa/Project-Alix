using UnityEngine;
using System.Collections;

public class RestartScene : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("m")) 
		{
			Application.LoadLevel("Surf1.0");
		}
	}
}