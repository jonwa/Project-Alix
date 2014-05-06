using UnityEngine;
using System.Collections;

public class InstantLoadLevel : MonoBehaviour 
{
	void Start()
	{
		DontDestroyOnLoad(gameObject);
		Application.LoadLevel(1);
	}

	void OnLevelWasLoaded()
	{
		DestroyImmediate(this);
	}
}
