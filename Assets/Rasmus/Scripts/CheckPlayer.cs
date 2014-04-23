using UnityEngine;
using System.Collections;

public class CheckPlayer : MonoBehaviour 
{
	public GameObject m_Player;
	public GameObject m_Target;

	// Use this for initialization
	void Start () 
	{
		GetComponent<Camera>().aspect = 0.3f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float dist = Vector3.Distance(transform.position, m_Target.transform.position);
		//Debug.Log(dist);
		//GetComponent<Camera>().fieldOfView = dist / 1.3f;
		transform.position = m_Player.transform.position + new Vector3(-55.5f, 0, 0);
		transform.LookAt(m_Target.transform.position);
	}
}
