using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/* Discription: MovieAudio
 * The audio that playes with the movie
 * 
 * Created by: Sebastian Olsson 08/05-14
 * Modified by:
 */

public class MovieAudio : TriggerComponent 
{
	#region PrivateMemberVariables
	private MoviePlayer		m_Movie; 
	private GameObject		m_Monitor;
	private AudioStack		m_AudioStack;
	private float			m_Counter;
	#endregion
	
	#region PublicMemberVariables
	public int				m_MoviePlaceInStack;
	#endregion

	override public string Name
	{
		get{ return "PlayMovie"; }
	}

	void Start () 
	{
		m_Movie = this.gameObject.GetComponent<MoviePlayer> ();

		List<Id> ids = UnityEngine.Object.FindObjectsOfType<Id>().ToList();
		foreach(Id i in ids)
		{
			if(i.ObjectId == m_Movie.m_TargetID)
			{
				m_Monitor = i.gameObject;
			}
		}
		m_AudioStack = m_Monitor.GetComponent<AudioStack> ();
	}

	public void PlayMovie()
	{
		m_AudioStack.Play ();
	}


	void Update () 
	{
		m_Counter = m_AudioStack.Counter;
		if(m_Counter == m_MoviePlaceInStack)
		{
			m_Movie.PlayMovieVideo();
		}
	}

	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
