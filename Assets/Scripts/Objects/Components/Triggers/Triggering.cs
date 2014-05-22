using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*Class for triggering something in a remote object

	Made by: Jimmy 2014-05-19
  */

public class Triggering : ObjectComponent 
{
	private List<int> m_TriggerIDs;

	void Start()
	{
		if(gameObject.GetComponent<SuperTrigger>())
		{
			SuperTrigger[] triggerArray;
			triggerArray = gameObject.GetComponents<SuperTrigger>();
			foreach(SuperTrigger c in triggerArray)
			{
				if(c.TriggerSelf)
				{
					m_TriggerIDs = c.m_IDsTrigger;
				}
			}
		}
	}
		
	//Will send activition to all TriggerID
	void ActivateTrigger()
	{
		List<Id> ids = Object.FindObjectsOfType<Id>().ToList();
		foreach(Id i in ids)
		{
			if(m_TriggerIDs.Contains(i.ObjectId))
			{
				if(i.gameObject.GetComponent<SuperTrigger>())
				{
					SuperTrigger[] triggerArray;
					triggerArray = i.gameObject.GetComponents<SuperTrigger>();
					foreach(SuperTrigger c in triggerArray)
					{
						if(c.TriggerGet){
							c.ActivateTriggerEffect();
						}
					}
				}
			}
			
		}
	}

	public override void Serialize(ref JSONObject jsonObject)
	{
	}
	public override void Deserialize(ref JSONObject jsonObject)
	{
	}
}









