using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*Class for triggering something in a remote object

	Made by: Jimmy 2014-05-19
  */

public class Triggering : ObjectComponent 
{
	#region PublicMemberVariables
	public List<int>	m_Triggers = new List<int>();
	public bool   		m_TriggerOnce = false;
	#endregion
	
	#region PrivateMemberVariables
	private bool 		 m_HasTriggered	 = false;
	#endregion

	void OnClick()
	{
		ActivateTrigger();
	}
	
	//Will send activition to all TriggerID
	public void ActivateTrigger()
	{
		if(!m_HasTriggered)
		{
			List<Id> ids = Resources.FindObjectsOfTypeAll<Id>().ToList();
			foreach(Id i in ids)
			{
				if(m_Triggers.Contains(i.ObjectId))
				{
					i.gameObject.GetComponent<TriggerEffect>().ActivateTriggerEffect();
					if(i.gameObject.GetComponent<CheckTrigger>() != null)
					{
						i.gameObject.GetComponent<CheckTrigger>().Trigger();
					}
					m_HasTriggered = true;
				}	
			}
		}
	}

	public override void Serialize(ref JSONObject jsonObject)
	{
		JSONObject jObject = new JSONObject(JSONObject.Type.OBJECT);
		jsonObject.AddField(Name, jObject);
		jObject.AddField("m_HasTriggered", m_HasTriggered);

		JSONObject jAllowedArr = new JSONObject(JSONObject.Type.ARRAY);
	}
	public override void Deserialize(ref JSONObject jsonObject)
	{
		m_HasTriggered = (bool)jsonObject.GetField("m_HasTriggered").b;
	}
}









