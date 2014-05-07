using UnityEngine;
using System.Collections;

/* Discription: Class that holds data for the player, example health and alive/dead status
 * 
 * Created by: Jimmy Date: 2014-04-04
 * Modified by: Jon Wahlstöm 2014-04-14 and Rasmus 2014-05-02
 */

public class CharacterData : MonoBehaviour 
{
	#region PublicMemberVariables
	public GameObject m_DeathMenu;
	public GameObject m_Camera;
	public GameObject m_Oculus;
	public bool       m_UseUculus = false;
	#endregion

	#region PrivateMemberVariables
	private static bool 		 m_Alive  = true;
	private static int  		 m_Health = 1000;
	private static CharacterData m_Instance;
	#endregion

	void Start()
	{
		m_Instance = this;
		UpdateOculus();
	}

	public void SetOculus(bool oculus)
	{
		m_UseUculus = oculus;
	}

	public bool GetOculus()
	{
		return m_UseUculus;
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
		//m_DeathMenu.GetComponent<MenuInput>().Active = true;
	}

	private void UpdateOculus()
	{
		if(m_UseUculus == true)
		{
			m_Camera.gameObject.SetActive(false);
			m_Oculus.gameObject.SetActive(true);
		}
		else
		{
			m_Camera.gameObject.SetActive(true);
			m_Oculus.gameObject.SetActive(false);
		}
	}
}
