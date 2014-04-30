using UnityEngine;
using System.Collections;

/* Discription: Trigger component for killing the player
 * Created by: Robert 29/04-14
 * Modified by: 
 * 
 */
public class KillPlayer :  TriggerComponent
{
	public void Kill()
	{
		
	}

	override public string Name
	{ get{return"KillPlayer";}}
	
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
