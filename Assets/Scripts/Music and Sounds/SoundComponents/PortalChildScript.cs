using UnityEngine;
using System.Collections;

public class PortalChildScript : MonoBehaviour 
{
	#region PrivateMemberVariables
	private GameObject		m_Player;
	private GameObject		m_ThisObject;
	private bool 			m_IsColliding = false;
	
	#endregion

	void Start () 
	{
		m_Player = Camera.main.transform.parent.gameObject;
		m_ThisObject = this.gameObject;
	}

	public bool Colliding
	{
		get{return m_IsColliding;}
		set{m_IsColliding = value;}
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.name == m_Player.name && !m_IsColliding)
		{
			Debug.Log ("Collider");
			m_IsColliding = true;
		}
	}

}
