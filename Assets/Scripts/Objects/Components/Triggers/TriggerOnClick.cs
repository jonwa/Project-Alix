using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TriggerOnClick : ObjectComponent 
{
	#region PublicMemberVariables
	public List<int>	m_Triggers = new List<int>();
	public bool   		m_TriggerOnce = false;
	#endregion
	
	#region PrivateMemberVariables
	private bool 		 m_HasTriggered	 = false;
	#endregion
	
	public override void Interact()
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
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}

}
