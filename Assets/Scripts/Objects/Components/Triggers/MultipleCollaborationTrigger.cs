using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
/* Description: Trigger objects TriggerEffect when enough other triggers have been triggered...
 * 
 * Created by: Jimmy 2014-04-29
 */

public class MultipleCollaborationTrigger : ObjectComponent 
{
	public List<int>	m_NeedsToTriggerBeforeMe = new List<int>();
	
	private List<int> 	m_Triggered = new List<int>();

	public void AddToTriggeredList(int id)
	{
		m_Triggered.Add(id);
	}

	void Start()
	{
		SuperTrigger[] triggerArray;
		triggerArray = gameObject.GetComponents<SuperTrigger>();
		foreach(SuperTrigger c in triggerArray)
		{
			if(c.Multiple){
				m_NeedsToTriggerBeforeMe = c.m_IDsMulti;
			}
		}
	}

	void Update()
	{
		bool contains = false;
		foreach(int i in m_NeedsToTriggerBeforeMe)
		{
			if(m_Triggered.Contains(i))
			{
				contains = true;	
			}
			else
			{
				contains = false;
			}

			if(contains == false)
			{
				return;
			}
		}
			Trigger();
	}

	void Trigger()
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

	public override void Serialize(ref JSONObject jsonObject)
	{
		JSONObject jObject = new JSONObject(JSONObject.Type.OBJECT);
		jsonObject.AddField(Name, jObject);

		JSONObject jTriggeredArr = new JSONObject(JSONObject.Type.ARRAY);
		jObject.AddField("m_Triggered", jTriggeredArr);
		for(int i=0; i< m_Triggered.Count; ++i)
		{
			jTriggeredArr.Add(m_Triggered[i]);
		}
	}

	public override void Deserialize(ref JSONObject jsonObject)
	{
		JSONObject jTriggeredArr = jsonObject.GetField("m_Triggered");
		for(int i=0; i < jTriggeredArr.list.Count; ++i)
		{
			m_Triggered.Add(((int)jTriggeredArr.list[i].n));
		}
	}

}
