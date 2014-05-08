using UnityEngine;
using System.Collections;

public class HideScore : MonoBehaviour 
{
	public GameObject one;
	public GameObject two;
	public GameObject three;
	public GUIText m_text;
	public float m_TimePerRound;
	public GameObject m_player;

	private Vector3 m_origPos;
	private int   m_Score;
	private float m_GameTime;
	private bool  m_Game = false;
	// Use this for initialization
	void Start () 
	{
		m_GameTime = m_TimePerRound;
		m_origPos = m_player.transform.position;
		m_text.gameObject.SetActive(false);
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
				m_text.text = "Final score: " + m_Score.ToString();
				m_text.gameObject.SetActive(true);
				m_Score = 0;
				m_player.transform.position = m_origPos;
				m_GameTime = m_TimePerRound;
				one.SendMessage("Restart");
				two.SendMessage("Restart");
				three.SendMessage("Restart");
				m_Game = false;
				Camera.main.GetComponent<CameraFilter>().UseSelectedEffect();
			}
		}	
	}

	public void AddScore()
	{
		m_Score++;
	}

	public void RestartGame()
	{
		m_text.gameObject.SetActive(false);
		if(m_Game == false)
		{
			m_Game = true;
		}
	}
}
