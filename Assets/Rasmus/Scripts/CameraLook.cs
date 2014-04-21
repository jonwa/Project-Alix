using UnityEngine;
using System.Collections;

public class CameraLook : MonoBehaviour 
{
	public GameObject m_Player;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Quaternion test = m_Player.transform.rotation;
		//test.y*=(-1);
		//test.z*=(-1);
		transform.rotation = test;
	}
}
