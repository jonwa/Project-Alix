using UnityEngine;
using System.Collections;

/* Discription: Class that handles all objects that can spawn
 * 
 * Created by: Rasmus Datum: 22/04-14
 * Modified by:
 * 
 */

public class SpawnController : MonoBehaviour 
{
	#region PublicMemberVariables
	public GameObject[]	m_GameObjects;
	#endregion
	
	#region PrivateMemberVariables
	#endregion

	public void SpawnObject(int ID)
	{
		for(int i = 0; i < m_GameObjects.Length; i++)
		{
			if(ID == m_GameObjects[i].GetComponent<Id>().ObjectId)
			{
				m_GameObjects[i].GetComponent<Spawn>().Spawned();
			}
		}
	}
}
