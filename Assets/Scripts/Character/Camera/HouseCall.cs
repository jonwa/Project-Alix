﻿using UnityEngine;
using System.Collections;

public class HouseCall : MonoBehaviour 
{
	private int m_House  = 0;
	private int m_Target = 0;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("t"))
		{
			if(m_Target == 2)
			{
				m_Target=0;
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