using UnityEngine;
using System.Collections;

/* Discription: Move Component
 * 
 * Created by: Sebastian 02/04-14
 * Modified by:
 */
//
public class Move : ObjectComponent 
{
	void Start()
	{
	}

	void Update()
	{

	}
	
	public override void Interact()
	{

		//Moves the object forwards
		if (Input.GetAxis("Mouse Y") > 0) 
		{

			Debug.Log ("Rör musen upp!");
		}
		//Moves the object backwards
		if (Input.GetAxis ("Mouse Y") < 0) 
		{

			Debug.Log ("Rör musen Ner!");
		}


	}
}