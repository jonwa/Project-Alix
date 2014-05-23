using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using System.Linq;
/* 
 * 
 * Created By: Jon Wahlström 2014-05-01
 * Modified By: 
 */

public class PadlockTrigger : ObjectComponent 
{
	#region PublicMemberVariables
	public int 			m_CorrectCode;
	public GameObject[] m_PadlockNumbers;
	#endregion

	private int InputCode
	{
		get
		{
			int i = 0; 
			int number = 0;
			foreach(GameObject go in m_PadlockNumbers)
			{
				if(i == 0)
					number += int.Parse(go.GetComponentInChildren<UILabel>().text) * 1000;
				else if(i == 1)
					number += int.Parse(go.GetComponentInChildren<UILabel>().text) * 100;
				else if(i == 2)
					number += int.Parse(go.GetComponentInChildren<UILabel>().text) * 10;
				else if(i == 3)
					number += int.Parse(go.GetComponentInChildren<UILabel>().text) * 1;

				++i;
			}
			return number;
		}
	}

	void OnClick()
	{
		if(InputCode == m_CorrectCode)
		{
			GameObject p = transform.parent.gameObject;
			GameObject pp = p.transform.parent.gameObject;
			GameObject ppp = pp.transform.parent.gameObject;

			WindowStatus status = ppp.GetComponent<WindowStatus>();
			bool isActive = InputManager.RequestShowWindow(ppp);
			status.Activate((isActive == true) ? true : false);

			ActivateTrigger();
		}
		else
		{
			Debug.Log("Corr " + m_CorrectCode + " Input " + InputCode);
		}
	}

	//Will send activition to all TriggerID
	void ActivateTrigger()
	{
		SuperTrigger[] triggerArray;
		triggerArray = gameObject.GetComponents<SuperTrigger>();
		foreach(SuperTrigger c in triggerArray)
		{
			if(c.Multiple){
				c.ActivateTriggerEffect();
			}
		}
	}
	
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
