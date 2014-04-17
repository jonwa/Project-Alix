using UnityEngine;
using System.Collections;

/* Discription: Class for calculating rotation on doors
* 
* Made by: Rasmus 14/04
*/

public class RotLim : MonoBehaviour 
{

	#region PublicMemberVariables
	#endregion

	#region PrivateMemberVariables
	private float   m_OriginalRotation;
	private float   m_Difference = 0;
	private float 	m_LastRotation;
	#endregion



	// Use this for initialization
	void Start () 
	{
		m_OriginalRotation  = transform.localRotation.eulerAngles.y;
		m_LastRotation		= m_OriginalRotation;
	}

	// Update is called once per frame
	void Update () 
	{
		CheckUnLocked();
	}

	private void CheckUnLocked()
	{
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
	}

	public float GetDifference()
	{
		return m_Difference;
	}
}
