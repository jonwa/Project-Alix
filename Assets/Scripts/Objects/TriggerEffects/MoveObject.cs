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
	public bool 		m_Lerp;
	public Vector3[] 	m_Locations;
	public float		m_LerpSpeed;
	#endregion

	#region PrivateMemberVariables
	private bool 	m_Active;
	private int 	m_deActivteCounter;
	private int 	m_Counter;
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

	public void ReLocate(){
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
	
	override public string Name
	{ get{return"MoveObject";}}
	
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
