using UnityEngine;
using System.Collections;

/* Discription: TriggerLights
 * Used to toggel lights on or off
 * 
 * Created by: Sebastian Olsson 24-04-14
 * Modified by:
 */

public class TriggerLights : TriggerComponent {

	#region PublicMemberVariables
	#endregion
	
	#region PrivateMemberVariables
	private Light m_Light;
	#endregion

	override public string Name
	{
		get{ return "LightSwitch"; }
	}

	void LightSwitch()
	{
		if (m_Light.enabled == true) 
		{
			m_Light.enabled = false;
		}
		else
		{
			m_Light.enabled = true;
		}
	}

	void Start () 
	{
		m_Light = this.GetComponent<Light>();
	}
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
