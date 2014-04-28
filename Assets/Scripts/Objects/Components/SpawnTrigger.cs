using UnityEngine;
using System.Collections;

/* Discription: Class triggering a spawn
 * 
 * Created by: Rasmus Datum: 22/04-14
 * Modified by:
 * 
 */

public class SpawnTrigger : MonoBehaviour 
{
	#region PublicMemberVariables
	public int m_TargetId;
	#endregion

	#region PrivateMemberVariables
	private GameObject m_Spawner;
	#endregion

	void Start()
	{
		m_Spawner = GameObject.FindGameObjectWithTag("SpawnController");
	}

	public void OnTriggerEnter()
	{
		m_Spawner.GetComponent<SpawnController>().SpawnObject(m_TargetId);
	}
}
