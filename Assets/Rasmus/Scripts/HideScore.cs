using UnityEngine;
using System.Collections;

public class HideScore : MonoBehaviour 
{
	public GameObject one;
	public GameObject two;
	public GameObject three;
	public float m_TimePerRound;

	private int   m_Score;
	private float m_GameTime;
	private bool  m_Game = false;
	// Use this for initialization
	void Start () 
	{
		m_GameTime = m_TimePerRound;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(m_Game)
		{
			if(m_GameTime > 0)
			{
				m_GameTime -= Time.deltaTime;
			}
			else
			{
				Debug.Log("Game over! Total score: " + m_Score);
				m_Score = 0;
				m_GameTime = m_TimePerRound;
				one.SendMessage("Restart");
				two.SendMessage("Restart");
				three.SendMessage("Restart");
				m_Game = false;
			}
		}
	}

	public void AddScore()
	{
		m_Score++;
	}

	public void RestartGame()
	{
		if(m_Game == false)
		{
			m_Game = true;
		}
	}
}
