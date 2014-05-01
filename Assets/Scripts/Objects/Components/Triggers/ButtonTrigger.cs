﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*Class for triggering something in a remote object

Made By: Rasmus 08/04
 */

public class ButtonTrigger : ObjectComponent {
	#region PublicMemberVariables
	public List<int>	m_Triggers = new List<int>();
	public string 		m_Input 	 	= "Fire1";
	public bool   		m_TriggerOnce = false;
	#endregion
	
	#region PrivateMemberVariables
	private bool 		 m_HasTriggered	 = false;
	#endregion
	
	// Use this for initialization
	void Start () 
	{
	}

	void OnClick()
	{
		ActivateTrigger();
	}

	//Will send activition to all TriggerID
	void ActivateTrigger()
	{
		if(!m_HasTriggered)
		{
			List<Id> ids = Object.FindObjectsOfType<Id>().ToList();
			foreach(Id i in ids)
			{
				if(m_Triggers.Contains(i.ObjectId))
				{
					i.gameObject.GetComponent<TriggerEffect>().ActivateTriggerEffect(i.gameObject.GetComponent<Id>().ObjectId);
					if(i.gameObject.GetComponent<CheckTrigger>() != null)
					{
						i.gameObject.GetComponent<CheckTrigger>().Trigger();
					}
					m_HasTriggered = true;
				}
				
			}
		}
	}
			
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}








