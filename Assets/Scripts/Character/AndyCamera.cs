using UnityEngine;
using System.Collections;

/*Rasmus 02/04
 * Kameraklassen, fungerar med eller utan oculus
 * */

public class AndyCamera : MonoBehaviour 
{
	public float m_minimumY = -60F;
	public float m_maximumY = 60F;
	public bool m_isOculus = false;
	public bool m_isLocked = false;
	float m_rotationY = 0F;

	// Use this for initialization
	void Start () 
	{
	
	}

	// Update is called once per frame
	void Update () 
	{
		//Kameran utan Oculus
		if(m_isOculus == false)
		{
			//Låser kameran vid inspektion av object
			if(m_isLocked== false){
				//Rotation Y
				m_rotationY += Input.GetAxis("Mouse Y") * 5;
				m_rotationY = Mathf.Clamp (m_rotationY, m_minimumY, m_maximumY);
				transform.localEulerAngles = new Vector3(-m_rotationY, transform.localEulerAngles.y, 0);

				//Anropar förälder för rotation x
				this.SendMessageUpwards("RotateChar");
			}
		}
		//Kamera med Oculus rift
		else
		{
			//Skall vara för oculus, musen simulerar fortfarande rörelserna
			//Roterar x och y oberoende av förälder
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * 5;
			
			m_rotationY += Input.GetAxis("Mouse Y") * 5;
			m_rotationY = Mathf.Clamp (m_rotationY, m_minimumY, m_maximumY);
			
			transform.localEulerAngles = new Vector3(-m_rotationY, rotationX, 0);
		}
	}

	public void LockCamera()
	{
		m_isLocked=true;
	}

	public void UnLockCamera()
	{
		m_isLocked=false;
	}

}
