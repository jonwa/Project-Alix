using UnityEngine;
using System.Collections;

public class GravityControl : MonoBehaviour 
{
	public GameObject m_BlockControl;

	private float timer			= 0;
	private float timePerUpdate = 0.5f;
	private bool  m_Game 		= true;
	private bool  m_StartGame1  = true;
	// Use this for initialization
	void Start () 
	{

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
