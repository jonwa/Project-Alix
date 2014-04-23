using UnityEngine;
using System.Collections;
using System;
/* Discription: Objectcomponent class that sets an object ID
 * 
 * Created by: Robert Datum: 08/04-14
 * Modified by:
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
		jObject.AddField("State",m_State.ToString());
	}

	public override void Deserialize (ref JSONObject jsonObject)
	{

		switch(jsonObject.type)
		{
		case JSONObject.Type.OBJECT:
			for(int i=0; i<jsonObject.list.Count; i++)
			{
				string key = (string)jsonObject.keys[i];
				if(key == "State")
				{
					foreach(state s in Enum.GetValues(typeof(state)))
					{
						if(jsonObject.list[i].str == s.ToString())
						{
							m_State = s;
						}
					}
				}
				//Deserialize(ref jsonObject.list[i]);
			}
			break;
		}

	}

}
