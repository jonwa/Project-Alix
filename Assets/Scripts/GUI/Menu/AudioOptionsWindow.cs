using UnityEngine;
using System.Collections;

/*
 * 
 * Created By: Jon Wahlström 2014-05-06
 * Modified By: 
 */

public class AudioOptionsWindow : MonoBehaviour 
{
	public static void ChangeVolume(GameObject current)
	{
		float value = current.GetComponent<UIScrollBar> ().value;
	}
}
