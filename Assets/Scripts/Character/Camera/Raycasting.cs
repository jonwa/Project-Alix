using UnityEngine;
using System.Collections;


/* Casts a ray from the Objects position in the forward direction of the object
 * until it hits an object with ObjectComponent's then activates Interact on that object.
 * 
 * Created by: Sebastian / Jimmy  Date: 2014-04-04
 * Modified by:
 * 
 */

public class Raycasting : MonoBehaviour 
{

	#region PublicMemberVariables
	public float  		m_Distance  	 = 10;
	public string 		m_Input	 		 = "Fire1";
	public LayerMask	m_LayerMask 	 = (1<<9);
	public bool			m_HoldToInteract = false;
	#endregion
	#region PrivateMemberVariables
	private GameObject m_InteractingWith;
	#endregion

	// Update is called once per frame
	void Update () 
	{

		if(m_HoldToInteract)
		{
			HoldToInteract();
		}
		else
		{
			ClickToInteract();
		}

	}

	//Starts Interact with object when mouse button is clicked once over object and releases the object when button is pressed again
	void ClickToInteract()
	{
		if(Input.GetButtonDown(m_Input) && m_InteractingWith == null)
		{
			Cast ();
		}
		else if(Input.GetButtonDown(m_Input) && m_InteractingWith != null)
		{
			m_InteractingWith = null;
		}
		else if(m_InteractingWith != null)
		{
			if(Vector3.Distance(m_InteractingWith.transform.position,transform.position) > 5){
				m_InteractingWith = null;
			}
			else{
				ObjectComponent[] objectArray;
				objectArray = m_InteractingWith.GetComponents<ObjectComponent>();
				foreach(ObjectComponent c in objectArray)
				{
					c.Interact();
				}
			}
		}
	}

	// Calls Cast() while mouse button is hold down
	void HoldToInteract()
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

	// Invokes the Interact function on objects with ObjectComponents
	void Cast()
	{
		RaycastHit hit;
		Ray ray = new Ray(transform.position, transform.forward);
		Debug.DrawRay (ray.origin, ray.direction * m_Distance, Color.yellow);

		if (Physics.Raycast (ray, out hit, m_Distance, m_LayerMask.value))
		{
			m_InteractingWith = hit.collider.gameObject;
			ObjectComponent[] objectArray;
			objectArray = m_InteractingWith.GetComponents<ObjectComponent>();

			foreach(ObjectComponent c in objectArray)
			{
				c.Interact();
			}
		}

	}

	//Releases the grip of the object we are interacting with right now.
	public void Release()
	{
		m_InteractingWith = null;
	}

	public void Activate(GameObject go)
	{
		m_InteractingWith = go; 
	}
}
