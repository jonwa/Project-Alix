﻿using UnityEngine;
using System.Collections;
using System.Linq;
/* Discription: ObjectComponent class for interactions between two specific objects
 * 
 * Created by: Robert Datum: 08/04/14
 * Modified by: Jimmy Datum 14/04/14
 * Modified by: Sebastian Datum 23/04/14: Changed the raycast to cast from the camera, and changed GetButtonDown to GetButtonUp
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
		if(Input.GetButtonUp(m_Input))
		{
			RaycastHit hit;
			Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
			Debug.DrawRay (ray.origin, ray.direction * Camera.main.gameObject.GetComponent<Raycasting>().m_Distance, Color.green);

			// change m_Distance
			if(Physics.Raycast (ray, out hit, Camera.main.gameObject.GetComponent<Raycasting>().m_Distance, Camera.main.gameObject.GetComponent<Raycasting>().m_LayerMask.value))
			{
				ObjectComponent hoover = hit.collider.gameObject.GetComponent<ObjectComponent>();
				int collisionId = hoover.gameObject.GetComponent<Id>().ObjectId;
				if(m_ValidId.Contains(collisionId) && hoover != null)
				{
					hoover.gameObject.GetComponent<TriggerEffect>().ActivateTrigger();
				}
			}
		}
	}
}