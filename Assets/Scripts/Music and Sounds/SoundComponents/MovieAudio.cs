using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FMOD.Studio;

/* Discription: MovieAudio
 * The audio that playes with the movie
 * 
 * Created by: Sebastian Olsson 08/05-14
 * Modified by:
 */

public class MovieAudio : SoundComponent 
{
	#region PrivateMemberVariables
	private MoviePlayer		m_Movie;
	private GameObject		m_GameObject;
	#endregion
	
	#region PublicMemberVariables

	#endregion

	void Start () 
	{
		CacheEventInstance();
		m_GameObject = this.gameObject;
	}

	public override void PlaySound()
	{
		if(Evt != null)
		{
			StartEvent ();
		}

	}

	void Update () 
	{
		var attributes = UnityUtil.to3DAttributes (m_GameObject);
		ERRCHECK (Evt.set3DAttributes(attributes));	
	}
}
