using UnityEngine;
using System.Collections;

/*Class for the camera, works for mouse or xBoxcontroller
 * 
 * Made by: Rasmus 02/04
 * 
 * Will support Oculus in the future
 * */

public class FirstPersonCamera : MonoBehaviour 
{
	#region PublicMemberVariables
	public float m_minimumY = -60F;
	public float m_maximumY = 60F;
	public bool m_Oculus = false;
	public bool m_Locked = false;
	//public bool m_XboxController = false;
	public float m_sensitivity = 5;
	#endregion

	#region PrivateMemberVariables
	private float m_rotationY = 0F;
	#endregion

	// Use this for initialization
	void Start () 
	{
	
	}

	// Update is called once per frame
	void Update () 
	{
		//Camera without Oculus
		if(m_Oculus == false)
		{
			//Locks the camera when inspection objects
			if(m_Locked== false){
				//Rotation Y
				m_rotationY += Input.GetAxis("Mouse Y") * m_sensitivity;
				m_rotationY = Mathf.Clamp (m_rotationY, m_minimumY, m_maximumY);
				transform.localEulerAngles = new Vector3(-m_rotationY, transform.localEulerAngles.y, 0);

				//Call parents for x rotation
				this.SendMessageUpwards("RotateCharacter", m_sensitivity);
			}

			//Locks the camera when inspection objects
			if(m_Locked== false){
				//Rotation Y
				m_rotationY += Input.GetAxis("xBoxVertical") * m_sensitivity;
				m_rotationY = Mathf.Clamp (m_rotationY, m_minimumY, m_maximumY);
				transform.localEulerAngles = new Vector3(-m_rotationY, transform.localEulerAngles.y, 0);
				
				//Call parents for x rotation
				this.SendMessageUpwards("RotateCharacterJoystick", m_sensitivity);
			}
		}
		//Camera with Oculus rift, for later use
		else
		{
			//Shall be replaced for different input with oculus
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * m_sensitivity;
			
			m_rotationY += Input.GetAxis("Mouse Y") * m_sensitivity;
			m_rotationY = Mathf.Clamp (m_rotationY, m_minimumY, m_maximumY);
			
			transform.localEulerAngles = new Vector3(-m_rotationY, rotationX, 0);
		}
	}

	//Function for locking and unlocking the camera.
	public void LockCamera()
	{
		m_Locked=true;
	}

	public void UnLockCamera()	
	{
		m_Locked=false;
	}

}
