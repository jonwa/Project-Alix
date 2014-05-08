using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockControl : MonoBehaviour 
{
	public GameObject[] m_Blocks;
	public GameObject   m_StartPos;
	public GameObject   m_Messure;

	private Vector3 m_Pos;
	private float   m_Dist;
	private List<GameObject> m_List;

	// Use this for initialization
	void Start () 
	{
		m_List = new List<GameObject>();
		m_Dist = m_Messure.collider.bounds.size.x;
		m_Pos = m_StartPos.transform.position;
		m_Pos += m_StartPos.collider.bounds.size/2;
		m_Pos -= m_Messure.collider.bounds.size/2;
		m_Pos.y += m_Messure.collider.bounds.size.y;

		PlaceBlocks();
	}

	private void SpawnBlock()
	{
		m_List = new List<GameObject>(m_Blocks);
		m_List.Clear();
		m_List.Add(CreateOneBlock());
		m_List.Add(CreateOneBlock());
		m_List.Add(CreateOneBlock());
		m_List.Add(CreateOneBlock());
		m_Blocks = m_List.ToArray();

		PlaceBlocks();
	}

	private GameObject CreateOneBlock()
	{
		GameObject block = Instantiate(m_Messure) as GameObject;
		block.AddComponent<SingleBlock>();
		return block;
	}

	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("g"))
		{
			MoveLeft();
		}
		if(Input.GetKeyDown("j"))
		{
			MoveRight ();
		}
	}

	private void MoveLeft()
	{
		bool collide = false;
		for(int i=0; i<m_Blocks.Length; i++)
		{
			if(m_Blocks[i].GetComponent<SingleBlock>().GetHitLeft() == true)
			{
				collide = true;
			}
		}
		if(collide == false)
		{
			for(int i=0; i<m_Blocks.Length; i++)
			{
				m_Blocks[i].GetComponent<SingleBlock>().MoveLeft();
			}
		}
	}
	private void MoveRight()
	{
		bool collide = false;
		for(int i=0; i<m_Blocks.Length; i++)
		{
			if(m_Blocks[i].GetComponent<SingleBlock>().GetHitRight() == true)
			{
				collide = true;
			}
		}
		if(collide == false)
		{
			for(int i=0; i<m_Blocks.Length; i++)
			{
				m_Blocks[i].GetComponent<SingleBlock>().MoveRight();
			}
		}
	}

	public void UpdateGravity()
	{
		bool collide = false;
		for(int i=0; i<m_Blocks.Length; i++)
		{
			if(m_Blocks[i].GetComponent<SingleBlock>().GetColliding() == true)
			{
				collide = true;
			}
		}
		if(collide == false)
		{
			for(int i=0; i<m_Blocks.Length; i++)
			{
				m_Blocks[i].GetComponent<SingleBlock>().FallOneStep();
			}
		}
		else
		{
			StopBlocks();
		}
	}

	public void StopBlocks()
	{
		for(int i=0; i<m_Blocks.Length; i++)
		{
			m_Blocks[i].GetComponent<SingleBlock>().StopFalling();
		}
		SpawnBlock();
	}

	private void PlaceBlocks()
	{
		int shape = Random.Range(0, 5);
		//Debug.Log(shape);
		if(shape == 0)
		{
			for(int i = 0; i < m_Blocks.Length; i++)
			{
				if(i != 3)
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * (4 + i), 13 * m_Dist, 0);
				}
				else
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * (4 + 2), 12 * m_Dist, 0);
				}
			}
		}
		else if(shape == 1)
		{
			for(int i = 0; i < m_Blocks.Length; i++)
			{
				m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * 4, (12 + i) * m_Dist, 0);
			}
		}
		else if(shape == 2)
		{
			for(int i = 0; i < m_Blocks.Length; i++)
			{
				if(i != 3)
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * (4 + i), 13 * m_Dist, 0);
				}
				else
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * 4, 12 * m_Dist, 0);
				}
			}
		}
		else if(shape == 3)
		{
			for(int i = 0; i < m_Blocks.Length; i++)
			{
				if(i != 3)
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * (4 + i), 13 * m_Dist, 0);
				}
				else
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * 5, 12 * m_Dist, 0);
				}
			}
		}
		else if(shape == 4)
		{
			for(int i = 0; i < m_Blocks.Length; i++)
			{
				if(i < 2)
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * (4 + i), 13 * m_Dist, 0);
				}
				else
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * (2 + i), 12 * m_Dist, 0);
				}
			}
		}
	}
}
