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
	private bool m_HasTriggered = false;
	#endregion
	
	#region PublicMemberVariables
	public float m_TriggerTime;
	public string[] m_Messages;
	public bool m_TriggerOnce;
	#endregion

	
	override public string Name
	{
		get{ return "StartTimer"; }
	}

	void Update () 
	{

		if (m_Active) 
		{
			m_Time = Time.time - m_StartTime;
			Debug.Log (m_Time);
			if(m_Time >= m_TriggerTime)
			{
				ActivateTimeTrigger();
				if(gameObject.GetComponent<CheckTrigger>() != null)
				{
					gameObject.GetComponent<CheckTrigger>().Trigger();
				}
				m_HasTriggered = true;
				m_Active = false;
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
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
