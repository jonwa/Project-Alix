using UnityEngine;
using System.Collections;

/*Class used when a object is called from another object.
m_Message should be a command the object send to his component for the right effect
Made by: Rasmus 08/04
 */

public class TriggerEffect : ObjectComponent 
{
	#region PublicMemberVariables
	public string[] m_Messages;
	public int[]	m_SubMessages;
	public bool     m_AllowedFromStart = true;
	#endregion
	
	#region PrivateMemberVariables
	private bool m_CanBeTriggered;
	#endregion

	// Use this for initialization
	void Start () 
	{
		if(m_AllowedFromStart)
		{
			m_CanBeTriggered = true;
		}
		else
		{
			m_CanBeTriggered = false;
		}
	}

	public void AllowTriggering()
	{
		m_CanBeTriggered = true;
	}

	public void DisallowTriggering()
	{
		m_CanBeTriggered = false;
	}

	public bool GetAllowedTriggering()
	{
		return m_CanBeTriggered;
	}

	public void ActivateTriggerEffect()
	{
		for(int i = 0; i < m_Messages.Length; i++)
		{
			SendMessage(m_Messages[i],m_SubMessages[i]);
		}
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
