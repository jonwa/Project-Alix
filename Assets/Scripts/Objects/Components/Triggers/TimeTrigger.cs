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
			m_Time = Time.time - m_StartTime;
			Debug.Log (m_Time);
			if(m_Time >= m_TriggerTime)
			{
<<<<<<< HEAD
				SuperTrigger[] triggerArray;
				triggerArray = gameObject.GetComponents<SuperTrigger>();
				foreach(SuperTrigger c in triggerArray)
=======
				ActivateTimeTrigger();
				if(gameObject.GetComponent<CheckTrigger>() != null)
>>>>>>> 92beaf40a036c549a2d3df76d99f75233488c66d
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

<<<<<<< HEAD
=======
	void ActivateTimeTrigger()
	{
		if(!m_HasTriggered)
		{
			for(int i = 0; i < m_Messages.Length; i++){
				if(m_Messages[i].Equals("Effect"))
				{
					Debug.Log("Fått en triggerEffect");
				}
				else
				{
					Debug.Log("SendMessage TimeTrigger");
					SendMessage(m_Messages[i]);
					
				}
			}
		}
	}
>>>>>>> 92beaf40a036c549a2d3df76d99f75233488c66d
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
