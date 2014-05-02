using UnityEngine;
using System.Collections;

public class HideNSeek : ObjectComponent 
{
	private GameObject[] m_SpawnPoints;
	Vector3 orignialPos;
	private bool started = false;

	// Use this for initialization
	void Start () 
	{
		orignialPos = transform.position;
		m_SpawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
		Debug.Log(m_SpawnPoints.Length);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public override void Interact ()
	{
		int randomSpawn = Random.Range(0, m_SpawnPoints.Length);
		transform.position = m_SpawnPoints[randomSpawn].transform.position;
		if(started == true)
		{
			//Debug.Log("Found me");
			transform.parent.GetComponent<HideScore>().AddScore();
		}
		else
		{
			started = true;
			transform.parent.GetComponent<HideScore>().RestartGame();
		}
	}

	public void Restart()
	{
		transform.position = orignialPos;
		started = false;

	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
