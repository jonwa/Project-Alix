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
	public MovieTexture[] 	m_Movies;
	#endregion

	#region PrivateMemberVariables
	private bool			m_Started;
	#endregion

	override public string Name
	{
		get{ return "PlayMovie"; }
	}

	void PlayMovie(int mov)
	{
		renderer.material.mainTexture = m_Movies[mov];
		if (!m_Movies[mov].isPlaying) 
		{
			for(int i = 0; i < m_Movies.Length; i++)
			{
				m_Movies[i].Stop();
			}
			m_Movies[mov].Play();
		}
	}

	void Start () 
	{
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
