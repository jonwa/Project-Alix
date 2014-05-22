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
<<<<<<< HEAD
=======
		Vector3 position = this.gameObject.GetComponent<FirstPersonController> ().Position;

		m_Time = Time.time - m_StartTime;
		//Debug.Log ("LastPOs = " + m_LastPosition);
		//Debug.Log ("Position: " + position);
		if(m_LastPosition != position)
		{
			m_LastPosition = position;

>>>>>>> 3687087669129f322af8f9c2a4cc965e131e734c
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
				case "None":
					break;
				}
				
				if(getPlaybackState() == PLAYBACK_STATE.SUSTAINING && m_Time >= m_WalkingSoundSpeed)
				{
					StartEvent();
					//Debug.Log (m_Time);
					m_StartTime = Time.time;
				}
			}
<<<<<<< HEAD
		//Låter skumt
		//else
		//{
		//	Evt.stop();
		//	m_FirstTime = true;
		//}
=======
		}
		else
		{
			//Debug.Log ("STOP");
		}
>>>>>>> 3687087669129f322af8f9c2a4cc965e131e734c
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
		Vector3 speed = new Vector3 ();
		//m_PlayerSpeed = this.gameObject.transform.rigidbody.velocity.normalized.magnitude;
		speed = new Vector3(this.gameObject.transform.rigidbody.velocity.normalized.x, 0, this.gameObject.transform.rigidbody.velocity.normalized.z);
		m_PlayerSpeed = speed.normalized.magnitude;
		
		Debug.Log (speed);
		
		m_Time = Time.time - m_StartTime;
		Debug.Log (m_PlayerSpeed);
		if(m_PlayerSpeed != 0)
		{
			if(PlayWalkingSound)
			{
				PlaySound();
			}
		}
	}
}
