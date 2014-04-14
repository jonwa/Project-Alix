using UnityEngine;
using System.Collections;

/* Discription: Class for rotationLimit on object, works for the in-game physiscs.
* 
* Made by: Rasmus 14/04
*/

public class RotLim : MonoBehaviour 
{

	#region PublicMemberVariables
	public float m_MaxLimit 	= 90;
	public float m_MinLimit 	= 90;
	public float m_LockedOffset = 5;
	public bool  m_Locked 		= false;
	public RotLim m_OtherLimit;
	//public bool  m_Vertical		= true;
	#endregion

	#region PrivateMemberVariables
	private float   m_OriginalRotation;
	private Vector3 m_LastPosition;
	private float   m_Difference;
	#endregion



	// Use this for initialization
	void Start () 
	{
		if(m_MinLimit < 1)
		{
			m_MinLimit = 1;
		}

		m_LastPosition 		= transform.position;
		m_OriginalRotation  = transform.localRotation.eulerAngles.y;
		Debug.Log(transform.localRotation.eulerAngles.y + " och " + transform.rotation.eulerAngles.y);

	}

	// Update is called once per frame
	void LateUpdate () 
	{
		//if(m_Vertical){
			if(m_Locked)
			{
				CheckLocked();
			}
			else
			{
				CheckUnLocked();
			}
		//}
	}

	private void CheckUnLocked()
	{
		float m_TempMaximum = m_OriginalRotation + m_MaxLimit;
		float m_TempMinimum = m_OriginalRotation - m_MinLimit;

		//Debug.Log(transform.localRotation.eulerAngles.y);
		//Debug.Log();

		//Rotation minimum is still positive
		if(m_TempMinimum > 1)
		{
			if(transform.localRotation.eulerAngles.y  > m_TempMaximum)
			{
				transform.position = m_LastPosition;
				transform.Rotate(0, m_TempMaximum - transform.localRotation.eulerAngles.y, 0);
			}
			else if(transform.localRotation.eulerAngles.y < m_TempMinimum)
			{
				transform.position = m_LastPosition;
				transform.Rotate(0, m_TempMinimum - transform.localRotation.eulerAngles.y, 0);
			}
			else
			{
				//Debug.Log("Skall spara en position");
				m_LastPosition = transform.position;
			}
		}
		else //Rotation minimum is under 0, exempel -90
		{
			m_TempMinimum += 360;
			if(transform.localRotation.eulerAngles.y + m_Difference> m_TempMaximum && transform.localRotation.eulerAngles.y <= 250)
			{
				transform.position = m_LastPosition;
				transform.Rotate(0, m_TempMaximum - transform.localRotation.eulerAngles.y, 0);
			}
			else if(transform.localRotation.eulerAngles.y - m_Difference < m_TempMinimum  && transform.localRotation.eulerAngles.y> 250)
			{
				transform.position = m_LastPosition;
				transform.Rotate(0, m_TempMinimum - transform.localRotation.eulerAngles.y, 0);
			}
			else 
			{
				m_LastPosition = transform.position;
			}
		}
	}

	private void CheckLocked()
	{
		float m_TempMaximum = m_OriginalRotation + m_LockedOffset;
		float m_TempMinimum = m_OriginalRotation - m_LockedOffset;

		if(transform.localRotation.eulerAngles.y > m_TempMaximum)
		{
			transform.position = m_LastPosition;
			transform.Rotate(0, m_TempMaximum - transform.localRotation.eulerAngles.y, 0);
		}
		else if(transform.localRotation.eulerAngles.y < m_TempMinimum)
		{
			transform.position = m_LastPosition;
			transform.Rotate(0, m_TempMinimum - transform.localRotation.eulerAngles.y, 0);
		}
		else
		{
			m_LastPosition = transform.position;
		}
	}

	public void SetDifference(float flo)
	{
		Debug.Log("Getting difference");
		m_Difference = flo;
	}
}
