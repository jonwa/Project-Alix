using UnityEngine;
using System.Collections;

public class PortalManager : MonoBehaviour 
{
	#region PublicMemberVariables
	public int m_NumberOfTimeStages = 2;
	#endregion
	#region PrivateMemberVariables 
	private static int 				m_TargetTimeStage   = 0;
	private static PortalManager 	m_PortalManagerInstance;
	#endregion

	void Awake()
	{
		m_PortalManagerInstance = this;
	}

	public static int NumberOfStages
	{
		get { return m_PortalManagerInstance.m_NumberOfTimeStages;  }
		set { m_PortalManagerInstance.m_NumberOfTimeStages = value; }
	}

	public static void NextTimeStage()
	{
		if(m_TargetTimeStage < (m_PortalManagerInstance.m_NumberOfTimeStages-1))
		{
			m_TargetTimeStage++;
		}
	}

	public static void SetCurrentTimeStage(int timeStage)
	{
		m_TargetTimeStage = timeStage;
	}

	public static void PreviousTimeStage()
	{
		if(m_TargetTimeStage > 0)
		{
			m_TargetTimeStage--;
		}
	}

	public static int GetCurrentTimeStage()
	{
		return m_TargetTimeStage;
	}
}
