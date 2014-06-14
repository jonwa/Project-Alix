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
	private GameObject 		m_TextureTarget = null;
	private float			m_StopValue = 0.15f;
	private int				m_Counter = 0;
	private Texture			m_OriginalTexture;
	private GameObject		m_Monitor;
	#endregion

	override public string Name
	{
		get{ return "PlayMovieVideo"; }
	}
	
	public void PlayMovieVideo()
	{
		m_TextureTarget.renderer.material.mainTexture = m_Movie;

		m_Movie.Play();

	}

	void Start () 
	{
		m_OriginalTexture = renderer.material.mainTexture;
		m_Started = false;

		List<Id> ids = UnityEngine.Object.FindObjectsOfType<Id>().ToList();
		foreach(Id i in ids)
		{
			if(i.ObjectId == m_TargetID)
			{
				m_TextureTarget = i.gameObject;
				m_Monitor = i.gameObject;
			}
		}
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
