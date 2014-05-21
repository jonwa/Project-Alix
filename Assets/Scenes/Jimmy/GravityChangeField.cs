using UnityEngine;
using System.Collections;

public class GravityChangeField : MonoBehaviour 
{
public enum direction { up, down, left, right }
	public direction _Direction = direction.up;
	int counter = 0;
	bool shouldTurn = false;
	Transform player = null;
	
	
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			shouldTurn = true;
			player = other.transform;
			other.gameObject.AddComponent<ConstantForce>();
			
			if(_Direction == direction.up)
			{
				other.gameObject.constantForce.force = new Vector3(0,2f,0);
			}
			else if(_Direction == direction.left)
			{
				other.gameObject.constantForce.force = new Vector3(-2,0f,0);
				other.rigidbody.useGravity = false;
			}
			else if(_Direction == direction.right)
			{
				other.gameObject.constantForce.force = new Vector3(2,0f,0);
				other.rigidbody.useGravity = false;
			}
		}
	}
	
	void Update()
	{
		if(shouldTurn)
		{
		
			if(_Direction == direction.up)
			{
				counter++;
				player.RotateAround(player.position, Vector3.forward, 2);
				if(counter >= 90)
				{
					shouldTurn = false;
					counter = 0;
				}
			}
			else if(_Direction == direction.left)
			{
				counter++;
				player.RotateAround(player.position, Vector3.forward, 2);
				if(counter >= 45)
				{
					shouldTurn = false;
					counter = 0;
				}
			}
			else if(_Direction == direction.right)
			{
				counter++;
				player.RotateAround(player.position, Vector3.forward, -2);
				if(counter >= 45)
				{
					shouldTurn = false;
					counter = 0;
				}			
			}
		

		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			other.rigidbody.useGravity = true;
			shouldTurn = true;
			player = other.transform;
			Destroy(other.gameObject.GetComponent<ConstantForce>());
		}
	}
	

}
