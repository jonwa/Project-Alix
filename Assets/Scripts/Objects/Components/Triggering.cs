using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*Class for triggering something in a remote object

Made By: Rasmus 08/04
 */

public class Triggering : ObjectComponent {
	#region PublicMemberVariables
	public int[]  m_Triggers;
	public string m_Input 	 	= "q";
	public bool   m_ActivateAll = false;
	#endregion
	
	#region PrivateMemberVariables
	private int 		 m_ArrayPosition = 0;
	private bool[] 		 m_Allowed;
	private GameObject[] m_GameObjects   = null;
	GameObject[] 		 tempArray		 = null;
	#endregion

	// Use this for initialization
	void Start () 
	{
		if(m_GameObjects == null)
		{
			m_Allowed 		= new bool[m_Triggers.Length];
			tempArray 		= FindGameObjectsWithLayer(9);
			m_GameObjects 	= new GameObject[m_Triggers.Length];
			MakeGameObjectList(tempArray);

			for(int  i= 0; i < m_Triggers.Length; i++)
			{
				m_Allowed[i] = m_GameObjects[i].GetComponent<TriggerEffect>().GetAllowedTriggering();
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public override void Interact ()
	{
		if(Input.GetKeyDown(m_Input))
		{
			ActivateTrigger();
		}
	}

	//Will send activition to one or all TriggerID, if unlocked
	public void ActivateTrigger()
	{
		//Gather new values in case of change
		for(int i = 0; i < m_Triggers.Length; i++)
		{
			m_Allowed[i] = m_GameObjects[i].GetComponent<TriggerEffect>().GetAllowedTriggering();
		}

		if(m_ActivateAll == true)
		{
			for(int i = 0; i < m_Triggers.Length; i++)
			{
				if(m_Allowed[i] == true)
				{
					m_GameObjects[i].GetComponent<TriggerEffect>().ActivateTriggerEffect();
				}
			}
		}
		else
		{
			if(m_Allowed[m_ArrayPosition] == true)
			{
				m_GameObjects[m_ArrayPosition].GetComponent<TriggerEffect>().ActivateTriggerEffect();
			}
		}
	}

	//Set target to another trigger in list, returns true of targetID is in the list
	public bool SetTrigger(int mTriggerToActivate)
	{
		bool triggerfound = false;
		for(int i=0; i<m_Triggers.Length; i++)
		{
			if(m_Triggers[i] == mTriggerToActivate)
			{
				triggerfound 	= true;
				//m_TriggerID=mTriggerToActivate;
				m_ArrayPosition = i;
			}
		}
		return triggerfound;
	} 
	
	public void ActivateAll(bool bo)
	{
		m_ActivateAll = bo;
	}

	//Picks out the gameObject that match the m_Triggers ID
	private void MakeGameObjectList(GameObject[] tempArray)
	{
		int arrayInt = 0;
		for(int i = 0; i < m_Triggers.Length; i++)
		{
			for(int j = 0; j < tempArray.Length; j++)
			{
				if(tempArray[j].gameObject.GetComponent<Id>() != null){
					if(m_Triggers[i] == tempArray[j].gameObject.GetComponent<Id>().ObjectId)
					{
						m_GameObjects[arrayInt] = tempArray[j];
						arrayInt++;
					}
				}
			}
		}
	}

	//Look for gameObject on a layer
	private GameObject[] FindGameObjectsWithLayer (int layer) 
	{
		GameObject[] goArray 	= FindObjectsOfType(typeof(GameObject)) as GameObject[];
		List<GameObject> goList = new List<GameObject>();
		int test 				= 0;
		for (int i = 0; i < goArray.Length; i++) 
		{
			if (goArray[i].layer == layer) 
			{
				goList.Add(goArray[i]);
				test++;
			}
		}

		if(goList == null)
		{
			return null;
		}
		return goList.ToArray();
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}









