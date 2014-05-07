using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

/* 
 * Padlock window takes care to set the correct current number
 * to each of the padlock numbers. 
 * 
 * Created By: Jon Wahlström 2014-04-16
 * Modified By: 
 */

public class PadlockWindow : MonoBehaviour
{
	#region PublicMemberVariables
	public GameObject[] m_NumberPrefabs = null;  
	#endregion

	#region PrivateMemberVariables
	private static GameObject[] m_Numbers; 
	private static int m_CurrentNumber = 0; 
	#endregion

	void Start()
	{
		if(m_NumberPrefabs == null) return;  

		m_Numbers = new GameObject[m_NumberPrefabs.Length];
		int i = 0; 
		foreach(GameObject go in m_NumberPrefabs)
		{
			m_Numbers[i] = go;
			++i;
		}
		Debug.Log("m_Numbers.Length: " + m_Numbers.Length);
	}

	public static void NextNumber(int id)
	{
		m_CurrentNumber = int.Parse(m_Numbers[id].GetComponentInChildren<UILabel>().text.ToString());

		if(m_CurrentNumber < 9)
		{
			m_CurrentNumber++; 
		}
		else if(m_CurrentNumber == 9)
		{
			m_CurrentNumber = 0; 
		}

		m_Numbers[id].GetComponentInChildren<UILabel>().text = m_CurrentNumber.ToString();
	}

	public static void PreviousNumber(int id)
	{
		m_CurrentNumber = int.Parse(m_Numbers[id].GetComponentInChildren<UILabel>().text.ToString());

		if(m_CurrentNumber > 0)
		{
			--m_CurrentNumber;
		}
		else if(m_CurrentNumber == 0)
			m_CurrentNumber = 9; 

		m_Numbers[id].GetComponentInChildren<UILabel>().text = m_CurrentNumber.ToString();
	}
}
