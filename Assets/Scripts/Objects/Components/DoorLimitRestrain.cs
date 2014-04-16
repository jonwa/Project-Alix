using UnityEngine;
using System.Collections;	

public class DoorLimitRestrain : MonoBehaviour 
{
	#region PublicMemberVariables
	public float m_Maximum 		= 90;
	public float m_Minimum 		= -90;
	public float m_LockedOffset = 5;
	public bool  m_Door;
	public GameObject m_OtherLimit;
	#endregion
	
	#region PrivateMemberVariables
	private Transform m_LastTransform;
	private float 	  m_TotalRotation = 0;
	private int       m_Delay 		  = 0;
	private int       m_Bugg 		  = 0;
	private int       m_Bugg2 		  = 0;
	private float     m_OriginalMaximum;
	private float     m_OriginalMinimum;
	#endregion
	
	
	void Start () 
	{
		m_OriginalMaximum = m_Maximum;
		m_OriginalMinimum = m_Minimum;
		
		m_LastTransform = transform;
		if(m_Door)
		{
			m_Maximum = m_OtherLimit.GetComponent<DoorLimitRestrain>().m_Maximum;
			m_Minimum = m_OtherLimit.GetComponent<DoorLimitRestrain>().m_Minimum;
		}
	}
	
	void Update ()
	{
		if(m_Door)
		{
			if(m_OtherLimit.GetComponent<Locked>().GetLocked())
			{
				m_Maximum = m_LockedOffset;
				m_Minimum = -m_LockedOffset;
			}
			else
			{
				m_Maximum = m_OriginalMaximum;
				m_Minimum = m_OriginalMinimum;
			}
			CheckLimit();
		}
		else
		{
			if(GetComponent<Locked>().GetLocked())
			{
				m_Maximum = m_LockedOffset;
				m_Minimum = -m_LockedOffset;
			}
			else
			{
				m_Maximum = m_OriginalMaximum;
				m_Minimum = m_OriginalMinimum;
			}
			CheckLimit();
		}
	}
	
	private void CheckLimit()
	{
		if(m_Delay == 0)
		{
			rigidbody.isKinematic = false;
			m_TotalRotation 	  = m_OtherLimit.GetComponent<DoorLimitCalculate>().GetDifference() +	gameObject.GetComponent<DoorLimitCalculate>().GetDifference();
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
