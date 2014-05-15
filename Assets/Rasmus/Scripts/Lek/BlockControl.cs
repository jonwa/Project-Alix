using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockControl : MonoBehaviour 
{
	#region PublicVaribles
	public GameObject   m_GravityControl;
	public GameObject[] m_Blocks;
	public GameObject   m_StartPos;
	public GameObject   m_Messure;
	public GameObject   m_GUI;
	public Material[]   m_Material;
	#endregion

	#region PrivateVaribles
	private Vector3 m_Pos;
	private float   m_Dist;
	private List<GameObject> m_List;
	private int     m_NextShape;
	private int     m_CurrentShape;
	private int     m_Rot;
	private bool    m_TwoRotations;
	private int     m_TopSpawn = 18;
	#endregion

	// Use this for initialization
	void Start () 
	{
		m_List = new List<GameObject>();
		m_Dist = m_Messure.collider.bounds.size.x;
		m_Pos = m_StartPos.transform.position;
		m_Pos += m_StartPos.collider.bounds.size/2;
		m_Pos -= m_Messure.collider.bounds.size/2;
		m_Pos.y += m_Messure.collider.bounds.size.y;
		m_CurrentShape = Random.Range(0, 7);

		PlaceBlocks();
		m_GUI.GetComponent<TetrisGUI>().SetNextBlock(m_NextShape);
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
		m_GUI.GetComponent<TetrisGUI>().SetNextBlock(m_NextShape);
		m_GravityControl.GetComponent<GravityControl>().NewBlock();
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
			MoveRight();
		}
		if(Input.GetKeyDown("y"))
		{
			RotateBlocks();
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

	#region BlockRotations
	private void RotateBlocks()
	{
		if(m_TwoRotations == true)
		{
			if(m_CurrentShape == 4)
			{
				//Pretend to Rotate ;)
			}
			else if(m_CurrentShape == 1)
			{
				if(m_Rot == 0)
				{
					if(m_Blocks[2].GetComponent<SingleBlock>().GetHitLeft() == false && m_Blocks[2].GetComponent<SingleBlock>().GetHitRight() == false)
					{
						m_Rot++;
						m_Blocks[0].transform.position += new Vector3(m_Dist * 2, m_Dist * 2, 0);
						m_Blocks[1].transform.position += new Vector3(m_Dist * 1, m_Dist * 1, 0);
						m_Blocks[3].transform.position += new Vector3(m_Dist * -1, m_Dist * -1, 0);
					}
				}
				else
				{
					if(m_Blocks[2].GetComponent<SingleBlock>().GetColliding() == false)
					{
						m_Blocks[0].transform.position -= new Vector3(m_Dist * 2, m_Dist * 2, 0);
						m_Blocks[1].transform.position -= new Vector3(m_Dist * 1, m_Dist * 1, 0);
						m_Blocks[3].transform.position -= new Vector3(m_Dist * -1, m_Dist * -1, 0);
						m_Rot--;
					}
				}
			}
			else if(m_CurrentShape == 5)
			{
				if(m_Rot == 0)
				{
					if(m_Blocks[1].GetComponent<SingleBlock>().GetHitLeft() == false)
					{
						if(m_Blocks[2].GetComponent<SingleBlock>().GetColliding() == false)
						{
							m_Rot++;
							m_Blocks[0].transform.position += new Vector3(m_Dist, 0, 0);
							m_Blocks[1].transform.position += new Vector3(m_Dist, m_Dist * -2, 0);
						}
					}
				}
				else
				{
					if(m_Blocks[3].GetComponent<SingleBlock>().GetHitRight() == false)
					{
						m_Blocks[0].transform.position -= new Vector3(m_Dist, 0, 0);
						m_Blocks[1].transform.position -= new Vector3(m_Dist, m_Dist * -2, 0);
						m_Rot--;
					}
				}
			}
			else if(m_CurrentShape == 6)	
			{
				if(m_Rot == 0)
				{
					if(m_Blocks[1].GetComponent<SingleBlock>().GetHitRight() == false)
					{
						if(m_Blocks[3].GetComponent<SingleBlock>().GetColliding() == false)
						{
							m_Rot++;
							m_Blocks[0].transform.position += new Vector3(-m_Dist, m_Dist * -2, 0);
							m_Blocks[1].transform.position += new Vector3(-m_Dist, 0, 0);
						}
					}
				}
				else
				{
					if(m_Blocks[2].GetComponent<SingleBlock>().GetHitLeft() == false)
					{
						m_Blocks[0].transform.position -= new Vector3(-m_Dist, m_Dist * -2, 0);
						m_Blocks[1].transform.position -= new Vector3(-m_Dist, 0, 0);
						m_Rot--;
					}
				}
			}
		}
		else
		{
			RotateBlocks2();
		}
	}

	private void RotateBlocks2()
	{
		if(m_CurrentShape == 0)
		{
			RotateJBlock();
		}
		else if(m_CurrentShape == 2)
		{
			RotateLBlock();
		}
		else if(m_CurrentShape == 3)
		{
			RotateTBlock();
		}
	}

	private void RotateJBlock()
	{
		if(m_Rot == 0)
		{
			if(m_Blocks[0].GetComponent<SingleBlock>().GetColliding() == false)
			{
				if(m_Blocks[1].GetComponent<SingleBlock>().GetColliding() == false)
				{
					m_Blocks[0].transform.position += new Vector3(m_Dist * -1, m_Dist * 1, 0);
					m_Blocks[2].transform.position += new Vector3(m_Dist * 1, m_Dist * -1, 0);
					m_Blocks[3].transform.position += new Vector3(m_Dist * 2, 0, 0); 
					m_Rot++;
				}
			}
		}
		else if(m_Rot == 1)
		{
			if(m_Blocks[1].GetComponent<SingleBlock>().GetHitRight() == false && m_Blocks[1].GetComponent<SingleBlock>().GetHitLeft() == false)
			{
				if(m_Blocks[0].GetComponent<SingleBlock>().GetHitLeft() == false)
				{
					m_Blocks[0].transform.position += new Vector3(m_Dist * -1, m_Dist * -1, 0);
					m_Blocks[2].transform.position += new Vector3(m_Dist * 1, m_Dist * 1, 0);
					m_Blocks[3].transform.position += new Vector3(0, m_Dist * 2, 0); 
					m_Rot++;
				}
			}
		}
		else if(m_Rot == 2)
		{
			if(m_Blocks[1].GetComponent<SingleBlock>().GetColliding() == false)
			{
				m_Blocks[0].transform.position += new Vector3(m_Dist * 1, m_Dist * -1, 0);
				m_Blocks[2].transform.position += new Vector3(m_Dist * -1, m_Dist * 1, 0);
				m_Blocks[3].transform.position += new Vector3(m_Dist * -2, 0, 0); 
				m_Rot++;
			}
		}
		else if(m_Rot == 3)
		{
			if(m_Blocks[1].GetComponent<SingleBlock>().GetHitLeft() == false && m_Blocks[1].GetComponent<SingleBlock>().GetHitRight() == false)
			{
				if(m_Blocks[0].GetComponent<SingleBlock>().GetHitRight() == false)
				{
					m_Blocks[0].transform.position += new Vector3(m_Dist * 1, m_Dist * 1, 0);
					m_Blocks[2].transform.position += new Vector3(m_Dist * -1, m_Dist * -1, 0);
					m_Blocks[3].transform.position += new Vector3(0, m_Dist * -2, 0); 
					m_Rot = 0;
				}
			}
		}
	}
	private void RotateLBlock()
	{
		if(m_Rot == 0)
		{
			if(m_Blocks[1].GetComponent<SingleBlock>().GetColliding() == false)
			{
				m_Blocks[0].transform.position += new Vector3(m_Dist * -1, m_Dist * 1, 0);
				m_Blocks[2].transform.position += new Vector3(m_Dist * 1, m_Dist * -1, 0);
				m_Blocks[3].transform.position += new Vector3(0, m_Dist * 2, 0); 
				m_Rot++;
			}
		}
		else if(m_Rot == 1)
		{
			if(m_Blocks[1].GetComponent<SingleBlock>().GetHitLeft() == false && m_Blocks[1].GetComponent<SingleBlock>().GetHitRight() == false)
			{
				if(m_Blocks[2].GetComponent<SingleBlock>().GetHitRight() == false)
				{
					m_Blocks[0].transform.position += new Vector3(m_Dist * -1, m_Dist * -1, 0);
					m_Blocks[2].transform.position += new Vector3(m_Dist * 1, m_Dist * 1, 0);
					m_Blocks[3].transform.position += new Vector3(m_Dist * -2, 0, 0); 
					m_Rot++;
				}
			}
		}
		else if(m_Rot == 2)
		{
			if(m_Blocks[1].GetComponent<SingleBlock>().GetColliding() == false)
			{
				if(m_Blocks[2].GetComponent<SingleBlock>().GetColliding() == false)
				{
					m_Blocks[0].transform.position += new Vector3(m_Dist * 1, m_Dist * -1, 0);
					m_Blocks[2].transform.position += new Vector3(m_Dist * -1, m_Dist * 1, 0);
					m_Blocks[3].transform.position += new Vector3(0, m_Dist * -2, 0); 
					m_Rot++;
				}
			}
		}
		else if(m_Rot == 3)
		{
			if(m_Blocks[1].GetComponent<SingleBlock>().GetHitLeft() == false && m_Blocks[1].GetComponent<SingleBlock>().GetHitRight() == false)
			{
				if(m_Blocks[2].GetComponent<SingleBlock>().GetHitLeft() == false)
				{
					m_Blocks[0].transform.position += new Vector3(m_Dist * 1, m_Dist * 1, 0);
					m_Blocks[2].transform.position += new Vector3(m_Dist * -1, m_Dist * -1, 0);
					m_Blocks[3].transform.position += new Vector3(m_Dist * 2, 0, 0); 
					m_Rot = 0;
				}
			}
		}
	}
	private void RotateTBlock()	
	{
		if(m_Rot == 0)
		{
			m_Blocks[2].transform.position += new Vector3(m_Dist * 1, m_Dist * 1, 0);
			m_Rot++;
		}
		else if(m_Rot == 1)
		{
			if(m_Blocks[1].GetComponent<SingleBlock>().GetHitRight() == false)
			{
				m_Blocks[3].transform.position += new Vector3(m_Dist * -1, m_Dist * 1, 0);
				m_Rot++;
			}
		}
		else if(m_Rot == 2)
		{
			if(m_Blocks[1].GetComponent<SingleBlock>().GetColliding() == false)
			{
				m_Blocks[0].transform.position += new Vector3(m_Dist * -1, m_Dist * -1, 0);
				m_Rot++;
			}
		}
		else if(m_Rot == 3)
		{
			if(m_Blocks[1].GetComponent<SingleBlock>().GetHitLeft() == false)
			{
				m_Blocks[0].transform.position += new Vector3(m_Dist * 1, m_Dist * 1, 0); 
				m_Blocks[2].transform.position += new Vector3(m_Dist * -1, m_Dist * -1, 0); 
				m_Blocks[3].transform.position += new Vector3(m_Dist * 1, m_Dist * -1, 0); 
				m_Rot = 0;
			}
		}
	}
	#endregion

	#region PlaceBlocksAtSpawn
	private void PlaceBlocks()
	{
		m_CurrentShape = m_NextShape;
		//J-block
		if(m_CurrentShape == 0)
		{
			for(int i = 0; i < m_Blocks.Length; i++)
			{
				if(i != 3)
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * (4 + i), m_TopSpawn * m_Dist, 0);
				}
				else
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * (4 + 2), (m_TopSpawn - 1) * m_Dist, 0);
				}
			}
			m_TwoRotations = false;
		}
		//I-block
		else if(m_CurrentShape == 1)
		{
			for(int i = 0; i < m_Blocks.Length; i++)
			{
				m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * 4, ((m_TopSpawn - 1) + i) * m_Dist, 0);
			}
			m_TwoRotations = true;
		}
		//L-block
		else if(m_CurrentShape == 2)
		{
			for(int i = 0; i < m_Blocks.Length; i++)
			{
				if(i != 3)
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * (4 + i), m_TopSpawn * m_Dist, 0);
				}
				else
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * 4, (m_TopSpawn - 1)  * m_Dist, 0);
				}
			}
			m_TwoRotations = false;
		}
		//T-block
		else if(m_CurrentShape == 3)
		{
			for(int i = 0; i < m_Blocks.Length; i++)
			{
				if(i != 3)
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * (4 + i), m_TopSpawn * m_Dist, 0);
				}
				else
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * 5, (m_TopSpawn - 1) * m_Dist, 0);
				}
			}
			m_TwoRotations = false;
		}
		//O-block
		else if(m_CurrentShape == 4)
		{
			for(int i = 0; i < m_Blocks.Length; i++)
			{
				if(i < 2)
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * (4 + i), m_TopSpawn * m_Dist, 0);
				}
				else
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * (2 + i), (m_TopSpawn - 1) * m_Dist, 0);
				}
			}
			m_TwoRotations = true;
		}
		//S-block
		else if(m_CurrentShape == 5)
		{
			for(int i = 0; i < m_Blocks.Length; i++)
			{
				if(i < 2)
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * (4 + i), m_TopSpawn * m_Dist, 0);
				}
				else
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * (1 + i), (m_TopSpawn - 1) * m_Dist, 0);
				}
			}
			m_TwoRotations = true;
		}
		//Z-block
		else if(m_CurrentShape == 6)
		{
			for(int i = 0; i < m_Blocks.Length; i++)
			{
				if(i < 2)
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * (4 + i), m_TopSpawn * m_Dist, 0);
				}
				else
				{
					m_Blocks[i].transform.position = m_Pos + new Vector3(-m_Dist * (3 + i), (m_TopSpawn - 1) * m_Dist, 0);
				}
			}
			m_TwoRotations = true;
		}
		for(int j = 0; j < m_Blocks.Length; j++)
		{
			m_Blocks[j].renderer.material = m_Material[m_CurrentShape];
		}
		m_Rot       = 0;
		m_NextShape = Random.Range(0, 7);
	}
	#endregion
}
