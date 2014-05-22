using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*Class for triggers on buttons in the GUI

	Made By: Robert 01/05-2014
 */

public class ButtonTrigger : ObjectComponent 
{
	void OnClick()
	{
		ActivateTrigger();
	}

	//Will send activition to all TriggerID
	void ActivateTrigger()
	{
		SuperTrigger[] triggerArray;
		triggerArray = gameObject.GetComponents<SuperTrigger>();
		foreach(SuperTrigger c in triggerArray)
		{
			if(c.Multiple){
				c.ActivateTriggerEffect();
			}
		}
	}
			
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}









