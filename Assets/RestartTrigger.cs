using UnityEngine;
using System.Collections;

public class RestartTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		col.GetComponent<RestartWallJumpGrej> ().NewStartPoint (transform.position);
	}
}
