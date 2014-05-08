using UnityEngine;
using System.Collections;

public class GravityControl : MonoBehaviour 
{
	public GameObject m_BlockControl;

	private float timer			= 0;
	private float timePerUpdate = 3;
	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		if(timer < timePerUpdate)
		{
			timer += Time.deltaTime;
		}
		else
		{
			timer = 0;
			m_BlockControl.GetComponent<BlockControl>().UpdateGravity();
		}
	}
}
