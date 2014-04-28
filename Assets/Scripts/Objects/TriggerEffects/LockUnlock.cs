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
	public void LockDoor()
	{
		gameObject.GetComponent<Locked>().Lock();
	}
	public void UnLockDoor()
	{
		gameObject.GetComponent<Locked>().UnLock();
	}
	
	override public string Name
	{ get{return"LockUnlock";}}
	
	//Overload when saveing data for component.
	public virtual void Serialize(ref JSONObject jsonObject)
	{
	}
	
	//Overload when loading data for component.
	public virtual void Deserialize(ref JSONObject jsonObject)
	{
	}
}
