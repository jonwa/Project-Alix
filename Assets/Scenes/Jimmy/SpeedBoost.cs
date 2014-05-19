using UnityEngine;
using System.Collections;

public class SpeedBoost : MonoBehaviour 
{
	public enum dir { FORWARD, BACKWARD, LEFT, RIGHT, UP, DOWN };
	public dir direction = dir.FORWARD;
	public float speed = 2.0f;
	
	
	
	void OnCollisionStay(Collision collisionInfo)
	{
		switch(direction)
		{
		case dir.FORWARD:
			collisionInfo.rigidbody.AddForce((transform.forward*speed*10));
			break;
		case dir.BACKWARD:
			collisionInfo.rigidbody.AddForce((-transform.forward*speed*10));
			break;
		case dir.LEFT:
			collisionInfo.rigidbody.AddForce((-transform.right*speed*10));
			break;
		case dir.RIGHT:
			collisionInfo.rigidbody.AddForce((transform.right*speed*10));
			break;
			case dir.UP:
			collisionInfo.rigidbody.AddForce((transform.up*speed*10));
			break;
			case dir.DOWN:
			collisionInfo.rigidbody.AddForce((-transform.up*speed*10));
			break;
		}
	}
}
