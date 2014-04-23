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

		int collisionId = obj.GetComponent<Id>().ObjectId;
		if(m_ValidId.Contains(collisionId))
		{
			obj.GetComponent<TriggerEffectOld>().ActivateTrigger();
		}
	}

	void OnCollisionEnter(Collision Hit)
	{
		CheckCollision(Hit.collider.gameObject);
	}
}
