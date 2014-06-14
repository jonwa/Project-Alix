using UnityEngine;
using System.Collections;

/* Discription: Generic Door Lock Script
 * Adds needed script components for locks on doors
 * 
 * Created by: George Barota 2014-05-14
 * Modified by:
 */

public class DoorLocks : MonoBehaviour
{
	#region PublicMemberVariables
	public bool m_LockStart;
	#endregion
	
	void Start()
	{
		NewLock();
		gameObject.AddComponent("LockUnlock");
	}


	private void NewLock()
	{
		Locked newLocked = (Locked)gameObject.AddComponent("Locked");
		
		newLocked.m_LockedFromStart = m_LockStart;
	}
}
