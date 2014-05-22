using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SuperTrigger : ObjectComponent 
{
	#region FirstList
	public List<string> m_MessageAllways = new List<string>();
	public List<bool> m_TriggerOnce = new List<bool>();	
	private bool[] m_HasTriggered;
	#endregion
	
	#region
	public List<string> m_MessageCount = new List<string>();
	public List<
	#endregion
	
	void Start()
	{
		m_HasTriggered = new bool[m_MessageAllways.Count];
		foreach(bool b in m_HasTriggered)
		{
			b = false;
		}
	}	
	
	private void ActivateTriggerAllways()
	{
		for(int i=0; i<m_MessageAllways.Count; i++)
		{
			if( m_TriggerOnce[i])
			{
				if(!m_HasTriggered[i])
				{
					ActivateSendMessage(m_MessageAllways[i]);
					m_HasTriggered[i] = true;
				}
			}
			else
			{
				ActivateSendMessage(m_MessageAllways[i]);
			}
		}
	} 
	
	private void ActivateSendMessage(string message)
	{
		if(message == "Activate")
		{
			gameObject.GetComponent<ActivateDeactivate>().Activate();
		}
		else
		{
			SendMessage(message);
		}
	}
	
	public void ActivateTriggerEffect()
	{
		ActivateTriggerAllways();
	}


	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
