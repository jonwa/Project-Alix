using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.transform.position.x < transform.position.x)
			SendMessageUpwards("RotateDoorClock");//, col.gameObject.rigidbody.velocity.magnitude);
		else
			SendMessageUpwards("RotateDoorUnClock");
	}
	public void OnCollisionStay(Collision col)
	{
		if(col.gameObject.transform.position.x < transform.position.x)
			SendMessageUpwards("RotateDoorClock");
		else
			SendMessageUpwards("RotateDoorUnClock");
	}
}
