using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TetrisRow : MonoBehaviour 
{
	public GameObject m_RowDestroy;

	private List<Collider> m_Hits = new List<Collider>();
	private int m_MyRow;
	//private bool CheckOnce = true;
	// Use this for initialization
	void Start () 
	{
	
	}

	public void SetRow(int row)
	{
		m_MyRow = row;
	}

	// Update is called once per frame
	void Update () 
	{
		if(m_Hits.Count >= 10)
		{
			Collider[] m_Obj = m_Hits.ToArray();
			m_Obj = m_Hits.ToArray();
			for(int i = 0; i < m_Obj.Length; i++)
			{
				Destroy(m_Obj[i].gameObject);
			}
			m_RowDestroy.GetComponent<TetrisRowDestroy>().DestroyedRow(m_MyRow);
			m_Hits.Clear();
		}
	}

	public void MoveBlocks(int row)
	{
		Collider[] m_Obj = m_Hits.ToArray();
		for(int i = 0; i < m_Obj.Length; i++)
		{
			m_Obj[i].gameObject.GetComponent<SingleBlock>().FallSteps(row);
		}
		m_Hits.Clear();
	}

	public void OnTriggerStay(Collider col)
	{
		if(col.tag == "Blocks")
		{
			if(!m_Hits.Contains(col))
			{
				if(col.GetComponent<SingleBlock>().GetFalling() == false)
				{
					m_Hits.Add(col);	
				}
			}
		}
	}
	public void OnTriggerExit(Collider col)
	{
		if(col.tag == "Blocks")
		{
			if(m_Hits.Contains(col))
			{
				m_Hits.Remove(col);	
			}
		}
	}
}
