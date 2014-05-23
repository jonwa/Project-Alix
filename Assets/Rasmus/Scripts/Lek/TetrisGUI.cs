using UnityEngine;
using System.Collections;

public class TetrisGUI : MonoBehaviour 
{
	public GUITexture m_NextBlock;
	public GUIText    m_Tetris;
	public GUIText    m_Next;
	public GUIText    m_Score;
	public GUIText    m_ShowLevel;
	public GUIText    m_NextLevel;
	public Texture[]  m_Blocks;
	public GameObject m_Game;
	public GameObject m_RowControl;

	private int m_HighScore = 0;
	private int m_Level		= 0;
	private int m_RowsLeft  = 10;

	// Use this for initialization
	void Start () 
	{
		m_Score.text = m_HighScore.ToString();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void SetNextBlock(int block)
	{
		m_NextBlock.texture = m_Blocks[block];
	}

	public void AddScore(int score)
	{
		m_Level 		 = m_Game.GetComponent<GravityControl>().GetLevel();
		m_ShowLevel.text = m_Level.ToString();
		m_RowsLeft       = 10 - m_RowControl.GetComponent<TetrisRowDestroy>().GetRowsTaken();
		if(m_Level != 10)
		{
			if(m_RowsLeft != 1)
			{
				m_NextLevel.text = m_RowsLeft.ToString() + " rows";
			}
			else
			{
				m_NextLevel.text = m_RowsLeft.ToString() + " row";
			}
		}
		else
		{
			m_NextLevel.text = "Over 9000!";
		}

		if(score == 1)
		{
			m_HighScore += 40 * (m_Level + 1);
		}
		else if(score == 2)
		{
			m_HighScore += 100 * (m_Level + 1);
		}
		else if(score == 3)
		{
			m_HighScore += 300 * (m_Level + 1);
		}
		else if(score == 4)
		{
			m_HighScore += 1200 * (m_Level + 1);
		}

		m_Score.text = m_HighScore.ToString();
	}

	public void AddScore2(int score)
	{
		m_HighScore += score;

		m_Score.text = m_HighScore.ToString();
	}
}
