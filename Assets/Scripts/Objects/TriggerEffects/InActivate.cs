using UnityEngine;
using System.Collections;

/* Discription: Base class for triggers on objects
 * 
 * Created by: 
 * Modified by: 
 * 
 */

public class InActivate :  TriggerEffect
{
	#region PrivateMemberVariables
	private bool m_IsActive = true; 
	#endregion
	
	public void DeActivate()
	{
		m_IsActive = false;
		gameObject.SetActive (m_IsActive);
	}

	override public string Name
	{ get{return"TriggerEffect";}}
	
	//Overload when saveing data for component.
	public virtual void Serialize(ref JSONObject jsonObject)
	{
	}
	
	//Overload when loading data for component.
	public virtual void Deserialize(ref JSONObject jsonObject)
	{
	}
}
