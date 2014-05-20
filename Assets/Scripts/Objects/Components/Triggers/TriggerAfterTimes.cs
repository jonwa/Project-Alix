using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TriggerAfterTimes : ObjectComponent 
{
	#region PublicMemberVariables
	public int m_NumberOfTimes = 1;
	public List<int> m_TriggerIds = new List<int>();
	public List<string> m_Messages = new List<string>();
	#endregion
	#region PrivateMemberVariables
	private int m_Count = 0;
	private bool m_HasTriggered = false;
	#endregion

	public void AddToCount()
	{
		m_Count++;
		if(m_Count >= m_NumberOfTimes && !m_HasTriggered)
		{
			m_HasTriggered = true;
			ActivateTrigger();
		}
	}

	void ActivateTrigger()
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

			}
			
		}

		//HERE IS SOME STUFF AKA TriggerEffect
		for(int i = 0; i < m_Messages.Count; i++)
		{		
			if(m_Messages[i] == "Activate")
			{
				gameObject.GetComponent<ActivateDeactivate>().Activate();
			}
			else
			{
				SendMessage(m_Messages[i]);
			}
			
		}

	}
	//TODO: Add save/load
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
