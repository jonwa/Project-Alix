using UnityEngine;
using System.Collections;

public class RotatetoChar : MonoBehaviour {
	public GameObject m_Camera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(m_Camera.transform.position);
	}
}
