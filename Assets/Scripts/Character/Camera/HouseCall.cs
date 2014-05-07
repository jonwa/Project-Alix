using UnityEngine;
using System.Collections;

/*Description: Script for controlling what house the player is in and what house the player targets, made for portals

Made by: Rasmus 29/04
 */

public class HouseCall : MonoBehaviour 
{
	#region PublicMemberVariables
	public int m_NumberOfHouses = 2;
	#endregion

	#region PrivateMemberVariables
	private int m_House  = 0;
	private int m_Target = 0;
	#endregion

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("t"))
		{
			if(m_Target == m_NumberOfHouses)
			{
				m_Target = 0;
			}
			else
			{
				m_Target++;
			}
		}
	}

	public int GetTargetHouse()
	{
		return m_Target;
	}

	public void SetTargetHouse(int target)
	{
		m_Target = target;
	}

	public int GetHouseCall()
	{
		return m_House;
	}

	public void SetHouseCall(int house)
	{
		m_House = house;
	}
}
