using UnityEngine;
using System.Collections;

/* Discription: Trigger component for moving the object
 * Created by: Robert 23/04-14
 * Modified by: 
 * 
 */

public class MoveObject :  TriggerComponent
{
	#region PublicMemberVariables
	public bool 		m_HideAndSeek = false ;
	public bool 		m_Lerp;
	public Vector3[] 	m_Locations;
	public float		m_LerpSpeed;
	#endregion

	#region PrivateMemberVariables
	private bool 	m_Active = false;
	private int 	m_deActivteCounter;
	private int 	m_Counter = 0;
	private bool 	m_InSight = true;
	#endregion

	void Update()
	{
		if(m_Active)
		{
			ReLocate();
		}
		else if(m_deActivteCounter > 100)
		{
			m_Active = false;
		}
	}

	public void ReLocate()
	{
		if(!m_HideAndSeek)
		{
			if (m_Lerp)
			{
				m_Active = true;
				if(m_Counter < m_Locations.Length)
				{
					transform.position =  Vector3.Lerp(transform.position, m_Locations[m_Counter],m_LerpSpeed);
					m_deActivteCounter = 0;
					if(Vector3.Distance(transform.position, m_Locations[m_Counter])< 0.01)
					{
						m_Counter ++;
					}
				}
			}
			else if(!m_Lerp)
			{
				if(m_Counter < m_Locations.Length)
				{
					transform.position = m_Locations[m_Counter];
					m_Counter ++;
				}
			}
		}
		else
		{
			Debug.Log("ReLocate with hide n seek");
			if(m_InSight)
			{
				transform.GetComponent<Gravity>().m_Gravity = false; 
				if(transform.GetComponent<PickUp>())
				{
					transform.localScale = transform.GetComponent<PickUp>().OriginalScale;
					
					transform.GetComponent<PickUp>().enabled = false;
				}
				if(transform.parent != null)
				{
					transform.localPosition = m_Locations[0];
				}
				else
				{
					transform.position = m_Locations[0];
				}
				Debug.Log("Changed position to: " + m_Locations[0]);
				m_InSight = !m_InSight;
			}
			else
			{
				if(transform.parent != null)
					transform.localPosition = m_Locations[1];
				else
					transform.position = m_Locations[1];

				transform.GetComponent<Gravity>().m_Gravity = true;
				if(transform.GetComponent<PickUp>())
				{
					transform.GetComponent<PickUp>().enabled = true;
				}

				Debug.Log("Changed position to: " + m_Locations[1]);


				m_InSight = !m_InSight;
			}
		}
	}
	
	override public string Name
	{ get{return"ReLocate";}}
	
	public override void Serialize(ref JSONObject jsonObject)
	{
		JSONObject jObject = new JSONObject(JSONObject.Type.OBJECT);
		jsonObject.AddField(Name, jObject);
		jObject.AddField("m_Active", m_Active);
		jObject.AddField("m_deActivteCounter", m_deActivteCounter);
		jObject.AddField("m_Counter", m_Counter);
	}
	public override void Deserialize(ref JSONObject jsonObject)
	{
		m_Active = jsonObject.GetField("m_Active").b;
		m_deActivteCounter = (int)jsonObject.GetField("m_deActivteCounter").n;
		m_Counter = (int)jsonObject.GetField("m_Counter").n;
	}
}
