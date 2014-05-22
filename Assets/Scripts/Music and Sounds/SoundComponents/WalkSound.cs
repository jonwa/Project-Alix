using UnityEngine;
using System.Collections;
using FMOD.Studio;

/* Discription: WalkSound
 * Sound for footsteps, put this script on the player
 * 
 * Created by: Sebastian Olsson 21/05-14
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
	private bool		m_PlayWalkingSound = true;
	private string		m_Material;
	private Vector3 	m_LastPosition;
	#endregion
	
	#region PublicMemberVariables
	public string[]	m_Parameters;
	public float	m_WalkingSoundSpeed = 0.7f;
	#endregion

	public bool PlayWalkingSound
	{
		get{return m_PlayWalkingSound;}
		set{m_PlayWalkingSound = value;}
	}

	public override void PlaySound()
	{
		Vector3 position = this.gameObject.GetComponent<FirstPersonController> ().Position;
		m_PlayerSpeed = this.gameObject.rigidbody.velocity.normalized.magnitude;

		//Debug.Log (Vector3.Distance(position, m_LastPosition));
		m_Time = Time.time - m_StartTime;
		//if(m_LastPosition != position)
		if(Vector3.Distance(position, m_LastPosition) > 0.075f)
		{
			m_LastPosition = position;
			if(m_FirstTime)
			{
				m_FirstTime = false;
				m_Surface = 0.99f;
				Evt.setParameterValue (m_Parameters [0], m_Surface);
				StartEvent();
			}
			else
			{
				switch(GetMaterial())
				{
				case "Carpet":
					m_Surface = 0.05f;
					Evt.setParameterValue(m_Parameters[0], m_Surface);
					break;
				case "Wood":
					m_Surface = 0.15f;
					Evt.setParameterValue(m_Parameters[0], m_Surface);
					break;
				}
				
				if(getPlaybackState() == PLAYBACK_STATE.SUSTAINING && m_Time >= m_WalkingSoundSpeed)
				{
					StartEvent();
					m_StartTime = Time.time;
				}
			}
		}
		else
		{
			m_LastPosition = position;
		}
	}
	void Start () 
	{
		CacheEventInstance();
		m_StartTime = Time.time;
		m_Player = this.gameObject;
		m_LastPosition = this.gameObject.GetComponent<FirstPersonController> ().Position;
	}

	string GetMaterial()
	{
		RaycastHit hit;
		Ray ray = new Ray(m_Player.transform.position, -transform.up);
		Debug.DrawRay (ray.origin, ray.direction * (m_Player.transform.lossyScale.y + 0.10f), Color.yellow);

		if(Physics.Raycast (ray, out hit, (m_Player.transform.lossyScale.y + 0.25f)))
		{
			if(hit.collider.gameObject.GetComponent<FloorMaterial>() != null)
			{
				return hit.collider.gameObject.GetComponent<FloorMaterial>().FloorType;
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
		if(PlayWalkingSound)
		{
			PlaySound();
		}
	}
}
