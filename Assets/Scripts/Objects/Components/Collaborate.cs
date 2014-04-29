using UnityEngine;
using System.Collections;
using System.Linq;
/* Discription: ObjectComponent class for interactions between two specific objects
 * 
 * Created by: Robert Datum: 08/04/14
 * Modified by: Jimmy Datum 14/04/14
 * Modified by: Sebastian Datum 23/04/14: Changed the raycast to cast from the camera, and changed GetButtonDown to GetButtonUp
 * Modified by: Jon Wahlstrom 2014-04-29 "added functionallity for collaborate hover effect"
 */
[RequireComponent(typeof(PickUp))]
public class Collaborate : ObjectComponent
{
	#region PublicMemberVariables
	public int[]	m_ValidId;
	public string	m_Input = "Fire1";
	#endregion
	
	#region PrivateMemberVariables
	#endregion
	

	//void CheckCollision(GameObject obj)
	//{
	//
	//	int collisionId = obj.GetComponent<Id>().ObjectId;
	//	if(m_ValidId.Contains(collisionId))
	//	{
	//		obj.GetComponent<TriggerEffect>().ActivateTrigger();
	//	}
	//}
	//
	//void OnCollisionEnter(Collision Hit)
	//{
	//	CheckCollision(Hit.collider.gameObject);
	//}
	void Update()
	{

	}

	public override void Interact ()
	{
		RaycastHit hit;
		Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		Debug.DrawRay (ray.origin, ray.direction * Camera.main.gameObject.GetComponent<Raycasting>().m_Distance, Color.green);

		if(Input.GetButtonUp(m_Input))
		{
			// change m_Distance
			if(Physics.Raycast (ray, out hit, Camera.main.gameObject.GetComponent<Raycasting>().m_Distance, Camera.main.gameObject.GetComponent<Raycasting>().m_LayerMask.value))
			{
				ObjectComponent hoover = hit.collider.gameObject.GetComponent<ObjectComponent>();
				int collisionId = hoover.gameObject.GetComponent<Id>().ObjectId;
				if(m_ValidId.Contains(collisionId) && hoover != null)
				{
					Camera.main.GetComponent<Raycasting>().ShowCollaborateHover = true;

					if(hoover.gameObject.GetComponent<TriggerEffect>())
					{
						hoover.gameObject.GetComponent<TriggerEffect>().ActivateTriggerEffect();
					}
					if(gameObject.GetComponent<TriggerEffect>())
					{
						gameObject.GetComponent<TriggerEffect>().ActivateTriggerEffect();
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

	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
