using UnityEngine;
using System.Collections;

/* Functionallity for either of the action you'r doing while reading
 * a book.  
 * 
 * Created By: Jon Wahlström 2014-04-16
 * Modified By: 
 */

public class BookWindow : MonoBehaviour 
{
	#region publicMemberVariables
	public GameObject[] m_PagesPrefabs;
	#endregion

	#region privateMemberVariables
	private static GameObject[] m_Pages; 
	private static GameObject 	m_CurrentWindow = null;
	private static GameObject	m_DefaultWindow = null; 
	private static int			m_PageCounter 	= 0; 
	#endregion

	void Start()
	{ 
	 	if(m_PagesPrefabs.Length > 0) 
		{
			m_Pages = new GameObject[m_PagesPrefabs.Length];
			int i = 0;
			foreach(GameObject go in m_PagesPrefabs)
			{
				m_Pages[i] = go;
				++i;
			}
			Debug.Log("Pages.size " + m_Pages.Length);
		}
	}

	public static void NextPage()
	{
		if(m_PageCounter < m_Pages.Length-1)
		{
			++m_PageCounter;
		}
		Debug.Log("Pages counter " + m_PageCounter);
		m_Pages[m_PageCounter-1].SetActive(false);
		m_Pages[m_PageCounter].SetActive(true);
	}

	public static void PreviousPage()
	{
		if(m_PageCounter > 0)
		{
			--m_PageCounter; 
		}
		Debug.Log("Pages counter " + m_PageCounter);
		m_Pages[m_PageCounter+1].SetActive(false);
		m_Pages[m_PageCounter].SetActive(true);
	}

	public static void Close()
	{
		m_PageCounter = 0; 
		if(m_Pages.Length > 0)
		{
			foreach(GameObject go in m_Pages)
			{
				go.SetActive(false);
			}
			m_Pages [m_PageCounter].SetActive (true);
		}
	}
}
