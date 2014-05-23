using UnityEngine;
using System.Collections;

public class GravityChangeField : MonoBehaviour 
{
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
			other.gameObject.constantForce.force = new Vector3(0,2f,0);
		}
	}
	
	void Update()
	{
		if(shouldTurn)
		{
			counter++;
			player.RotateAround(player.position, Vector3.forward, 2);
			if(counter >= 90)
			{
				shouldTurn = false;
				counter = 0;
			}
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			shouldTurn = true;
			player = other.transform;
			Destroy(other.gameObject.GetComponent<ConstantForce>());
		}
	}
	

}
