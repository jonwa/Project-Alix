using UnityEngine;
using System.Collections;

public class RestartWallJumpGrej : MonoBehaviour {
	public GameObject m_player;
	public Vector3 m_startpos;
	// Use this for initialization
	void Start () {
		m_startpos = m_player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("r")) 
		{
			m_player.transform.position = m_startpos;
		}
	}

	public void NewStartPoint(Vector3 pos)
	{
		m_startpos = pos;
	}
}
