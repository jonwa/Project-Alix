using UnityEngine;
using System.Collections;

/*
 * 
 * Created By: Jon Wahlström 2014-05-06
 * Modified By: 
 */

public class AudioOptionsButton : MonoBehaviour 
{
	public GameObject m_VolumeScrollBar;

	void OnDrag()
	{
		AudioOptionsWindow.ChangeVolume (m_VolumeScrollBar);
	}
}
