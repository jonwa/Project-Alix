using UnityEngine;
using System;
using System.Collections;
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
	#endregion

	#region PrivateMemberVariables
	private bool							m_Started;
	#endregion

	override public string Name
	{
		get{ return "PlayMovie"; }
	}

	void PlayMovie()
	{
		Debug.Log ("Hejsan");
		if (!m_Movie.isPlaying) 
		{
			m_Movie.Stop();
			m_Movie.Play();
		}
	}

	void Start () 
	{
		renderer.material.mainTexture = m_Movie;
		m_Started = false;
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
