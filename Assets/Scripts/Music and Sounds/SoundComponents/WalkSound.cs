using UnityEngine;
using System.Collections;
using FMOD.Studio;

/* Discription: WalkSound
 * Sound for footsteps
 * 
 * Created by: Sebastian Olsson 14/05-14
 * Modified by:
 */

//TODO: ALLT

public class WalkSound : SoundComponent 
{
	#region PrivateMemberVariables
	private float	m_Action;
	private float	m_PlayerSpeed;
	private GameObject	m_Player;
	#endregion
	
	#region PublicMemberVariables
	public string	m_Material;
	public string[]	m_Parameters;
	#endregion
	

	public override void PlaySound()
	{
		m_PlayerSpeed = Camera.main.transform.parent.gameObject.transform.rigidbody.velocity.normalized.magnitude;
		Debug.Log (m_PlayerSpeed);
		if(m_PlayerSpeed != 0 )
		{
			switch(m_Material)
			{
			case "Wood":
				//m_Action = 0.15f;
				//Evt.setParameterValue(m_Parameters[0], m_Action);
				Debug.Log ("Wood");
				break;
			case "Carpet":
				break;
			default:
				break;
			}
		}
	}
	void Start () 
	{
		CacheEventInstance();
		StartEvent();

		m_Player = Camera.main.transform.parent.gameObject;
	}
	
	void Update () 
	{
		var attributes = UnityUtil.to3DAttributes (m_Player);
		ERRCHECK (Evt.set3DAttributes(attributes));			


		PlaySound ();
	}
}
