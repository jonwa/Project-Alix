using UnityEngine;
using System.Collections;

/* Discription: Trigger component for opening and closing doors to fixed angles
 * 
 * Created by: Robert 23/04-14
 * Modified by: 
 * 
 */

public class OpenCloseDoor :  TriggerComponent
{
	#region PublicMemberVariables
	public float m_OpenAngle;
	public float m_ClosedAngle;
	public string m_angle;
	#endregion

	public void CloseDoor()
	{
		if(gameObject.GetComponent<Locked>())
		{
			if(!gameObject.GetComponent<Locked>().GetLocked())
			{
				if(m_angle.Equals("x"))
				{
					transform.localEulerAngles = new Vector3(m_ClosedAngle,transform.localEulerAngles.y,transform.localEulerAngles.z);
				}
				if(m_angle.Equals("y"))
				{
					transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,m_ClosedAngle,transform.localEulerAngles.z);
				}
				if(m_angle.Equals("z"))
				{
					transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,m_ClosedAngle);
				}
			}
		}
	}

	public void OpenDoor()
	{
		if(gameObject.GetComponent<Locked>())
		{
			if(!gameObject.GetComponent<Locked>().GetLocked())
			{
				if(m_angle.Equals("x"))
				{
					transform.localEulerAngles = new Vector3(m_OpenAngle,transform.localEulerAngles.y,transform.localEulerAngles.z);
				}
				if(m_angle.Equals("y"))
				{
					transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,m_OpenAngle,transform.localEulerAngles.z);
				}
				if(m_angle.Equals("z"))
				{
					transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,m_OpenAngle);
				}
			}
		}
	}
	
	override public string Name
	{ get{return"OpenCloseDoor";}}
	
	//Overload when saveing data for component.
	public virtual void Serialize(ref JSONObject jsonObject)
	{
	}
	
	//Overload when loading data for component.
	public virtual void Deserialize(ref JSONObject jsonObject)
	{
	}
}
