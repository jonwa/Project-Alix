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

	override public string Name
	{ get{return"Locked";}}

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
<<<<<<< HEAD

=======
		//Remove after testing
		//m_Locked = m_LockedFromStart;
>>>>>>> 88f73b61168ec194da55a071ea0425aafecbf502
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
	public override void Serialize(ref JSONObject jsonObject)
	{
		JSONObject jObject = new JSONObject(JSONObject.Type.OBJECT);
		jsonObject.AddField(Name, jObject);
		jObject.AddField("m_Locked", m_Locked);
	}
	public override void Deserialize(ref JSONObject jsonObject)
	{
		m_Locked = jsonObject.GetField("m_Locked").b;
	}
}
