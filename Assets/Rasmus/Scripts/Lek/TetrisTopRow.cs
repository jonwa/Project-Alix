using UnityEngine;
using System.Collections;

public class TetrisTopRow : MonoBehaviour 
{
	public GameObject m_Game;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnTriggerStay(Collider col)
	{
		if(col.tag == "Blocks")
		{
			if(col.GetComponent<SingleBlock>().GetFalling() == false)
			{
				m_Game.GetComponent<GravityControl>().EndGame();
			}
		}
	}
}
