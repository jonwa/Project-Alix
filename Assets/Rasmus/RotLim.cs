using UnityEngine;
using System.Collections;

/* Discription: Class for rotationLimit on object, works for the in-game physiscs.
* 
* Made by: Rasmus 14/04
*/

public class RotLim : MonoBehaviour 
{

	#region PublicMemberVariables
	//public float  	  m_MaxLimit 	 = 90;
	//public float  	  m_MinLimit 	 = 90;
	//public bool   	  m_Locked 		 = false;
	//public GameObject m_OtherLimit;
	//public bool  m_Vertical		= true;
	#endregion

	#region PrivateMemberVariables
	private float   m_OriginalRotation;
	//private Vector3 m_LastPosition;
	private float   m_Difference = 0;
	private float 	m_LastRotation;
	//private float   m_TotalRotation;
	//private float   m_LastTotal;
	//private bool    m_Door;
	#endregion



	// Use this for initialization
	void Start () 
	{
		//Debug.Log(transform.localRotation.eulerAngles.y);

		//m_LastPosition 		= transform.position;
		m_OriginalRotation  = transform.localRotation.eulerAngles.y;
		m_LastRotation		= m_OriginalRotation;
	}

	// Update is called once per frame
	void Update () 
	{
		CheckUnLocked();

		//m_TotalRotation = m_Difference + m_OtherLimit.GetComponent<RotLim2>().GetDifference();
		//if(m_LastTotal != m_TotalRotation)
		//{
		//	m_LastTotal = m_TotalRotation;
		//	Debug.Log(m_TotalRotation);
		//}
		//Debug.Log(m_Difference);
	}

	private void CheckUnLocked()
	{
		//float m_TempMaximum = m_OriginalRotation + m_MaxLimit;
		//float m_TempMinimum = m_OriginalRotation - m_MinLimit;

		//Rotation minimum is still positive
		//if(m_TempMinimum > 1)
		//{
		//if(m_Difference > m_MaxLimit)
		//{
		//	transform.position = m_LastPosition;
		//	transform.localRotation.Set(0, m_OriginalRotation+m_MaxLimit, 0, 0);
		//}
		//else if(m_Difference < m_MinLimit)
		//{
		//	transform.position = m_LastPosition;
		//	transform.localRotation.Set(0, m_OriginalRotation-m_MinLimit, 0, 0);
		//}
		//else
		//{
			if(m_LastRotation + 0.01 > transform.localRotation.eulerAngles.y && m_LastRotation - 0.01 < transform.localRotation.eulerAngles.y)
			{
				//Skillnad i float
			}
			else if(m_LastRotation + 50 > transform.localRotation.eulerAngles.y && m_LastRotation - 50 < transform.localRotation.eulerAngles.y)
			{
				m_Difference   += transform.localRotation.eulerAngles.y - m_LastRotation;
				m_LastRotation = transform.localRotation.eulerAngles.y;
			}
			else
			{
				m_LastRotation = transform.localRotation.eulerAngles.y;
			}
			//m_LastPosition = transform.position;
		//}
		//}
		//else //Rotation minimum is under 0, exempel -90
		//{
		//	m_TempMinimum += 360;
		//	if(transform.localRotation.eulerAngles.y > m_TempMaximum && transform.localRotation.eulerAngles.y <= 270)
		//	{
		//		transform.position = m_LastPosition;
		//		transform.Rotate(0, m_TempMaximum - transform.localRotation.eulerAngles.y, 0);
		//	}
		//	else if(transform.localRotation.eulerAngles.y < m_TempMinimum  && transform.localRotation.eulerAngles.y> 270)
		//	{
		//		transform.position = m_LastPosition;
		//		transform.Rotate(0, m_TempMinimum - transform.localRotation.eulerAngles.y, 0);
		//	}
		//	else 
		//	{
		//		if(m_LastRotation + 0.01 > transform.localRotation.eulerAngles.y && m_LastRotation - 0.01 < transform.localRotation.eulerAngles.y)
		//		{
		//			//Skillnad i float
		//		}
		//		else if(m_LastRotation + 30 > transform.localRotation.eulerAngles.y && m_LastRotation - 30 < transform.localRotation.eulerAngles.y)
		//		{
		//			m_Difference   += transform.localRotation.eulerAngles.y - m_LastRotation;
		//			m_LastRotation = transform.localRotation.eulerAngles.y;
		//		}
		//		else
		//		{
		//			m_LastRotation = transform.localRotation.eulerAngles.y;
		//		}
		//		m_LastPosition = transform.position;
		//	}
		//}
	}

	public float GetDifference()
	{
		return m_Difference;
	}
}
