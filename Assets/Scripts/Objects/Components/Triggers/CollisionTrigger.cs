using UnityEngine;
using System.Collections;

/* If player collide with the gameObject Trigger, start the triggereffects on gameObject

	Made By: Rasmus 30/4
 */

public class CollisionTrigger : MonoBehaviour {	
	public void OnTriggerEnter()
	{
		if(gameObject.GetComponent<SuperTrigger>())
		{
			SuperTrigger[] triggerArray;
			triggerArray = gameObject.GetComponents<SuperTrigger>();
			foreach(SuperTrigger c in triggerArray)
			{
				if(c.Collision){
					c.ActivateTriggerEffect();
				}
			}
		}
	}
}
