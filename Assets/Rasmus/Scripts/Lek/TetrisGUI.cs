using UnityEngine;
using System.Collections;

public class TetrisGUI : MonoBehaviour 
{
	public GUITexture m_NextBlock;
	public GUIText    m_Tetris;
	public GUIText    m_Next;
	public GUIText    m_Score;
	public Texture[]  m_Blocks;

	private int m_HighScore = 0;

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
		if(score == 1)
		{
			m_HighScore += 40;
		}
		else if(score == 2)
		{
			m_HighScore += 100;
		}
		else if(score == 3)
		{
			m_HighScore += 300;
		}
		else if(score == 4)
		{
			m_HighScore += 1200;
		}

		m_Score.text = m_HighScore.ToString();
	}
}
