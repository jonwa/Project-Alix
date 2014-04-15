using UnityEngine;
using System.Collections;

/*Class for Locking/unlocking

Made By: Rasmus 08/04
 */

public class Locked : ObjectComponent 
{
	#region PublicMemberVariables
	public bool m_LockedFromStart = true;
	#endregion
	
	#region PrivateMemberVariables
	private bool m_Locked;
	#endregion


	// Use this for initialization
	void Start() 
	{
		if(m_LockedFromStart == true)
		{
			m_Locked = true;
		}
		else
		{
			m_Locked = false;
		}
	}
	
	// Update is called once per frame
	void Update() 
	{
		//Remove after testing
		m_Locked = m_LockedFromStart;
	}

	public void Lock()
	{
		m_Locked = true;
	}
	public void UnLock()
	{
		m_Locked = false;
	}

	public bool GetLocked()
	{
		return m_Locked;
	}
}
