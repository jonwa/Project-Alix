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

public class MoviePlayer : TriggerComponent 
{
	#region PublicMemberVariables
	public MovieTexture 	m_Movie;
	public int				m_TargetID;
	public bool 			m_NonTrigger = false;
	#endregion

	#region PrivateMemberVariables
	private bool			m_Started;
	private MovieAudio		m_MovieAudio;
	private GameObject 		m_TextureTarget = null;
	private float			m_StopValue = 0.15f;
	private bool			m_HasStarted = false;
	private int				m_Counter = 0;
	private Texture			m_OriginalTexture;
	private GameObject		m_Monitor;
	#endregion

	override public string Name
	{
		get{ return "PlayMovie"; }
	}

	public MovieTexture Movie
	{
		get{return m_Movie;}
	}

	void PlayMovie()
	{
		List<Id> ids = UnityEngine.Object.FindObjectsOfType<Id>().ToList();
		foreach(Id i in ids)
		{
			if(i.ObjectId == m_TargetID)
			{
				m_TextureTarget = i.gameObject;
				m_Monitor = i.gameObject;
			}
		}
		m_MovieAudio = m_Monitor.GetComponent<MovieAudio> ();
		m_TextureTarget.renderer.material.mainTexture = m_Movie;
		m_Movie.Stop();
		m_Movie.Play();
		m_MovieAudio.PlaySound ();
		m_HasStarted = true;
	}

	void Start () 
	{
		m_OriginalTexture = renderer.material.mainTexture;
		m_Started = false;
	}


	void Update()
	{
		if(m_NonTrigger)
		{
			gameObject.renderer.material.mainTexture = m_Movie;
			m_Movie.Play();
			m_Movie.loop = true; 
		}
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
