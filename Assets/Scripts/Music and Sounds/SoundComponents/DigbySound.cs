using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class DigbySound : ObjectComponent
{
	#region PublicMemberVariables

	#endregion
	#region PrivateMemberVariables
	private bool			m_Played;
	private DigbyFoundYou	m_Digby;
	private bool			m_Active = false;
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
		if(audiostack.SoundStackCount == 0 && audiostack.getPlaybackState() == PLAYBACK_STATE.SUSTAINING && !m_Active)
		{
			m_Active = true;
			m_Digby = GameObject.FindObjectOfType<DigbyFoundYou>() as DigbyFoundYou;
			m_Digby.Play();
		}

	}
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}
