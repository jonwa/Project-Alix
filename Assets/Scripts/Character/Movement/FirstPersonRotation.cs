using UnityEngine;
using System.Collections;
/* Class for rotation of character, called from FirstPersonCamera
 * 
 * Made by: Rasmus Björk 02/04
 * */

public class FirstPersonRotation : MonoBehaviour 
{
	// Use this for initialization	
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	//Called from FirstPersonCamera
	void RotateCharacter(float sensitivity)
	{
		transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
	}

	void RotateCharacterJoystick(float sensitivity)
	{
		transform.Rotate(0, Input.GetAxis("xBoxHorizontal") * sensitivity, 0);
	}

}
