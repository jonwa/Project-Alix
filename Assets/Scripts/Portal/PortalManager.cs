using UnityEngine;
using System.Collections;

public class PortalManager : MonoBehaviour 
{
	#region PublicMemberVariables
	public int m_TimeStages = 3;
	public string m_InputForwards =	"Sprint";
	public string m_InputBackwards =	"Crouch";
	#endregion
	#region PrivateMemberVariables 
	//private static int 				m_NumberOfTimeStages = 2;
	private static int 				m_TargetTimeStage    = 0;
	private static PortalManager 	m_PortalManagerInstance;
	#endregion

	public static PortalManager Instance
	{
		get
		{
			if( m_PortalManagerInstance == null)
			{
				m_PortalManagerInstance = new PortalManager() as PortalManager;
			}
			return m_PortalManagerInstance;
		}
	}

	public static int NumberOfStages
	{
		get 
		{ 
			//Instance.m_TimeStages = Instance.m_TimeStages;
			return Instance.m_TimeStages;  
		}
		set 
		{ 	
			Instance.m_TimeStages = value; 
			//m_NumberOfTimeStages  = value;
		}
	}

	public static void NextTimeStage()
	{
		Debug.Log("Timestages: " + Instance.m_TimeStages.ToString());
		if(m_TargetTimeStage < (Instance.m_TimeStages-1))
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

	void Update()
	{
		if(Input.GetButtonDown(m_InputForwards))
		{
			NextTimeStage();
		}
		else if(Input.GetButtonDown(m_InputBackwards))
		{
			PreviousTimeStage();
		}
	}
}
