using UnityEngine;
using System.Collections;


/* Casts a ray from the Objects position in the forward direction of the object
 * until it hits an object with ObjectComponent's then activates Interact on that object.
 * 
 * Created by: Sebastian / Jimmy  Date: 2014-04-04
 * Modified by: Jon Wahlström 2014-04-29 "added collaborate hover effect"
 * 
 */

public class Raycasting : MonoBehaviour 
{

	#region PublicMemberVariables
	public float  		m_Distance  	 = 3;
	public string 		m_Input	 		 = "Fire1";
	public LayerMask	m_LayerMask 	 = (1<<9);
	#endregion
	#region PrivateMemberVariables
	private GameObject m_InteractingWith;
	private bool m_Release = false;
	private bool m_ShowHover = true;
	#endregion

	// Used only for inventory swap functionallity
	public GameObject InteractingWith{ get;set;}

	public bool ShowHover
	{
		set { m_ShowHover = value; }
	}

	public bool ShowCollaborateHover { get;set; }

	// Update is called once per frame
	void Update () 
	{
		// used for mouse cursor state
		Cast (m_ShowHover);

		ClickToInteract();

		if(m_Release)
		{
			m_InteractingWith = null;
		    m_Release = false;
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
			RaycastHit hit;
			Ray ray = new Ray(transform.position, transform.forward);
			Debug.DrawRay (ray.origin, ray.direction * m_Distance, Color.yellow);
			
			if(Physics.Raycast (ray, out hit, m_Distance, m_LayerMask.value))
			{
				ObjectComponent hoover = hit.collider.gameObject.GetComponent<ObjectComponent>();

				if(m_InteractingWith.GetComponent<PickUp>() != null && m_InteractingWith.GetComponent<CollaborateTrigger>() != null && hoover != null)
				{
					ObjectComponent[] objectArray;
					objectArray = m_InteractingWith.GetComponents<ObjectComponent>();
					foreach(ObjectComponent c in objectArray)
					{
						c.Interact();
					}
				}
				if((m_InteractingWith.GetComponent<PickUp>() == null || m_InteractingWith.GetComponent<CollaborateTrigger>() == null) && hoover != null)
				{
					Release();
				}

			}
			else
			{
				Release();
			}
		}
		else if(m_InteractingWith != null)
		{
			if(Vector3.Distance(m_InteractingWith.transform.position,transform.position) > m_Distance)
			{
				Release();
			}
			else
			{
				ObjectComponent[] objectArray;
				objectArray = m_InteractingWith.GetComponents<ObjectComponent>();
				foreach(ObjectComponent c in objectArray)
				{
					c.Interact();
				}
			}
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

			//TODO:TEST
			InteractingWith = hit.collider.gameObject;

			ObjectComponent[] objectArray;
			objectArray = m_InteractingWith.GetComponents<ObjectComponent>();

			foreach(ObjectComponent c in objectArray)
			{
				c.Interact();
			}
		}
		else
		{
			InteractingWith = null;
		}
	}

	void Cast(bool showHover)
	{
		if(showHover)
		{
			RaycastHit hit;
			Ray ray = new Ray(transform.position, transform.forward);
			Debug.DrawRay (ray.origin, ray.direction * m_Distance, Color.yellow);
			
			if (Physics.Raycast (ray, out hit, m_Distance, m_LayerMask.value))
			{
				CollaborateHoverEffect collaborateHover = hit.collider.gameObject.GetComponent<CollaborateHoverEffect>();
				HoverEffect 		   hover		    = hit.collider.gameObject.GetComponent<HoverEffect>();

				// collaborate hover effect check
				if(collaborateHover != null && ShowCollaborateHover)
				{
					Cursor.SetCursor(collaborateHover.HoverTexture, collaborateHover.Description, true);
				}
				// regular hover effect check
				else if(hover != null)
				{
					if(Input.GetButton(m_Input))
					{
						if(hover.ButtonDownHoverTexture != null)
						{
							Cursor.SetCursor(hover.ButtonDownHoverTexture, hover.Description, true);
						}
						else
						{
							Cursor.SetCursor(hover.HoverTexture, hover.Description, true);
						}
					}
					else
					{
						Cursor.SetCursor(hover.HoverTexture, hover.Description, true);
					}
				}
				else
				{
					Cursor.SetCursor(null, null, true);
				}
			}
			else
			{
				Cursor.SetCursor(null, null, true);
			}
		}
		else
		{
			Cursor.SetCursor(null, null, false);
		}
	}

	//Releases the grip of the object we are interacting with right now.
	public void Release()
	{
		m_Release = true;
	}

	public void Activate(GameObject go)
	{
		m_InteractingWith = go; 
		InteractingWith = go;
	}
}
