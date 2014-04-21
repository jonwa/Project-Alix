using UnityEngine;
using System.Collections;

public class DoorSound : MonoBehaviour {

	public AudioClip test;
	public bool m_destroy=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter()
	{
		AudioSource.PlayClipAtPoint(test, transform.position);
	}

	void OnTriggerEnter()
	{
		AudioSource.PlayClipAtPoint(test, transform.position);
		if(m_destroy)
		Object.Destroy(this.gameObject);
	}
}
