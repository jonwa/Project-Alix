using UnityEngine;
using System.Collections;

public class CallPhone : TriggerComponent
{
	#region PrivateMemberVariables
	private bool		m_Entered;
	private string		m_PlayerName;
	private PhoneSound 	m_Phone;
	#endregion
	
	#region PublicMemberVariables
	public bool			m_TriggerOnCollision;
	#endregion


	override public string Name
	{
		get{return"RingRing";}
	}
	
	void RingRing()
	{
		m_Phone = GameObject.FindObjectOfType<PhoneSound> () as PhoneSound;
		m_Phone.Play ();
	}

	// Use this for initialization
	void Start () 
	{
		m_PlayerName = Camera.main.transform.parent.gameObject.name;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == m_PlayerName && m_TriggerOnCollision) 
		{
			if(!m_Entered)
			{
				RingRing ();
				m_Entered = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
