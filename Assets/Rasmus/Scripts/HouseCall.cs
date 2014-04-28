using UnityEngine;
using System.Collections;

public class HouseCall : MonoBehaviour 
{
	private int m_House = 0;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
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
