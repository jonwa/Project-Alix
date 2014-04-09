using UnityEngine;
using System.Collections;

/*Class used when a object is called from another object.
m_Message should be a command the object send to his component for the right effect
Made by: Rasmus 08/04
 */

public class TriggerEffect : ObjectComponent 
{
	#region PublicMemberVariables
	public string m_Message = "Effect";
	#endregion
	
	#region PrivateMemberVariables
	#endregion
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void ActivateTrigger()
	{
		if(m_Message.Equals("Effect"))
		{
			Debug.Log("Fått en triggereffekt");
		}
		else
		{
			BroadcastMessage(m_Message);
		}
	}
}
