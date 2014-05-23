using UnityEngine;
using System.Collections;

/* Discription: TimeTrigger
 * After time T stuff will trigger
 * 
 * Created by: Sebastian Olsson 29-04-14
 * Modified by:
 */

public class TimeTrigger : ObjectComponent 
{
	#region PrivateMemberVariables
	private bool m_Active = false;
	private float m_StartTime;
	private float m_Time;
	private float m_TriggerTime;
	#endregion
	
	override public string Name
	{
		get{ return "StartTimer"; }
	}

	void Start(){
		SuperTrigger[] triggerArray;
		triggerArray = gameObject.GetComponents<SuperTrigger>();
		foreach(SuperTrigger c in triggerArray)
		{
			if(c.Time){
				m_TriggerTime = c.m_TimeDelay;
			}
		}
	}

	void Update () 
	{
		if (m_Active) 
		{
			Debug.Log("Time Trigger update active");
			m_Time = Time.time - m_StartTime;
			if(m_Time >= m_TriggerTime)
			{
				SuperTrigger[] triggerArray;
				triggerArray = gameObject.GetComponents<SuperTrigger>();
				foreach(SuperTrigger c in triggerArray)
				{
					if(c.Time){
						c.ActivateTriggerEffect();
					}
				}
			}
		}
	}

	void StartTimer()
	{
		m_StartTime = Time.time;
		if (!m_Active) 
		{
			m_Active = true;
		}
		else
		{
			m_Active = false;
		}
	}
	
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
