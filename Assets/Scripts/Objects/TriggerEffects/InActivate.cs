using UnityEngine;
using System.Collections;

/* Discription: Trigger components for inactivating the Object
 * Created by: Robert 23/04-14
 * Modified by: 
 * 
 */
[RequireComponent(typeof(State))]
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
	
	public override void Serialize(ref JSONObject jsonObject)
	{
		JSONObject jObject = new JSONObject(JSONObject.Type.OBJECT);
		jsonObject.AddField(Name, jObject);
		jObject.AddField("m_IsActive", m_IsActive);
	}
	public override void Deserialize(ref JSONObject jsonObject){}
}
