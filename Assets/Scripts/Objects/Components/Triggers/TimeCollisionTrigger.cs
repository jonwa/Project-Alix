using UnityEngine;
using System.Collections;

/* Discription: TimeCollisionTrigger
 * Trigger other objects after T seconds
 * 
 * Created by: Sebastian Olsson 29-04-14
 * Modified by:
 */

[RequireComponent(typeof(BoxCollider))]
public class TimeCollisionTrigger : ObjectComponent 
{
	#region PrivateMemberVariables
	private bool m_Active = false;
	private float m_StartTime;
	private float m_Time;
	private Id[]  m_ObjectIds;
	private Id[]  m_FoundIDs;
	private bool  m_HasTriggered = false;
	#endregion
	
	#region PublicMemberVariables
	public float m_TriggerTime;
	public int[] m_IDs;
	public bool m_TriggerOnce;
	#endregion

	void Start () 
	{
		collider.isTrigger = true;
		m_ObjectIds = Object.FindObjectsOfType<Id>();
		m_FoundIDs = new Id[m_IDs.Length];
	}

	void Update()
	{
		if (m_Active) 
		{
			m_Time = Time.time - m_StartTime;
			if(m_Time >= m_TriggerTime)
			{
				GetIDsToTrigger(m_FoundIDs);
				foreach(Id id in m_FoundIDs)
				{
					id.GetComponent<TriggerEffect>().ActivateTriggerEffect();
					//id.gameObject.GetComponent<CheckTrigger>().Trigger();
					m_HasTriggered = true;
				}
				m_Active = false;
			}
		}
	}

	void GetIDsToTrigger(Id[] p_FoundIDs)
	{
		int arraySize = 0;
		Debug.Log ("Trigger Collision");
		foreach(Id id in m_ObjectIds)
		{
			foreach(int i in m_IDs)
			{
				if(i != null)
				{
					if(i == id.ObjectId)
					{
						p_FoundIDs[arraySize] = id;
						arraySize++;
					}
				}
			}
		}
	}

	void OnTriggerEnter()
	{
		m_StartTime = Time.time;
		if (!m_Active) 
		{
			Start ();
			m_Active = true;
		}
	}

	void OnTriggerExit()
	{
		if(m_Active)
		{
			m_Active = false;
		}
	}
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
