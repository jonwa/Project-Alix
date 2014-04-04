using UnityEngine;
using System.Collections;

/* Discription: ObjectComponent class for rotating items in fixed position in inspect mode
 * 
 * Created by: Robert Datum: 02/04-14
 * Modified by:
 * 
 */

public class Inspect : ObjectComponent
{
	public int m_Sensitivity;

	void Update()
	{

	}

	public override void Interact ()
	{
		if(!GetIsActive() && Input.GetKey(KeyCode.E)){
			float m_moveX = Input.GetAxis("Mouse X") * m_Sensitivity;
			float m_moveY = Input.GetAxis("Mouse Y") * m_Sensitivity;

			//state changed to inspecting or camera is locked

			//rotates the object based on mouse input

			//transform.Rotate(m_moveX,m_moveY,0,Space.Self);
			transform.RotateAround(collider.bounds.center,Vector3.left, m_moveY);
			transform.RotateAround(collider.bounds.center,Vector3.up, m_moveX);
		}
		else{
			//state to not inspecting/idle/holding or camera is unfrozen
		}
	}

}