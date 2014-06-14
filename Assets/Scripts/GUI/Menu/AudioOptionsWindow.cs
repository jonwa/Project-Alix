using UnityEngine;
using System.Collections;

/*
 * 
 * Created By: Jon Wahlström 2014-05-06
 * Modified By: 
 */

public class AudioOptionsWindow : MonoBehaviour 
{

	public Camera m_Camera; 


	private static Camera _camera; 

	void Start()
	{
		_camera = m_Camera;
	}

	public static void ChangeVolume(string name, float value)
	{
		_camera.GetComponent<MusicOptions> ().setVolume (name, value);
	}
}
