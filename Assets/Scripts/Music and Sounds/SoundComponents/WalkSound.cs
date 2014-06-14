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
	private bool		m_PlayWalkingSound = true;
<<<<<<< HEAD
=======
	private string		m_Material;
	private Vector3 	m_LastPosition;
	private float		m_SprintSpeed = 0.075f;
	private float		m_WalkingSoundSpeed;
>>>>>>> 92beaf40a036c549a2d3df76d99f75233488c66d
	#endregion
	
	#region PublicMemberVariables
	public string	m_Material;
	public string[]	m_Parameters;
	private float	m_DistanceBeforeSound = 0.055f;

	#endregion

	public bool PlayWalkingSound
	{
		get{return m_PlayWalkingSound;}
		set{m_PlayWalkingSound = value;}
	}

	public override void PlaySound()
	{
<<<<<<< HEAD
		m_PlayerSpeed = Camera.main.transform.parent.gameObject.transform.rigidbody.velocity.normalized.magnitude;
		m_Time = Time.time - m_StartTime;
=======
		Vector3 position = this.gameObject.GetComponent<FirstPersonController> ().Position;
		float distance;
>>>>>>> 92beaf40a036c549a2d3df76d99f75233488c66d

		m_PlayerSpeed = this.gameObject.rigidbody.velocity.normalized.magnitude;
		distance = Vector3.Distance (position, m_LastPosition);
		m_Time = Time.time - m_StartTime;
		
		if(distance > (m_DistanceBeforeSound))
		{
			m_LastPosition = position;
			m_WalkingSoundSpeed = 0.75f;

			if(distance > m_SprintSpeed)
			{
				m_WalkingSoundSpeed = 0.55f;
			}

			if(m_FirstTime)
			{
				m_FirstTime = false;
				m_Surface = 0.99f;
				Evt.setParameterValue (m_Parameters [0], m_Surface);
				StartEvent();
			}
<<<<<<< HEAD

			switch(m_Material)
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
				Debug.Log (m_Time);
				m_StartTime = Time.time;
=======
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
>>>>>>> 92beaf40a036c549a2d3df76d99f75233488c66d
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
<<<<<<< HEAD
		m_Player = Camera.main.transform.parent.gameObject;
=======
		m_Player = this.gameObject;
		m_LastPosition = this.gameObject.GetComponent<FirstPersonController> ().Position;
>>>>>>> 92beaf40a036c549a2d3df76d99f75233488c66d
	}

	string GetMaterial()
	{
		RaycastHit hit;
		Ray ray = new Ray(m_Player.transform.position, -transform.up);
		Debug.DrawRay (ray.origin, ray.direction * (m_Player.transform.lossyScale.y + 0.10f), Color.yellow);

		if(Physics.Raycast (ray, out hit, (m_Player.transform.lossyScale.y + 0.25f)))
		{
			if(hit.collider.gameObject.GetComponent<WalkSound>() != null)
			{
<<<<<<< HEAD
				return hit.collider.gameObject.GetComponent<WalkSound>().m_Material;
=======
				return hit.collider.gameObject.GetComponent<FloorMaterial>().FloorType;
>>>>>>> 92beaf40a036c549a2d3df76d99f75233488c66d
			}
		}
		return null;
	}

	void Update () 
	{
<<<<<<< HEAD
		if(PlayWalkingSound)
=======
		var attributes = UnityUtil.to3DAttributes (m_Player);
		ERRCHECK (Evt.set3DAttributes(attributes));			
	}

	void FixedUpdate()
	{
		Vector3 speed = new Vector3 ();
		//m_PlayerSpeed = this.gameObject.transform.rigidbody.velocity.normalized.magnitude;
		speed = new Vector3(this.gameObject.transform.rigidbody.velocity.normalized.x, 0, this.gameObject.transform.rigidbody.velocity.normalized.z);
		m_PlayerSpeed = speed.normalized.magnitude;
		

		m_Time = Time.time - m_StartTime;
		if(m_PlayerSpeed != 0)
>>>>>>> 92beaf40a036c549a2d3df76d99f75233488c66d
		{
			if(PlayWalkingSound)
			{
				PlaySound();
			}
		}

		var attributes = UnityUtil.to3DAttributes (m_Player);
		ERRCHECK (Evt.set3DAttributes(attributes));			
	}
}
