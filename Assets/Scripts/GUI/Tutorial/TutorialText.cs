using UnityEngine;
using System.Collections;

/* Class for showing the tutorialtext. Destroy itself and the guitext when done.
 * 
 * Made by: Rasmus 08/07
 */

public class TutorialText : MonoBehaviour 
{
	#region PublicMemberVariables
	public string[] m_TutorialText;
	public GUIText m_Text;
	public GUIText m_Text2;
	#endregion

	#region PrivateMemberVariables
	private int m_Line = 0;
	#endregion

	// Use this for initialization
	void Start () 
	{
		m_Text.text = m_TutorialText[m_Line];
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("space"))
		{
			if(m_Line + 1 < m_TutorialText.Length)
			{
				m_Line++;
				m_Text.text = m_TutorialText[m_Line];
			}
			else
			{
				Destroy(m_Text.gameObject);
				Destroy(m_Text2.gameObject);
				Destroy(this);
			}
		}
	}
}
