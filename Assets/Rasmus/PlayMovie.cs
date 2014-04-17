using UnityEngine;
using System.Collections;

public class PlayMovie : MonoBehaviour 
{
	public MovieTexture m_Movie;
	// Use this for initialization
	void Start () 
	{
		renderer.material.mainTexture = m_Movie;
		//m_Movie.Play();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnCollisionEnter()
	{
		m_Movie.Stop();
		m_Movie.Play();
		GetComponent<AudioSource>().Play();

	}
}
