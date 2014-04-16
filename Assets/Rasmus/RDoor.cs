using UnityEngine;
using System.Collections;

public class RDoor : MonoBehaviour 
{
	public float test		= 0;
	public float test2		= 0;
	public float MaxAngle	= 90;
	public float MinAngel	= 270;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey("t"))
		{
			Vector3 pointVec = transform.localPosition;
			//pointVec.x -= renderer.bounds.size.x/2;
			
			transform.RotateAround(pointVec, transform.up, test);
		}
		if(Input.GetKey("y"))
		{
			Vector3 pointVec = transform.localPosition;
			//pointVec.x -= renderer.bounds.size.x/2;
			
			transform.RotateAround(pointVec, transform.up, -test);
		}
	}

	public void RotateDoorClock()
	{
		if(transform.rotation.eulerAngles.y < MaxAngle){
			Vector3 pointVec = transform.localPosition;
			transform.RotateAround(pointVec, transform.up, test);
		}
		Debug.Log(transform.rotation.eulerAngles.y);
	}
	public void RotateDoorUnClock()
	{
		if(transform.rotation.eulerAngles.y > MinAngel)
		{
			Vector3 pointVec = transform.localPosition;
			transform.RotateAround(pointVec, transform.up, -test);
		}
		Debug.Log(transform.rotation.eulerAngles.y);
	}
}
