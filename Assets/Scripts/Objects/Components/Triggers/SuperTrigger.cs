using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SuperTrigger : ObjectComponent 
{
	#region TriggerTypes
	public bool m_CollaborateSelf;
	public List<int> m_IDsCollaborate;
	public string m_CollaborateInput = "Fire1";

	public bool m_CollaborateGet;

	public bool m_TriggerSelf;
	public List<int> m_IDsTrigger;

	public bool m_TriggerGet;

	public bool m_Time;
	public int 	m_TimeDelay;

	public bool m_Collision;

	public bool m_Multiple;
	public List<int> m_IDsMulti;

	public bool m_Button;
	public List<int> m_IDsButton;

	public bool m_Padlock;
	public List<int> m_IDsPadlock;
	#endregion

	#region FirstList
	public  List<string> m_MessageAlways = new List<string>();
	public  List<bool> 	 m_TriggerOnce 	 = new List<bool>();	
	private List<bool> 	 m_HasTriggered	 = new List<bool>();
	#endregion
	
	#region
	public List<string> m_MessageCount = new List<string>();
	public List<int>	m_CounterValue = new List<int>();
	#endregion
	
	void Start()
	{
		m_HasTriggered.Capacity = m_MessageAlways.Count;
		for(int i = 0; i < m_HasTriggered.Count; i++)
		{		
			m_HasTriggered[i] = false;
		}
		if (m_CollaborateSelf) {
			gameObject.AddComponent<CollaborateTrigger>();
		}
		if (m_TriggerSelf) {
			gameObject.AddComponent<Triggering>();
		}
		if (m_Time) {
			gameObject.AddComponent<TimeTrigger>();
		}
		if (m_Collision) {
			gameObject.AddComponent<CollisionTrigger>();
		}
		if (m_Multiple) {
			gameObject.AddComponent<MultipleCollaborationTrigger>();
		}
		if (m_Button) {
			gameObject.AddComponent<ButtonTrigger>();
		}
		if (m_Padlock) {
			gameObject.AddComponent<PadlockTrigger>();
		}
	}

	public bool CollaborateGet
	{get { return m_CollaborateGet; }}

	public bool CollaborateSelf
	{get { return m_CollaborateSelf; }}

	public bool TriggerGet
	{get { return m_TriggerGet; }}

	public bool TriggerSelf
	{get { return m_TriggerSelf; }}

	public bool Time
	{get { return m_Time; }}

	public bool Collision
	{get { return m_Collision; }}

	public bool Multiple
	{get { return m_Multiple; }}

	public bool Button
	{get { return m_Button; }}

	public bool Padlock
	{get { return m_Padlock; }}
	
	private void ActivateTriggerAlways()
	{
		for(int i=0; i<m_MessageAlways.Count; i++)
		{
			if(m_TriggerOnce[i])
			{
				if(!m_HasTriggered[i])
				{
					ActivateSendMessage(m_MessageAlways[i]);
					m_HasTriggered[i] = true;
				}
			}
			else
			{
				ActivateSendMessage(m_MessageAlways[i]);
			}
		}
	} 

	private void ActivateTriggerCounter()
	{

		for(int i=0; i<m_MessageCount.Count; i++)
		{
			if(m_TriggerOnce[i])
			{
				if(!m_HasTriggered[i])
				{
					ActivateSendMessage(m_MessageCount[i]);
					m_HasTriggered[i] = true;
				}
			}
			else
			{
				ActivateSendMessage(m_MessageCount[i]);
			}
		}
	}
	
	private void ActivateSendMessage(string message)
	{
		if(message == "Activate")
		{
			gameObject.GetComponent<ActivateDeactivate>().Activate();
			if(gameObject.GetComponent<CheckTrigger>() != null)
			{
				gameObject.GetComponent<CheckTrigger>().Trigger();
			}
		}
		else
		{
			SendMessage(message);
		}
	}
	
	public void ActivateTriggerEffect()
	{
		ActivateTriggerAlways();
		ActivateTriggerCounter();
	}


	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
