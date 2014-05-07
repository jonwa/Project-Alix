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
	#endregion

	override public string Name
	{
		get{ return "PlayMovie"; }
	}

	void PlayMovie()
	{
		GameObject TextureTarget = null;
		List<Id> ids = UnityEngine.Object.FindObjectsOfType<Id>().ToList();
		foreach(Id i in ids)
		{
			if(i.ObjectId == m_TargetID)
			{
				TextureTarget = i.gameObject;
			}
		}
		TextureTarget.gameObject.renderer.material.mainTexture = m_Movie;
		m_Movie.Stop();
		m_Movie.Play();
	}

	void Start () 
	{
		m_Started = false;
	}

	void Update()
	{
		if(m_NonTrigger)
		{
			gameObject.renderer.material.mainTexture = m_Movie;
			//m_Movie.Stop();
			m_Movie.Play();
			m_Movie.loop = true; 
		}
	}
	

	//Overload when saveing data for component.
	public override void Serialize(ref JSONObject jsonObject)
	{
		
	}
	
	//Overload when loading data for component.
	public override void Deserialize(ref JSONObject jsonObject)
	{
		
	}
}
