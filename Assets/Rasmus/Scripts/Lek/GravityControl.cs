using UnityEngine;
using System.Collections;

public class GravityControl : MonoBehaviour 
{
	public GameObject m_BlockControl;
	public GameObject m_Score;
	public int m_Level = 0;

	private float timer			= 0;
	private float timePerUpdate = 1.1f;
	private bool  m_Game 		= false;
	private bool  m_StartGame1  = true;
	private bool  m_NewBlock    = true;
	private int   m_SoftScore   = 0;
	// Use this for initialization
	void Start () 
	{
		timePerUpdate -= (m_Level * 0.1f);
	}

	// Update is called once per frame
	void Update () 
	{
		if(m_Game == true)
		{
			if(timer < timePerUpdate)
			{
				timer += Time.deltaTime;
			}
			else
			{
				timer = 0;
				m_BlockControl.GetComponent<BlockControl>().UpdateGravity();
			}
		}
		if(Input.GetKeyDown("h"))
		{
			m_NewBlock = false;
		}
		if(Input.GetKey("h"))
		{
			if(m_NewBlock == false)
			{
				timer = timePerUpdate;
				m_SoftScore++;
			}
		}
	}

	public void NextLevel()
	{
		if(m_Level < 10)
		{
			m_Level++;
			timePerUpdate -= 0.1f;
		}
	}

	public int GetLevel()
	{
		return m_Level;
	}

	public void NewBlock()
	{
		m_NewBlock = true;
		m_Score.GetComponent<TetrisGUI>().AddScore2(m_SoftScore);
		m_SoftScore = 0;
	}

	public void EndGame()
	{
		m_Game = false;
	}

	public void StartGame()
	{
		if(m_StartGame1 == true)
		{
			m_Game = true;
			m_StartGame1 = false;
		}
	}
}
