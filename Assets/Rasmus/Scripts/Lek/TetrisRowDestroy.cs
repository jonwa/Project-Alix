using UnityEngine;
using System.Collections;

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

	// Use this for initialization
	void Start () 
	{
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
			for(int i = m_HighRow; i < m_Rows.Length; i++)
			{
				m_Rows[i].GetComponent<TetrisRow>().MoveBlocks(m_RowsDestroyed);
			}
			m_RowDestroyed  = false;
			m_RowsDestroyed = 0;
			m_HighRow 	    = 0;
		}

		m_GUI.GetComponent<TetrisGUI>().AddScore(m_Score);
		m_Score = 0;
	}


	public void DestroyedRow(int row)
	{
		m_Score++;
		m_RowDestroyed = true;
		m_RowsDestroyed++;
		m_RowThisLevel++;

		if(row > m_HighRow)
		{
			m_HighRow = row;
		}
	}
}
