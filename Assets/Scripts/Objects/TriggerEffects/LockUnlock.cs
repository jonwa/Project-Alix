using UnityEngine;
using System.Collections;

/* Discription: Trigger components for locking or unlocking the Object
 * Created by: Robert 23/04-14
 * Modified by: 
 * 
 */
[RequireComponent(typeof(Locked))]
public class LockUnlock :  TriggerComponent
{
	public void Lock()
	{
		gameObject.GetComponent<Locked>().Lock();
	}
	public void UnLock()
	{
		gameObject.GetComponent<Locked>().UnLock();
	}
	
	override public string Name
	{ get{return"LockUnlock";}}
	
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
