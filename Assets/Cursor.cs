using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {


	public Texture crossHair;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI (){
		Rect pos = new Rect (Screen.width * 0.5f - crossHair.width * 0.5f, Screen.height * 0.5f - crossHair.height * 0.5f, crossHair.width, crossHair.height);
		GUI.DrawTexture (pos, crossHair);
	}
}
