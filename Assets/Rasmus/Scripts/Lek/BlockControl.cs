using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour 
{
	public GameObject[] m_Blocks;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void UpdateGravity()
	{
		for(int i=0; i<m_Blocks.Length; i++)
		{
			m_Blocks[i].GetComponent<SingleBlock>().FallOneStep();
		}
	}

	public void StopBlocks()
	{
		for(int i=0; i<m_Blocks.Length; i++)
		{
			m_Blocks[i].GetComponent<SingleBlock>().FallOneStep();
		}
	}
}
