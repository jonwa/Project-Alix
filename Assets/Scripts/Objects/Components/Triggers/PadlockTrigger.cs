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
	public List<int>	m_Triggers = new List<int>();
	public GameObject[] m_PadlockNumbers;
	public bool   		m_TriggerOnce = false;
	#endregion

	#region PrivateMemberVariables
	private bool 		 m_HasTriggered	 = false;
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
			GameObject parent = transform.parent.gameObject;
			GameObject parentsParent = parent.transform.parent.gameObject;
			parentsParent.SetActive(false);
			Camera.main.GetComponent<Raycasting>().ShowHover = true; 
			Camera.main.GetComponent<FirstPersonCamera>().UnLockCamera();

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
		if(!m_HasTriggered)
		{
			List<Id> ids = Object.FindObjectsOfType<Id>().ToList();
			foreach(Id i in ids)
			{
				if(m_Triggers.Contains(i.ObjectId))
				{
					i.gameObject.GetComponent<TriggerEffect>().ActivateTriggerEffect();
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
