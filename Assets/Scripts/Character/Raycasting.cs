using UnityEngine;
using System.Collections;

public class Raycasting : MonoBehaviour {

	public float m_Distance = 10;

	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Cast ();
	}

	public void Cast()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawRay (ray.origin, ray.direction * m_Distance, Color.yellow);

		if (Input.GetMouseButton (0))
		{
			if (Physics.Raycast (ray, out hit, m_Distance))
			{
				ObjectComponent[] objectArray;
				objectArray = hit.collider.gameObject.GetComponents<ObjectComponent>();
				Debug.Log("Träffade " + hit.collider.gameObject.name.ToString() + objectArray.Length.ToString());
				foreach(ObjectComponent c in objectArray)
				{
					c.Interact();
				}
			}
		}
	}
}
