using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class DigbySound : SoundComponent
{
	#region PublicMemberVariables
	public string[]	m_Parameters;

	#endregion
	#region PrivateMemberVariables
	private float	m_Distance;
	public float	m_Line;
	public bool		m_DigbyPuzzle;
	private bool	m_Entered 		= false;
	private string	m_PlayerName;
	private bool	m_Line1 		= false;
	#endregion

	public bool DigbyPuzzle
	{
		get{return m_DigbyPuzzle;}
		set{m_DigbyPuzzle = value;}
	}

	public override void PlaySound()
	{
		Camera.main.SendMessage("Release");
		if(!m_Line1)
		{
			ChangeValue (m_Parameters [0], m_Line);
			StartEvent ();
			m_Line1 = true;
		}

	}

	void Start () 
	{
		CacheEventInstance ();
		m_PlayerName = Camera.main.transform.parent.gameObject.name;
	}

	void Update () 
	{
		var attributes = UnityUtil.to3DAttributes (this.gameObject);
		ERRCHECK (Evt.set3DAttributes(attributes));	
	}
	
	//void OnTriggerEnter(Collider collider)
	//{
	//	if(m_DigbyPuzzle)
	//	{
	//		if (collider.gameObject.name == m_PlayerName) 
	//		{
	//			if(!m_Entered && !m_Line1)
	//			{
	//				ChangeValue(m_Parameters[0], 0.05f);
	//				m_Line1 = true;
	//				m_Entered = true;
	//			}
	//		}
	//	}
	//}
	//
	//void OnTriggerExit(Collider collider)
	//{
	//	//m_Entered = false;
	//}

	void ChangeValue(string p_Parameter, float p_Value)
	{
		Evt.setParameterValue(p_Parameter, p_Value);
	}
}
