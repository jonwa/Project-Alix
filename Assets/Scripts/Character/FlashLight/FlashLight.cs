using UnityEngine;
using System.Collections;

public class FlashLight : ObjectComponent {

	#region PublicMemeberVariables
	public string m_Input;
	public bool m_OnOff  = false;
	#endregion

	#region PrivateMemeberVariables
	private bool m_CanUse = false;
	#endregion

	// Use this for initialization
	void Start ()
	{
		gameObject.GetComponent<Light>().enabled = m_OnOff;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(m_CanUse && Input.GetButtonDown(m_Input))
		{
			Toggle();
		}
	}

	void Toggle()
	{
		m_OnOff = !m_OnOff;
		gameObject.GetComponent<Light>().enabled = m_OnOff;
	}

	public void Find(){
		if(!m_CanUse){
			m_CanUse = true;
		}
	}
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
