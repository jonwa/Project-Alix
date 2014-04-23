using UnityEngine;
using System.Collections;

/* Discription: Trigger components for inactivating the Object
 * Created by: Robert 23/04-14
 * Modified by: 
 * 
 */

public class InActivate :  TriggerComponent
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
	{ get{return"InActivate";}}
	
	//Overload when saveing data for component.
	public virtual void Serialize(ref JSONObject jsonObject)
	{
	}
	
	//Overload when loading data for component.
	public virtual void Deserialize(ref JSONObject jsonObject)
	{
	}
}
