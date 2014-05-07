using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FMOD.Studio;

/* Discription: MoviePlayer, starts a Movie, when triggered
 * 
 * Created by: Sebastian Olsson: 23-04-2014
 * Modified by: 
 * 
 */

[RequireComponent(typeof(SoundEffect))]
public class MoviePlayer : TriggerComponent 
{
	#region PublicMemberVariables
	public MovieTexture 	m_Movie;
	public int				m_TargetID;
	#endregion

	#region PrivateMemberVariables
	private bool			m_Started;
	private SoundEffect		m_SoundEffect;
	private GameObject 		m_TextureTarget = null;
	private float			m_StopValue = 0.15f;
	private bool			m_HasStarted = false;
	private int				m_Counter = 0;
	private Texture			m_OriginalTexture;
	#endregion

	override public string Name
	{
		get{ return "PlayMovie"; }
	}

	void PlayMovie()
	{

		List<Id> ids = UnityEngine.Object.FindObjectsOfType<Id>().ToList();
		foreach(Id i in ids)
		{
			if(i.ObjectId == m_TargetID)
			{
				m_TextureTarget = i.gameObject;
			}
		}
		m_TextureTarget.renderer.material.mainTexture = m_Movie;
		m_Movie.Stop();
		m_Movie.Play();
		m_HasStarted = true;
	}

	void Start () 
	{
		m_OriginalTexture = renderer.material.mainTexture;
		m_SoundEffect = this.GetComponent<SoundEffect> ();
		m_Started = false;
	}

	void PlayExitSound()
	{
		if(!m_Movie.isPlaying && m_HasStarted && m_Counter < 1)
		{
			Debug.Log ("DONE PLAYING");
			m_SoundEffect.Parameter = m_StopValue;
			m_SoundEffect.PlaySoundEffect();
			m_Counter++;
		}
	}

	void Update()
	{
		PlayExitSound ();
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
