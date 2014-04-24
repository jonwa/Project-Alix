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
	public float OpenAngle;
	public float ClosedAngle;
	public string angle;
	#endregion
	
	#region PrivateMemberVariables

	#endregion
	
	//public void CloseDoor()
	//{
	//	if(angle.Equals("x")){
	//		transform.localEulerAngles.x = ClosedAngle;
	//	}
	//	if(angle.Equals("y")){
	//		transform.localEulerAngles.y = ClosedAngle;
	//	}
	//	if(angle.Equals("z")){
	//		transform.localEulerAngles.z = ClosedAngle;
	//	}
	//}
	//
	//public void OpenDoor()
	//{
	//	if(angle.Equals("x")){
	//		transform.localEulerAngles.x = OpenAngle;
	//	}
	//	if(angle.Equals("y")){
	//		transform.localEulerAngles.y = OpenAngle;
	//	}
	//	if(angle.Equals("z")){
	//		transform.localEulerAngles.z = OpenAngle;
	//	}
	//}
	
	override public string Name
	{ get{return"OpenCloseDoor";}}
	
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
