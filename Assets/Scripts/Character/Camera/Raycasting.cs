﻿using UnityEngine;
using System.Collections;


/* Casts a ray from the Objects position in the forward direction of the object
 * until it hits an object with ObjectComponent's then activates Interact on that object.
 * 
 * Created by: Sebastian / Jimmy  Date: 2014-04-04
 * Modified by:
 * 
 */

public class Raycasting : MonoBehaviour {

	#region PublicMemberVariables
	public float  		m_Distance  = 10;
	public string 		m_Input	 	= "Fire1";
	public LayerMask	m_LayerMask = (1<<9);
	#endregion
	#region PrivateMemberVariables
	private GameObject m_InteractingWith;
	#endregion

	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButton(m_Input) && m_InteractingWith == null)
		{
			Cast ();
		}
		else if(Input.GetButton(m_Input) && m_InteractingWith != null)
		{
			ObjectComponent[] objectArray;
			objectArray = m_InteractingWith.GetComponents<ObjectComponent>();
			foreach(ObjectComponent c in objectArray)
			{
				c.Interact();
			}
		}
		else
		{
			m_InteractingWith = null;
		}
	}

	public void Cast()
	{
		RaycastHit hit;
		Ray ray = new Ray(transform.position, transform.forward);
		Debug.DrawRay (ray.origin, ray.direction * m_Distance, Color.yellow);

		if (Physics.Raycast (ray, out hit, m_Distance, m_LayerMask.value))
		{
			m_InteractingWith = hit.collider.gameObject;
			ObjectComponent[] objectArray;
			objectArray = m_InteractingWith.GetComponents<ObjectComponent>();
			Debug.Log("Träffade " + m_InteractingWith.name.ToString() + objectArray.Length.ToString());
			foreach(ObjectComponent c in objectArray)
			{
				c.Interact();
			}
		}

	}
}
