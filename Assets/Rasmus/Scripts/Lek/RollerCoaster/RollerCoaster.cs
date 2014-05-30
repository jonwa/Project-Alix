using UnityEngine;
using System.Collections;

public class RollerCoaster : MonoBehaviour 
{
	public GameObject[] m_Nodes0;
	public GameObject[] m_Nodes1;
	public GameObject[] m_Nodes2;
	public GameObject[] m_Nodes3;
	public GameObject[] m_Nodes4;
	public GameObject[] m_Nodes5;
	public float m_Speed = 0.5f;

	private int m_Int = 0;
	private GameObject[] m_ActiveNodes;

	// Use this for initialization
	void Start () 
	{
		m_ActiveNodes = m_Nodes0;
	}

	private void NextNodes()
	{
		if(m_ActiveNodes == m_Nodes0)
		{
			m_ActiveNodes = m_Nodes1;
		}
		else if(m_ActiveNodes == m_Nodes1)
		{
			m_ActiveNodes = m_Nodes2;
		}
		else if(m_ActiveNodes == m_Nodes2)
		{
			m_ActiveNodes = m_Nodes3;
		}
		else if(m_ActiveNodes == m_Nodes3)
		{
			m_ActiveNodes = m_Nodes4;
		}
		else if(m_ActiveNodes == m_Nodes4)
		{
			m_ActiveNodes = m_Nodes5;
		}
		else if(m_ActiveNodes == m_Nodes5)
		{
			m_ActiveNodes = m_Nodes0;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		transform.LookAt(m_ActiveNodes[m_Int].transform.position);
		transform.position += transform.forward*m_Speed;

		if(Vector3.Distance(transform.position, m_ActiveNodes[m_Int].transform.position) < 1)
		{
			if(m_Int < m_ActiveNodes.Length - 1)
			{
				m_Int++;
			}
			else
			{
				m_Int = 0;
				NextNodes();
			}
			m_Speed = m_ActiveNodes[m_Int].GetComponent<NodeSpeed>().GetSpeed();
		}
	}
}
