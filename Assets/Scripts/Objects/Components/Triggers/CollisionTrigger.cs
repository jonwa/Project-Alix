using UnityEngine;
using System.Collections;

/* If player collide with the gameObject Trigger, start the triggereffects on gameObject

	Made By: Rasmus 30/4
 */

<<<<<<< HEAD
public class CollisionTrigger : MonoBehaviour {	
	public void OnTriggerEnter()
	{
		if(gameObject.GetComponent<SuperTrigger>())
		{
			SuperTrigger[] triggerArray;
			triggerArray = gameObject.GetComponents<SuperTrigger>();
			foreach(SuperTrigger c in triggerArray)
=======
public class CollisionTrigger : MonoBehaviour {
	#region PrivateMemberVariables
	private bool 	m_HasTriggered = false;
	private string	m_PlayerName;
	#endregion
	
	#region PublicMemberVariables
	public string[] m_Messages;
	public bool m_TriggerOnce;
	#endregion
	// Use this for initialization
	void Start () 
	{
		m_PlayerName = Camera.main.transform.parent.gameObject.name;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == m_PlayerName ) 
		{
			Debug.Log("jAPP FUNKER");
			if(m_HasTriggered == false)
			{
				ActivateTriggerEffect();
				if(m_TriggerOnce == true)
				{
					m_HasTriggered = true;
				}
			}
		}
	}

	public void ActivateTriggerEffect()
	{
		for(int i = 0; i < m_Messages.Length; i++){
			if(m_Messages[i].Equals("Effect"))
			{
				Debug.Log("Fått en triggerEffect");
			}
			else
>>>>>>> 92beaf40a036c549a2d3df76d99f75233488c66d
			{
				if(c.Collision){
					c.ActivateTriggerEffect();
				}
			}
		}
	}
}
