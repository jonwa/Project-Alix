using UnityEngine;
using System.Collections;
using System;
/* Discription: Objectcomponent class that sets an object ID
 * 
 * Created by: Robert Datum: 08/04-14
 * Modified by: Jimmy 2014-04-24
 * 
 */
[RequireComponent(typeof(Id))]
public class State : ObjectComponent
{
	#region state
	public enum state 
	{
		 Pocket,
		 InActive,
		 Active
	}

	#endregion
	#region PrivateMemberVariables
	private state m_State = state.Active;
	#endregion

	public state CurrentState
	{
		get
		{
			return m_State;
		}
		set
		{
			m_State = value;
		}
	}

	public override string Name 
	{
		get
		{
			return "State";
		}
	}


	public override void Serialize (ref JSONObject jsonObject)
	{
		JSONObject jObject = new JSONObject(JSONObject.Type.OBJECT);
		jsonObject.AddField(Name, jObject);
		jObject.AddField("m_State",m_State.ToString());
	}

	public override void Deserialize (ref JSONObject jsonObject)
	{
		switch(jsonObject.GetField("m_State").str)
		{
		case "Pocket":
			m_State = state.Pocket;
			break;
		case "InActive":
			m_State = state.InActive;
			break;
		case "Active":
			m_State = state.Active;
			break;
		default:
			Debug.LogError("Failed to deserialize State");
			break;
		}
	}

}
