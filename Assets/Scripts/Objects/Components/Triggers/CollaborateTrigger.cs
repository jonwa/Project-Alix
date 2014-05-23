using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
/* Discription: ObjectComponent class for interactions between two specific objects
 * 
 * Created by: Robert Datum: 08/04/14
 * Modified by: Jimmy Datum 14/04/14
 * Modified by: Sebastian Datum 23/04/14: Changed the raycast to cast from the camera, and changed GetButtonDown to GetButtonUp
 * Modified by: Jon Wahlstrom 2014-04-29 "added functionallity for collaborate hover effect"
 */
[RequireComponent(typeof(PickUp))]
public class CollaborateTrigger : ObjectComponent
{
	#region PublicMemberVariables
	private List<int>	m_ValidId = new List<int>();
	private string		m_Input;
	#endregion

	void Start()
	{
		SuperTrigger[] triggerArray;
		triggerArray = gameObject.GetComponents<SuperTrigger>();
		foreach(SuperTrigger c in triggerArray)
		{
			if(c.CollaborateSelf){
				m_ValidId = c.m_IDsCollaborate;
				m_Input = c.m_CollaborateInput;
			}
		}
	}

	public override void Interact ()
	{
		RaycastHit hit;
		Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		Debug.DrawRay (ray.origin, ray.direction * Camera.main.gameObject.GetComponent<Raycasting>().m_Distance, Color.green);

		if(Input.GetButtonDown(m_Input))
		{
			// change m_Distance
			if(Physics.Raycast (ray, out hit, Camera.main.gameObject.GetComponent<Raycasting>().m_Distance, Camera.main.gameObject.GetComponent<Raycasting>().m_LayerMask.value))
			{
				ObjectComponent hoover = hit.collider.gameObject.GetComponent<ObjectComponent>();
				if(hoover.gameObject.GetComponent<Id>() != null)
				{
					int collisionId = hoover.gameObject.GetComponent<Id>().ObjectId;
					if(m_ValidId.Contains(collisionId) && hoover != null)
					{
						Camera.main.GetComponent<Raycasting>().ShowCollaborateHover = true;
					
						if(hoover.gameObject.GetComponent<SuperTrigger>())
						{
							SuperTrigger[] triggerArray;
							triggerArray = hoover.gameObject.GetComponents<SuperTrigger>();
							foreach(SuperTrigger c in triggerArray)
							{
								if(c.CollaborateGet){
									c.ActivateTriggerEffect();
								}
							}
						}
						if(gameObject.GetComponent<SuperTrigger>())
						{
							SuperTrigger[] triggerArray;
							triggerArray = gameObject.GetComponents<SuperTrigger>();
							foreach(SuperTrigger c in triggerArray)
							{
								if(c.CollaborateSelf){
									c.ActivateTriggerEffect();
								}
							}
						}
					}
				}
			}
		}
		else
		{
			// change m_Distance
			if(Physics.Raycast (ray, out hit, Camera.main.gameObject.GetComponent<Raycasting>().m_Distance, Camera.main.gameObject.GetComponent<Raycasting>().m_LayerMask.value))
			{
				ObjectComponent hoover = hit.collider.gameObject.GetComponent<ObjectComponent>();
				if(hoover.gameObject.GetComponent<Id>() != null)
				{
					int collisionId = hoover.gameObject.GetComponent<Id>().ObjectId;
				
					if(m_ValidId.Contains(collisionId) && hoover != null)
					{
						Camera.main.GetComponent<Raycasting>().ShowCollaborateHover = true;
					}
				}
				else
				{
					Camera.main.GetComponent<Raycasting>().ShowCollaborateHover = false;
				}
			}
			else
			{
				Camera.main.GetComponent<Raycasting>().ShowCollaborateHover = false;
			}
		}

	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
