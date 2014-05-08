using UnityEngine;
using System.Collections;

public class SingleBlock : MonoBehaviour 
{
	private bool falling = true;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void stopFalling()
	{
		falling = false;
	}

	public void FallOneStep()
	{
		Vector3 nextMove = transform.position;
		nextMove.y -= gameObject.transform.collider.bounds.size.x;
		if(falling == true)
		{
			transform.position = nextMove;
		}
	}
}
