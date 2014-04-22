using UnityEngine;
using System.Collections;

public class CheckPlayer : MonoBehaviour 
{
	public GameObject m_Player;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = m_Player.transform.position + new Vector3(-55, 0, 0);
	}
}
