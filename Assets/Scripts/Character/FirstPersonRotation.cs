using UnityEngine;
using System.Collections;
/*Rasmus Björk 02/04
 * Class for rotation of character, called from FirstPersonCamera
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
	void RotateCharacter()
	{
		transform.Rotate(0, Input.GetAxis("Mouse X") * 5, 0);
	}
	void RotateCharacterJoystick()
	{
		transform.Rotate(0, Input.GetAxis("xBoxHorizontal") * 5, 0);
	}

}
