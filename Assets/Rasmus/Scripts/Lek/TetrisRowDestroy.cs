using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TetrisRowDestroy : MonoBehaviour
{
	public GameObject[] m_Rows;
	public GameObject   m_GUI;
	public GameObject   m_Game;

	private bool m_RowDestroyed  = false;
	private int  m_HighRow 		 = 0;
	private int  m_RowsDestroyed = 0;
	private int  m_Score         = 0;
	private int  m_RowThisLevel  = 0;
	private bool m_Special       = false;
	private int  m_SpecialRow    = 0;
	private int  m_Gap			 = 0;
	private List<int> m_List;

	// Use this for initialization
	void Start () 
	{
		m_List = new List<int>();
		for(int i = 0; i < m_Rows.Length; i++)
		{
			m_Rows[i].GetComponent<TetrisRow>().SetRow(i);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(m_RowThisLevel >= 10)
		{
			m_Game.GetComponent<GravityControl>().NextLevel();
			m_RowThisLevel = 0;
		}
	}

	public int GetRowsTaken()
	{
		return m_RowThisLevel;
	}

	void LateUpdate()
	{
		if(m_RowDestroyed == true)
		{
			CheckGap();
			if(m_Special == false)
			{
				for(int i = m_HighRow; i < m_Rows.Length; i++)
				{
					m_Rows[i].GetComponent<TetrisRow>().MoveBlocks(m_RowsDestroyed);
				}
			}
			else
			{
				m_Rows[m_SpecialRow + 1].GetComponent<TetrisRow>().MoveBlocks(m_Gap);
				m_Rows[m_SpecialRow + 2].GetComponent<TetrisRow>().MoveBlocks(m_Gap);
				for(int i = m_HighRow; i < m_Rows.Length; i++)
				{
					m_Rows[i].GetComponent<TetrisRow>().MoveBlocks(m_RowsDestroyed);
				}
			}

			m_SpecialRow    = 0;
			m_Gap			= 0;
			m_Special		= false;
			m_RowDestroyed  = false;
			m_RowsDestroyed = 0;
			m_HighRow 	    = 0;
			m_List.Clear();
		}

		m_GUI.GetComponent<TetrisGUI>().AddScore(m_Score);
		m_Score = 0;
	}

	private void CheckGap()
	{
		int[] ints = m_List.ToArray();
		if(ints.Length == 2)
		{
			if(ints[0] > ints[1])
			{
				int temp = ints[0];
				ints[0] = ints[1];
				ints[1] = temp;
			}

			if(ints[0] + 1 == ints[1])
			{

			}
			else if(ints[0] + 1 != ints[1])
			{
				m_Special = true;
				m_Gap = 1;
				m_SpecialRow = ints[0];
			}
			else if(ints[0] + 2 != ints[1])
			{
				m_Special = true;
				m_Gap = 1;
				m_SpecialRow = ints[0];
			}
		}
		else if(ints.Length == 3)
		{
			if(ints[0] > ints[1])
			{
				int temp = ints[0];
				ints[0] = ints[1];
				ints[1] = temp;
			}
			if(ints[1] > ints[2])
			{
				int temp = ints[1];
				ints[1] = ints[2];
				ints[2] = temp;
			}
			if(ints[0] > ints[1])
			{
				int temp = ints[0];
				ints[0] = ints[1];
				ints[1] = temp;
			}

			if(ints[0] + 1 == ints[1] && ints[1] + 1 == ints[2])
			{
				
			}
			else if(ints[0] + 1 != ints[1])
			{
				m_Special = true;
				m_Gap = 1;
				m_SpecialRow = ints[0];
			}
			else if(ints[1] + 1 != ints[2])
			{
				m_Special = true;
				m_Gap = 2;
				m_SpecialRow = ints[0];
			}
		}

		if(m_Special == true)
		{
			m_List.Clear();
			for(int i = 0; i < ints.Length; i++)
			{
				m_List.Add(ints[i]);
			}
		}

	}

	public void DestroyedRow(int row)
	{
		m_Score++;
		m_RowDestroyed = true;
		m_RowsDestroyed++;
		m_RowThisLevel++;
		m_List.Add(row);

		if(row > m_HighRow)
		{
			m_HighRow = row;
		}
	}
}
