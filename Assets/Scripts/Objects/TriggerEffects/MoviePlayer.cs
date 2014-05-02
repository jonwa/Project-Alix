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
	public MovieTexture[] 	m_Movies;
	public int				m_TargetID;
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
		GameObject TextureTarget = null;
		List<Id> ids = UnityEngine.Object.FindObjectsOfType<Id>().ToList();
		foreach(Id i in ids)
		{
			if(i.ObjectId == m_TargetID)
			{
				TextureTarget = i.gameObject;
			}
		}
		TextureTarget.gameObject.renderer.material.mainTexture = m_Movies[mov];
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
