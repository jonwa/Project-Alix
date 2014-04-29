using UnityEngine;
using System.Collections;

/* Placed on the character. Handles movement WASD and with Controller.
 * Requires a rigidbody to work!
 * 
 * Created by: 	Jimmy Nilsson 14-04-02
 * Modified by:	Jon Wahlström 2014-04-21 (Crouch, cameraposition.y is set to half the height)
 */

[RequireComponent(typeof(Rigidbody))]
public class FirstPersonController : MonoBehaviour 
{
	#region PublicMemberVariables
	public float m_MovementSpeed = 10.0f;
	public float m_SprintSpeed	 = 15.0f;
	public float m_ChrouchSpeed	 = 5.5f;

	public float m_JumpForce	 = 1.0f;
	public float m_Gravity		 = 5.0f;
	#endregion

	#region PrivateMemberVariables
	private bool m_Grounded		 = false;
	private bool m_Locked		 = false;
	#endregion

	private float m_CameraPositionY = 0f; 

	public Vector3 Position
	{
		get { return rigidbody.position; }
	}

	void Awake()
	{
		m_CameraPositionY = Camera.main.transform.position.y;
		rigidbody.useGravity = false;
		rigidbody.freezeRotation = true;
	}

	// The function that handles all movement 
	void Move(float deltaTime)
	{
		//if(m_Grounded && !m_Locked)
		if(!m_Locked)
		{
			//Vector3 cameraPosition = Camera.main.transform.position;
			//Camera.main.transform.position = new Vector3(cameraPosition.x, m_CameraPositionY, cameraPosition.z);

			Vector3 forward			= transform.forward.normalized*Input.GetAxis("Vertical");
			Vector3 right			= -transform.right.normalized*Input.GetAxis("Horizontal");
			Vector3 targetVelocity  = new Vector3(forward.x-right.x, 0.0f, forward.z-right.z);

			Vector3 velocity 		= rigidbody.velocity;
			float	maxVelocity		= m_MovementSpeed;


			if(Input.GetButton("Sprint"))
			{
				maxVelocity = m_SprintSpeed;
			}
			else if(Input.GetButton("Crouch"))
			{
				maxVelocity = m_ChrouchSpeed;
				//Camera.main.transform.position = new Vector3(cameraPosition.x, m_CameraPositionY/2, cameraPosition.z);
			}

			targetVelocity	*= maxVelocity;
			velocity  		 = (targetVelocity-velocity);
			velocity.x 		 = Mathf.Clamp(velocity.x, -maxVelocity, maxVelocity);
			velocity.y 		 = 0; 
			velocity.z 		 = Mathf.Clamp(velocity.z, -maxVelocity, maxVelocity);

			//add movement force, x/z
			rigidbody.AddForce(velocity, ForceMode.VelocityChange);

			//Jump logic
			//if(Input.GetButton("Jump"))
			//{
			//
			//	rigidbody.velocity = new Vector3(rigidbody.velocity.x,CalculateJumpForce(),rigidbody.velocity.z);
			//}
		}
		else if(m_Locked)
		{
			rigidbody.velocity = new Vector3(0f, 0f, 0f);
		}
		//Gravity
		rigidbody.AddForce(new Vector3(0, -m_Gravity*rigidbody.mass, 0));
		m_Grounded = false;

	}

	float CalculateJumpForce()
	{
		return Mathf.Sqrt(2* m_JumpForce * m_Gravity);
	}

	/*
	 * When the object collides with another object, cast a ray down, 
	 * this is done to see if we are standing on something or colliding with a wall!
	 */
	void OnCollisionStay(Collision collisionInfo)
	{
		RaycastHit rayHitInfo;
		Physics.Raycast(transform.position, transform.up*-1, out rayHitInfo, 1); 

		if(rayHitInfo.collider != null)
		{
			m_Grounded = true;
		}

	}

	//Locks player movement WASD
	public void LockPlayerMovement()
	{
		m_Locked = true;
	}

	//Unlocks player movement WASD
	public void UnLockPlayerMovement()
	{
		m_Locked = false;
	}

	void FixedUpdate()
	{
		Move(Time.fixedDeltaTime);
	}
}
