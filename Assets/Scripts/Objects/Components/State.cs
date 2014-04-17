using UnityEngine;
using System.Collections;

/* Discription: Objectcomponent class that sets an object ID
 * 
 * Created by: Robert Datum: 08/04-14
 * Modified by:
 * 
 */
[RequireComponent(typeof(Id))]
public class State : ObjectComponent
{

	//public string States
	//{
	//	get { return m_State; }
	//}

	public enum m_State 
	{
		 Pocket,
		 InActive,
		 Active
	}

}
