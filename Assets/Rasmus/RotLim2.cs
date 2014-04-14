using UnityEngine;
using System.Collections;	

public class RotLim2 : MonoBehaviour 
{
	private Quaternion m_LastPosition;
	private float m_OriginalRotation;
	private float m_Difference;
	// Use this for initialization
	void Start () 
	{
		m_LastPosition = transform.localRotation;
		m_OriginalRotation = transform.localRotation.eulerAngles.y;
		m_Difference=0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(m_LastPosition != transform.localRotation)
		{
			//Debug.Log("Skall spara en position");
			m_Difference = m_OriginalRotation - transform.localRotation.eulerAngles.y;
			m_Difference = Mathf.Abs(m_Difference);
			Debug.Log("Setting difference" + m_Difference);
			SendMessageUpwards("SetDifference", m_Difference);
		}
	}

	public void SetOriginal()
	{
		m_OriginalRotation = transform.localRotation.eulerAngles.y;
	}
}
