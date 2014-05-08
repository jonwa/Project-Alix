using UnityEngine;
using System.Collections;

public class GameScreen : ObjectComponent
{
	public GameObject m_game;
	private int turnoff;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		turnoff--;
		if(turnoff < 0)
		{
			Camera.main.GetComponent<FirstPersonCamera>().UnLockCamera();
			renderer.enabled = false;
		}
	}

	public override void Interact()
	{
		renderer.enabled = true;
		turnoff = 5;
		Camera.main.GetComponent<FirstPersonCamera>().LockCamera();
		m_game.GetComponent<GravityControl>().StartGame();
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
