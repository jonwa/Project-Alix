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
	private int m_Counter = 0;
	private int m_deActivteCounter = 0;
	private bool m_Active;
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
	
	//Overload when saveing data for component.
	public virtual void Serialize(ref JSONObject jsonObject)
	{
	}
	
	//Overload when loading data for component.
	public virtual void Deserialize(ref JSONObject jsonObject)
	{
	}
}
