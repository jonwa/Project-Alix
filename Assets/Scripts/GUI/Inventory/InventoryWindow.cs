using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Interface for the inventory background window
 * 
 * Created By: Jon Wahlström 2014-04-02
 * Modified By: 
 */

public class InventoryWindow : MonoBehaviour 
{
	private Vector3 m_MousePosition; 
	private float m_Speed = 5f;
	private bool m_Pressed = false;

	private Camera m_Camera;

	void Start()
	{
		m_Camera = GameObject.Find("Camera").camera;
	}

	void OnPress(bool pressed)
	{
		m_Pressed = pressed;
	}

	void Update()
	{
		if(m_Pressed)
		{
			//Moves the window towards the mouse position
			m_MousePosition    = m_Camera.ScreenToWorldPoint(Input.mousePosition);
			m_MousePosition.z  = 0f;
			transform.position = Vector3.MoveTowards (transform.position, m_MousePosition, m_Speed * Time.deltaTime);
		}
	}
}
