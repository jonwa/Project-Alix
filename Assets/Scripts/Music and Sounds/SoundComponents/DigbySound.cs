using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class DigbySound : ObjectComponent
{
	#region PublicMemberVariables

	#endregion
	#region PrivateMemberVariables
	private float	m_Distance;
	private bool	m_Played;
	private bool	m_Entered 		= false;
	private bool	m_Line1 		= false;
	#endregion

	public override void Interact()
	{
		Camera.main.SendMessage("Release");
		if(!m_Played)
		{
			m_Played = true;
			this.GetComponent<AudioStack>().Play ();
		}
	
	}

	void Start () 
	{
	}

	void Update () 
	{
		AudioStack audiostack = this.GetComponent<AudioStack> ();
		if(audiostack.SoundStackCount == 0 && audiostack.getPlaybackState() == PLAYBACK_STATE.SUSTAINING)
		{
			//TODO: Check if player is in a safe zone else die :>
			Debug.Log ("DÖD Motha fucka");
		}

	}
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
