using UnityEngine;
using System.Collections;

public class NodeSpeed : MonoBehaviour 
{
	public float m_Speed = 0.5f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public float GetSpeed()
	{
		return m_Speed;
	}
}
