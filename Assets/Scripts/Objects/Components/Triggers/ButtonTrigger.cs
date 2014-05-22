using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*Class for triggers on buttons in the GUI

	Made By: Robert 01/05-2014
 */

public class ButtonTrigger : ObjectComponent 
{
	#region PublicMemberVariables
	public List<int>	m_Triggers = new List<int>();
	#endregion
	
	// Use this for initialization
	void Start () 
	{
		if(gameObject.GetComponent<SuperTrigger>())
		{
			SuperTrigger[] triggerArray;
			triggerArray = gameObject.GetComponents<SuperTrigger>();
			foreach(SuperTrigger c in triggerArray)
			{
				if(c.Button)
				{
					m_Triggers = c.m_IDsTrigger;
				}
			}
		}
	}

	void OnClick()
	{
		ActivateTrigger();
	}

	//Will send activition to all TriggerID
	void ActivateTrigger()
	{
		List<Id> ids = Object.FindObjectsOfType<Id>().ToList();
		foreach(Id i in ids)
		{
			if(m_Triggers.Contains(i.ObjectId))
			{
				if(i.gameObject.GetComponent<SuperTrigger>())
				{
					SuperTrigger[] triggerArray;
					triggerArray = i.gameObject.GetComponents<SuperTrigger>();
					foreach(SuperTrigger c in triggerArray)
					{
						if(c.Button){
							c.ActivateTriggerEffect();
						}
					}
				}
			}
			
		}
	}
			
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}









