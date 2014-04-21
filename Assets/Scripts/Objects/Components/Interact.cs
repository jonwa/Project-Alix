using UnityEngine;
using System.Collections;
using System.Linq;
/* Discription: ObjectComponent class for interactions between two specific objects
 * 
 * Created by: Robert Datum: 08/04/14
 * Modified by: Jimmy Datum 14/04/14
 * 
 */
public class Interact : ObjectComponent
{
	#region PublicMemberVariables
	public int[]	m_ValidId;
	//public string	m_Input;
	#endregion
	
	#region PrivateMemberVariables
	#endregion
	

	void CheckCollision(GameObject obj)
	{
		Debug.Log("Kommer hit1");
		if (obj.GetComponents<Id>() != null) 
		{
			Debug.Log("Kommer hit2");
			int collisionId = obj.GetComponent<Id> ().ObjectId;
			if (m_ValidId.Contains (collisionId)) 
			{
					obj.GetComponent<TriggerEffect> ().ActivateTrigger ();
				Debug.Log("Kommer hit4");
			}
		}
	}

	void OnCollisionEnter(Collision Hit)
	{
		CheckCollision(Hit.collider.gameObject);
	}
	void OnTriggerEnter(Collision hit)
	{
		Debug.Log ("TRIGGERERDDE");
	}
}
