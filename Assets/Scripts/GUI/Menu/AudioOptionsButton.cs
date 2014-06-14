using UnityEngine;
using System.Collections;

/*
 * 
 * Created By: Jon Wahlström 2014-05-06
 * Modified By: 
 */

public class AudioOptionsButton : MonoBehaviour 
{
	public enum Name{Master, Music, Sound, VoiceOver};

	public Name _Name = Name.Master;

	void Update()
	{
		EventDelegate.Add(gameObject.GetComponent<UIScrollBar>().onChange, ChangeVolume);
	}

	void ChangeVolume()
	{
		float value = gameObject.GetComponent<UIScrollBar> ().value;
		Debug.Log ("value " +  value);
		switch (_Name) 
		{
		case Name.Master:
			AudioOptionsWindow.ChangeVolume ("master", value);
			break;
		case Name.Music:
			AudioOptionsWindow.ChangeVolume ("music", value);
			break;
		case Name.Sound:
			AudioOptionsWindow.ChangeVolume ("sound", value);
			break; 
		case Name.VoiceOver:
			AudioOptionsWindow.ChangeVolume ("voiceOver", value);
			break;
		}
	}
}
