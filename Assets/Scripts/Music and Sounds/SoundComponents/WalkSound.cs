using UnityEngine;
using System.Collections;

/* Discription: WalkSound
 * Sound for footsteps
 * 
 * Created by: Sebastian Olsson 14/05-14
 * Modified by:
 */

//TODO: ALLT

public class WalkSound : SoundComponent 
{
	#region PrivateMemberVariables
	private float	m_Action;
	#endregion
	
	#region PublicMemberVariables
	public string	m_Material;
	public string[]	m_Parameters;
	#endregion
	
	
	public override void PlaySound()
	{
		switch(m_Material)
		{
		case "Wood":
			break;

		}
		//(m_Material == "Wood")
		{
			m_Action = 0.15f;
			Evt.setParameterValue(m_Parameters[0], m_Action);
			StartEvent();
		}
	//	else if(m_Material == "Other")
		{

		}
	}
	void Start () 
	{
	
	}
	
	void Update () 
	{
		
	}
}
