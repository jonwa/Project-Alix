using UnityEngine;
using System.Collections;

/* Discription: AmbientSound
 * Is used to play the ambient sound of the house and is playing pretty much all game
 * 
 * Created by: Sebastian Olsson 21/05-14
 * Modified by:
 */

public class AmbientSound : SoundComponent
{
	#region PublicMemberVariables
	public string[]	m_Parameters;
	#endregion

	public void ChangeParameter(string p_Name, float p_Value)
	{
		Evt.setParameterValue(p_Name, p_Value);
		StartEvent();
	}

	void Start () 
	{
		CacheEventInstance ();
		StartEvent ();
	}

	public void TurnOff()
	{
		Evt.stop ();
	}
}
