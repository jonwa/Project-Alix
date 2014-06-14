using UnityEngine;
using System.Collections;

/* Discription: FlickeringLight
 * If this lamp is on the light will be flickering
 * 
 * Created by: Sebastian Olsson 30-04-14
 * Modified by:
 */

[RequireComponent(typeof(Light))]
public class FlickeringLight : ObjectComponent
{
	#region PublicMemberVariables
	public float m_FlickerSpeed = 0.07f;
	public string m_Input = "Fire1";
	public bool m_LampOn = false;
	#endregion
	
	#region PrivateMemberVariables
	private int m_Randomizer = 0;
	private Light m_Light;
	#endregion

	override public string Name
	{ get{return"FlickeringLight";}}

	void Start()
	{
		m_Light = this.GetComponent<Light>();
		m_Light.enabled = m_LampOn;
		m_Randomizer = 0;
	}

	void Update()
	{
		if (m_LampOn) 
		{
			LightFlicker();
		}
	}
	
	public override void Interact()
	{
		if(Input.GetButtonDown(m_Input))
		{
			if(!m_LampOn)
			{
				m_LampOn = true;
			}
			else
			{
				m_LampOn = false;
				m_Light.enabled = false;
			}
			Camera.main.SendMessage("Release");
		}
	}

	private void LightFlicker()
	{
		if(m_Randomizer == 0)
		{
			m_Light.enabled = false;
		}
		else
		{
			m_Light.enabled = true;
		}
		m_Randomizer = Random.Range(0,2);
	}


	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
