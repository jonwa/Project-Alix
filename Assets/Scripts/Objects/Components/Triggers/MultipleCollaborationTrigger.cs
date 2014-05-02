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
	public List<int>	m_Triggers = new List<int>();

	private bool m_HasBeenTriggered = false;
	private List<int> m_Triggered = new List<int>();

	public void AddToTriggeredList(int id)
	{
		Debug.Log("GOT ADD");
		m_Triggered.Add(id);
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

		if(!m_HasBeenTriggered)
		{
			Debug.Log("SENT TO DAD!");
			Trigger();
			m_HasBeenTriggered = true;
		}
	}

	void Trigger()
	{
		//THIS SHOT WORKS PERFECTLY! REPLACE EVERYWHERE!
		List<Id> ids = Resources.FindObjectsOfTypeAll<Id>().ToList();
		foreach(Id i in ids)
		{
			if(m_Triggers.Contains(i.ObjectId))
			{
				Debug.Log("TRIGFGER SHIT!");
				i.gameObject.GetComponent<TriggerEffect>().ActivateTriggerEffect(gameObject.GetComponent<Id>().ObjectId);
			}

		}
	}

	public override void Serialize(ref JSONObject jsonObject)
	{
		JSONObject jObject = new JSONObject(JSONObject.Type.OBJECT);
		jsonObject.AddField(Name, jObject);
		jObject.AddField("m_HasBeenTriggered", m_HasBeenTriggered);


		JSONObject jTriggeredArr = new JSONObject(JSONObject.Type.ARRAY);
		jObject.AddField("m_Triggered", jTriggeredArr);
		for(int i=0; i< m_Triggered.Count; ++i)
		{
			jTriggeredArr.Add(m_Triggered[i]);
		}
	}

	public override void Deserialize(ref JSONObject jsonObject)
	{
		m_HasBeenTriggered = (bool)jsonObject.GetField("m_HasBeenTriggered").b;

		JSONObject jTriggeredArr = jsonObject.GetField("m_Triggered");
		for(int i=0; i < jTriggeredArr.list.Count; ++i)
		{
			m_Triggered.Add(((int)jTriggeredArr.list[i].n));
		}
	}

}
