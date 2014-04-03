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
	public float m_distance;
	Vector3 m_cameraPosition = Camera.current.transform.position;

	void Update()
	{
		Interact ();
	}
	
	public override void Interact()
	{
		RaycastHit hit;
		Ray ray = camera.ScreenPointToRay(new Vector3(200, 200, 0));
		//Ray m_objectRay = new Ray (m_cameraPosition, Vector3.forward);
		//Debug.DrawRay (ray, Vector3.forward, Color.red);
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
		
		
		if (Input.GetMouseButtonDown (0)) 
		{
			if(Physics.Raycast(ray, out hit, m_distance))
			{
				Debug.Log("Träff" + hit);
			}
		}

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