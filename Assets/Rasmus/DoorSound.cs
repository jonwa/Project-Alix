using UnityEngine;
using System.Collections;

public class DoorSound : MonoBehaviour {

	public AudioClip test;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter()
	{
		AudioSource.PlayClipAtPoint(test, transform.position);
		Object.Destroy(this.gameObject);
	}
}
