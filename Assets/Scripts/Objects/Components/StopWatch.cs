using UnityEngine;
using System.Collections;

public class StopWatch : ObjectComponent
{
    public GUIText m_Gui;
	public bool _startPoint;
	//public static float Time {get {return _time;} private set{ };}
	
	private static float _time;
	private static bool _active = false;
	
	void Update() 
	{
		if(_active)
		{
			_time += Time.deltaTime;
		}
		m_Gui.text = _time.ToString();
	}
	
	void OnTriggerEnter()
	{
		if(_startPoint)
		{
			_active = true;
			//_time = 0.0f;
		}
		else
		{
			_active = false;
			Debug.Log("Your time: " + _time.ToString());
		}
	}
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
