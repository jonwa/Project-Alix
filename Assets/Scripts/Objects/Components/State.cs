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
<<<<<<< HEAD
	public enum m_State {
				 Pocket,
				 InActive,
				 Active
				}
	#endregion
	
	//public string States
	//{
	//	get { return m_State; }
	//}

=======
	public enum m_State 
	{
		 Pocket,
		 InActive,
		 Active
	}
	#endregion
>>>>>>> 89f2b13025e4d96d7f38c46c59d2d71cdf0c06a2

}
