using UnityEngine;
using System.Collections;

/* Discription: ObjectComponent class for rotating items in fixed position in inspect mode
 * 
 * Created by: Robert Datum: 16/04-14
 * Modified by: 
 * 				
 * 
 */

public class Pull : ObjectComponent
{
	#region PublicMemberVariables
	public float 	m_Sensitivity 			  = 10.0f;
	public string	m_Input;
	public string 	m_MouseAxisInputX;
	public string 	m_MouseAxisInputY;
	public string 	m_MouseAxisInputZ;
	public bool 	m_XRotation;
	public bool		m_YRotation;
	public bool		m_ZRotation;
	#endregion
	
	#region PrivateMemberVariables
	private int			m_DeActivateCounter  = 0;
	private bool		m_UnlockedCamera	 = true;
	#endregion
	
	
	void Start()
	{
	
	}
	
	void Update()
	{
		if(!IsActive)
		{
			if(m_DeActivateCounter > 10 &&  m_UnlockedCamera == false)
			{
				Camera.main.transform.gameObject.GetComponent<FirstPersonCamera>().UnLockCamera();
				Camera.main.transform.parent.GetComponent<FirstPersonController>().UnLockPlayerMovement();
				m_UnlockedCamera = true;
			}
			m_DeActivateCounter++;
		}
		else
		{
			m_DeActivateCounter++;
			
			if(m_DeActivateCounter > 5)
			{
				DeActivate();
			}
		}
	}
	
	//Lerps position and rotation of the object to the inspection Mode distance and back to original position/rotation

	public override void Interact ()
	{
		//if we are active we rotate the object with the mouse here.
		if(IsActive)
		{
			float m_move;
			if(m_XRotation){
				m_move = Input.GetAxis(m_MouseAxisInputX) * m_Sensitivity;
				//Pulls the lever in diffrent directions based on mouse input
				//transform.RotateAround(collider.bounds.center,Vector3.left, m_moveY);
				if(gameObject.GetComponent<RotationLimit>())
				{
					//Debug.Log(m_moveY);
					m_move = gameObject.GetComponent<RotationLimit>().CheckRotation(m_move,"x");
					//Debug.Log(m_moveY);
				}
				//transform.RotateAround(collider.bounds.center,Vector3.left, m_moveY);
				transform.Rotate(m_move,0,0,Space.Self);
				//transform.Rotate(
			}
			if(m_YRotation){
				m_move = Input.GetAxis(m_MouseAxisInputY) * m_Sensitivity;
				//Pulls the lever in diffrent directions based on mouse input
				//transform.RotateAround(collider.bounds.center,Vector3.left, m_moveY);
				if(gameObject.GetComponent<RotationLimit>())
				{
					m_move = gameObject.GetComponent<RotationLimit>().CheckRotation(m_move,"y");
				}
				transform.Rotate(0,m_move,0,Space.Self);
			}
			if(m_ZRotation){
				m_move = Input.GetAxis(m_MouseAxisInputZ) * m_Sensitivity;
				//Pulls the lever in diffrent directions based on mouse input
				//transform.RotateAround(collider.bounds.center,Vector3.left, m_moveY);
				if(gameObject.GetComponent<RotationLimit>())
				{
					m_move = gameObject.GetComponent<RotationLimit>().CheckRotation(m_move,"z");
				}
				transform.Rotate(0,0,m_move,Space.Self);
			}
			

		}
		
		if(Input.GetButton(m_Input))
		{
			Camera.main.transform.GetComponent<FirstPersonCamera>().LockCamera();
			Camera.main.transform.parent.GetComponent<FirstPersonController>().LockPlayerMovement();
			m_UnlockedCamera = false;
			Activate();
			m_DeActivateCounter = 0;
		}
		else
		{
			Camera.main.SendMessage("Release");
			DeActivate();
		}
	}
	public override void Serialize(ref JSONObject jsonObject){}
	public override void Deserialize(ref JSONObject jsonObject){}
}