using UnityEngine;
using System.Collections;

/* Placed on the character. Handles movement WASD and with Controller.
 * 
 * Created by: 	Jimmy Nilsson 14-04-02
 * Modified by:	
 */

[RequireComponent(typeof(Rigidbody))]
public class CharacterController : MonoBehaviour 
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
	#endregion

	void Awake()
	{
		rigidbody.useGravity = false;
		rigidbody.freezeRotation = true;
	}

	/*
	 * The function that handles all movement 
	 */
	void Move(float deltaTime)
	{
		if(m_Grounded)
		{
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
			}

			targetVelocity	*= maxVelocity;
			velocity  		 = (targetVelocity-velocity);
			velocity.x 		 = Mathf.Clamp(velocity.x, -maxVelocity, maxVelocity);
			velocity.y 		 = 0; 
			velocity.z 		 = Mathf.Clamp(velocity.z, -maxVelocity, maxVelocity);

			//add movement force, x/z
			rigidbody.AddForce(velocity, ForceMode.VelocityChange);

			//Jump logic
			if(Input.GetButton("Jump"))
			{

				rigidbody.velocity = new Vector3(rigidbody.velocity.x,CalculateJumpForce(),rigidbody.velocity.z);
			}
		}

		//Gravity
		rigidbody.AddForce(new Vector3(0, -m_Gravity*rigidbody.mass, 0));
		m_Grounded = false;

	}

	float CalculateJumpForce()
	{
		return Mathf.Sqrt(2* m_JumpForce * m_Gravity);
	}

	void OnCollisionStay(Collision collisionInfo)
	{
		RaycastHit rayHitInfo;
		Physics.Raycast(transform.position, transform.up*-1, out rayHitInfo, 1); 

		if(rayHitInfo.collider != null)
		{
			m_Grounded = true;
		}

	}

	void FixedUpdate()
	{
		Move(Time.fixedDeltaTime);
	}
}
