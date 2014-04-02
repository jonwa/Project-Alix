using UnityEngine;
using System.Collections;
/*Rasmus Björk 02/04
 * Temporär klass för rotation av spelaren
 * */

public class Andy : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	//Anropas från kameran
	void RotateChar()
	{
		transform.Rotate(0, Input.GetAxis("Mouse X") * 5, 0);
	}

}
