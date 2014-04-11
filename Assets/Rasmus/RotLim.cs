using UnityEngine;
using System.Collections;

public class RotLim : MonoBehaviour 
{
	public float m_MaxLimit = 180;
	public float m_MinLimit = 0;

	public bool m_Locked=false;

	private float m_OriginalRotation;
	Vector3 m_pos;
	// Use this for initialization
	void Start () 
	{
		m_OriginalRotation = transform.localRotation.eulerAngles.y;
		Debug.Log(m_OriginalRotation);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!m_Locked)
		{
			//Debug.Log(transform.localRotation.eulerAngles.y);
			if(transform.localRotation.eulerAngles.y > 180 && transform.localRotation.eulerAngles.y <= 270)
			{
				transform.position = m_pos;
				//Debug.Log("Över y: " + transform.localRotation.eulerAngles.y);
				transform.Rotate(0, 180-transform.localRotation.eulerAngles.y, 0);
			}
			else if(transform.localRotation.eulerAngles.y < 360 && transform.localRotation.eulerAngles.y > 270)
			{
				transform.position = m_pos;
				transform.Rotate(0, 360-transform.localRotation.eulerAngles.y, 0);
				//Debug.Log("Under y: " + transform.localRotation.eulerAngles.y);
			}
			else
			{
				m_pos = transform.position;
			}
		}
		else
		{
			//Debug.Log(transform.localRotation.eulerAngles.y);
			if(transform.localRotation.eulerAngles.y > 95)
			{
				transform.position = m_pos;
				//Debug.Log("Över y: " + transform.localRotation.eulerAngles.y);
				transform.Rotate(0, 95-transform.localRotation.eulerAngles.y, 0);
			}
			else if(transform.localRotation.eulerAngles.y < 85)
			{
				transform.position = m_pos;
				transform.Rotate(0, 85-transform.localRotation.eulerAngles.y, 0);
				//Debug.Log("Under y: " + transform.localRotation.eulerAngles.y);
			}
			else
			{
				m_pos = transform.position;
			}
		}
	}
}
