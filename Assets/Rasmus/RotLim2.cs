using UnityEngine;
using System.Collections;	

public class RotLim2 : MonoBehaviour 
{
	public float m_Maximum = 90;
	public float m_Minimum = -90;
	public bool  m_Door;

	public GameObject m_OtherLimit;
	private float 	  m_TotalRotation = 0;
	private Transform m_LastTransform;
	private int       m_Delay = 0;
	private int       m_Bugg = 0;
	private int       m_Bugg2 = 0;


	void Start () 
	{
		m_LastTransform = transform;
	}
	
	void Update () 
	{
		if(m_Delay == 0)
		{
			rigidbody.isKinematic = false;
			m_TotalRotation = m_OtherLimit.GetComponent<RotLim>().GetDifference() +	gameObject.GetComponent<RotLim>().GetDifference();
			if(m_TotalRotation < m_Maximum && m_TotalRotation > m_Minimum)
			{
				m_LastTransform = transform;
			}
			else if(m_TotalRotation > m_Maximum)
			{
				gameObject.transform.Rotate(transform.up, (m_Maximum - m_TotalRotation));
				gameObject.transform.position = m_LastTransform.position;
				if(m_Door == true)
				{
					m_Delay =  10;
					m_Bugg  += 20;
				}
				else
				{
					m_Bugg2  +=10;
				}
			}
			else if(m_TotalRotation < m_Minimum)
			{
				gameObject.transform.Rotate(transform.up, (m_Minimum - m_TotalRotation));
				gameObject.transform.position = m_LastTransform.position;
				if(m_Door == true)
				{
					m_Delay =  10;
					m_Bugg  += 20;
				}
				else
				{
					m_Bugg2  +=10;
				}
			}
		}
		else
		{
			rigidbody.isKinematic = true;
			m_Delay--;
		}
		if(m_Bugg > 50)
		{
			m_Delay = 50;
			m_Bugg--;
		}
		else
		{
			m_Bugg--;
		}
		if(m_Bugg2 > 100)
		{
			BroadcastMessage("ReleaseDoor");
			m_Bugg2=0;
		}
		else
		{
			m_Bugg2--;
		}
	}
}
