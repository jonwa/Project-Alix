using UnityEngine;
using System.Collections;
using FMOD.Studio;

/* Discription: WalkSound
 * Sound for footsteps
 * 
 * Created by: Sebastian Olsson 14/05-14
 * Modified by:
 */

public class WalkSound : SoundComponent 
{
	#region PrivateMemberVariables
	private float		m_Surface;
	private float		m_PlayerSpeed;
	private GameObject	m_Player;
	private float 		m_Time;
	private float		m_StartTime;
	private bool		m_FirstTime = true;
	private string		m_WalkingOn;
	#endregion
	
	#region PublicMemberVariables
	public string	m_Material;
	public string[]	m_Parameters;
	public float	m_WalkingSoundSpeed = 0.7f;
	#endregion
	

	public override void PlaySound()
	{
		m_PlayerSpeed = Camera.main.transform.parent.gameObject.transform.rigidbody.velocity.normalized.magnitude;
		m_Time = Time.time - m_StartTime;

		if(m_PlayerSpeed != 0)
		{
			if(m_FirstTime)
			{
				m_FirstTime = false;
				m_Surface = 0.99f;
				Evt.setParameterValue (m_Parameters [0], m_Surface);
				StartEvent();
			}

			m_WalkingOn = GetMaterial();

			Debug.Log (m_WalkingOn);
			switch(m_WalkingOn)
			{
			case "Carpet":
				m_Surface = 0.05f;
				Evt.setParameterValue(m_Parameters[0], m_Surface);
				break;
			case "Wood":
				m_Surface = 0.15f;
				Evt.setParameterValue(m_Parameters[0], m_Surface);
				break;
			case "None":
				break;
			}

			if(getPlaybackState() == PLAYBACK_STATE.SUSTAINING && m_Time >= m_WalkingSoundSpeed)
			{
				StartEvent();
				m_StartTime = Time.time;
			}
		}
		//Låter skumt
		//else
		//{
		//	Evt.stop();
		//	m_FirstTime = true;
		//}
	}
	void Start () 
	{
		CacheEventInstance();
		m_StartTime = Time.time;
		m_Player = Camera.main.transform.parent.gameObject;
	}

	string GetMaterial()
	{
		RaycastHit hit;
		Ray ray = new Ray(m_Player.transform.position, -transform.up);
		//DEBUG RAY YEY
		Debug.DrawRay (ray.origin, ray.direction * (m_Player.transform.lossyScale.y + 0.25f), Color.yellow);

		if(Physics.Raycast (ray, out hit, (m_Player.transform.lossyScale.y + 0.25f)))
		{
			if(hit.collider.gameObject.GetComponent<WalkSound>() != null)
			{
				return hit.collider.gameObject.GetComponent<WalkSound>().m_Material;
			}
		}
		return null;
	}

	void Update () 
	{
		var attributes = UnityUtil.to3DAttributes (m_Player);
		ERRCHECK (Evt.set3DAttributes(attributes));			
	}

	void FixedUpdate()
	{
		PlaySound ();
	}
}
