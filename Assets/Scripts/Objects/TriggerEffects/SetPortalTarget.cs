using UnityEngine;
using System.Collections;

public class SetPortalTarget : TriggerComponent  
{
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	override public string Name
	{
		get{ return "SetPortalTarget"; }
	}

	public void PortalTarget0()
	{
		Camera.main.GetComponent<HouseCall>().SetTargetHouse(0);
	}
	public void PortalTarget1()
	{
		Camera.main.GetComponent<HouseCall>().SetTargetHouse(1);
	}
	public void PortalTarget2()
	{
		Camera.main.GetComponent<HouseCall>().SetTargetHouse(2);
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
