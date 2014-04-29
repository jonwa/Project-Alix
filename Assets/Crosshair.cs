using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour
{
	public Texture cross;

	private Rect rect;

	// Use this for initialization
	void Start()
	{
		rect = new Rect(Screen.width * 0.5f - 0.5f * cross.width, Screen.height * 0.5f - 0.5f * cross.height, cross.width, cross.height);
	}
	
	// Update is called once per frame
	void Update()
	{

	}

	void OnGUI()
	{
		GUI.DrawTexture(rect, cross);
	}
}
