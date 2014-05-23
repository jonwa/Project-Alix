using UnityEngine;
using System.Collections;

public class RestartFalling : MonoBehaviour {
	public GameObject m_player;
	public Vector3 m_SpawnPos;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}


	void OnTriggerEnter(Collider col)
		{
			m_SpawnPos = col.GetComponent<RestartWallJumpGrej> ().GetPos ();
			m_player.transform.position = m_SpawnPos;
		}
}