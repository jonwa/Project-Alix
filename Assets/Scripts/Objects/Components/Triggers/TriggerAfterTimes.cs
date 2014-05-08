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
		Debug.Log("Debug mothafuckah!1");
		if(m_Count >= m_NumberOfTimes && !m_HasTriggered)
		{
			m_HasTriggered = true;
			Debug.Log("Debug mothafuckah!2");
			ActivateTrigger();
		}
	}

	void ActivateTrigger()
	{

		Debug.Log("Debug mothafuckah!3");
		List<Id> ids = Resources.FindObjectsOfTypeAll<Id>().ToList();
		foreach(Id i in ids)
		{
			Debug.Log("Debug mothafuckah!4");
			if(m_TriggerIds.Contains(i.ObjectId))
			{
				Debug.Log("Debug mothafuckah!5");
				i.gameObject.GetComponent<TriggerEffect>().ActivateTriggerEffect();
				if(i.gameObject.GetComponent<CheckTrigger>() != null)
				{
					i.gameObject.GetComponent<CheckTrigger>().Trigger();
				}

			}
			
		}

	}
	//TODO: Add save/load
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
