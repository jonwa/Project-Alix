using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TriggerAfterTimes : ObjectComponent 
{
	#region PublicMemberVariables
	public int m_NumberOfTimes = 1;
	public List<int> m_TriggerIds = new List<int>();
	#endregion
	#region PrivateMemberVariables
	private int m_Count = 0;
	private bool m_HasTriggered = false;
	#endregion

	public void AddToCount()
	{
		m_Count++;
		if(m_Count >= m_NumberOfTimes)
		{
			ActivateTrigger();
		}
	}

	void ActivateTrigger()
	{
		if(!m_HasTriggered)
		{
			List<Id> ids = Resources.FindObjectsOfTypeAll<Id>().ToList();
			foreach(Id i in ids)
			{
				if(m_TriggerIds.Contains(i.ObjectId))
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
	//TODO: Add save/load
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
