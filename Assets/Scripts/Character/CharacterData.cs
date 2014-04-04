using UnityEngine;
using System.Collections;

/* Discription: Class that holds data for the player, example health and alive/dead status
 * 
 * Created by: Jimmy Date: 2014-04-04
 * Modified by:
 */

public class CharacterData : MonoBehaviour 
{
	#region PublicMemberVariables
	public GameObject m_DeathMenu;
	#endregion

	#region PrivateMemberVariables
	private static bool 		 m_Alive  = true;
	private static int  		 m_Health = 1000;
	private static CharacterData m_Instance;
	#endregion

	void Start()
	{
		m_Instance = this;
	}

	//Set or get the player alive status
	public static bool Alive
	{
		get 
		{ 
			return m_Alive; 
		}
		set 
		{ 
			m_Alive = value;
			if(!m_Alive)
			{
				m_Instance.GetComponent<FirstPersonController>().LockPlayerMovement();
				m_Instance.ShowDeathMenu();
			}
			else
			{
				m_Instance.GetComponent<FirstPersonController>().UnLockPlayerMovement();
			}
		}
	}

	//Set or get the health, also changes the players alive / dead status
	public static int Health
	{
		get 
		{ 
			return m_Health; 
		}
		set 
		{
			if(value <= 0)
			{
				m_Health = 0;
				m_Alive  = false;
				m_Instance.ShowDeathMenu();
			}
			else
			{
				m_Health = value;
				m_Alive  = true;
			}
		}
	}

	public void ShowDeathMenu()
	{

		m_DeathMenu.SetActive(true);
		m_DeathMenu.GetComponent<MenuInput>().Active = true;
		
		//freeze the camera position
		Camera.main.gameObject.GetComponent<FirstPersonCamera>().LockCamera();
	}
}
