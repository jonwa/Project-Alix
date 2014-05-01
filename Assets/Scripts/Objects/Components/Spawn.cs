using UnityEngine;
using System.Collections;

/* Discription: Class for spawning of fixed objects
 * 
 * Created by: Rasmus Datum: 22/04-14
 * Modified by:
 * 
 */

public class Spawn : MonoBehaviour {

	#region PublicMemberVariables
	public float m_Delay   = 1;
	public bool  m_UnSpawn = true;
	#endregion

	#region PrivateMemberVariables
	private Vector3 m_Position;
	private Vector3 m_RestingPosition;
	private float   m_Timer;
	private bool    m_Spawned;
	#endregion

	// Use this for initialization
	void Start () 
	{
		m_Position 			= transform.position;
		m_RestingPosition 	= transform.position + new Vector3(0, 20, 0);
		m_Timer    			= m_Delay + 1;
		m_Spawned  			= true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(m_Spawned && m_UnSpawn)
		{
			m_Timer += Time.deltaTime;
			if(m_Timer > m_Delay)
			{
				transform.position  = m_RestingPosition;
				m_Spawned 			= false;
			}
		}
	}
}
