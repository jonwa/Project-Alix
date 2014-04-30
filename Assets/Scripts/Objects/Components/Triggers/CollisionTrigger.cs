using UnityEngine;
using System.Collections;

/* If player collide with the gameObject Trigger, start the triggereffects on gameObject

	Made By: Rasmus 30/4
 */

public class CollisionTrigger : MonoBehaviour {
	#region PrivateMemberVariables
	private bool m_HasTriggered = false;
	#endregion
	
	#region PublicMemberVariables
	public string[] m_Messages;
	public bool m_TriggerOnce;
	#endregion
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnTriggerEnter()
	{
		if(m_HasTriggered == false)
		{
			ActivateTriggerEffect();
			if(m_TriggerOnce == true)
			{
				m_HasTriggered = true;
			}
		}
	}

	public void ActivateTriggerEffect()
	{
		for(int i = 0; i < m_Messages.Length; i++){
			if(m_Messages[i].Equals("Effect"))
			{
				Debug.Log("Fått en triggerEffect");
			}
			else
			{
				SendMessage(m_Messages[i]);
				
			}
		}
	}
}
