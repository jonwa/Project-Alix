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

	#region PublicMemberVariables
	public enum m_State 
	{
		 Pocket,
		 InActive,
		 Active
	}
	#endregion

}
