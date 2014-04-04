using UnityEngine;
using System.Collections;

/* Discription: Move Component
 * 
 * Created by: Sebastian 02/04-14
 * Modified by:
 */

public class Move : ObjectComponent 
{
	#region PUBLIC MEMBERS
	public Transform heldObject;
	#endregion //PUBLIC MEMBERS
	
	#region PRIVATE MEMBERS
	private GameObject m_Target;
	private Vector3 touchOffset;
	private bool dragging = false;
	#endregion //PRIVATE MEMBERS

	void Start()
	{
	}

	void Update()
	{


	}
	public override void Interact()
	{

			if(Input.GetMouseButton(0))
			{
				m_Target = transform.gameObject;
				//Vector3 screenPoint = Camera.main.WorldToScreenPoint(m_Target.transform.position);
				//Debug.Log ("ScreenPoint: " + screenPoint);
				

			if(m_Target != null)
				{
					/*calculate offset*/
					Vector3 screenPoint = Camera.main.WorldToScreenPoint(m_Target.transform.position);
					

					/*calculate offset from camera*/
					Vector3 offset = m_Target.transform.position - Camera.main.transform.position;
					Debug.Log ("Offset: " + offset);

					//Fuck this shietttt
					//form the current position
					Vector3 curPosition = Camera.main.transform.position + offset;
					Debug.Log ("Curposition: " + curPosition);

					
				m_Target.transform.position = curPosition;
				}
			}
			

	}

	/*
	public override void Interact()
	{
		if(Input.GetMouseButton(0))
		{

			//m_Movement += Input.GetAxis("Mouse Y") * 1;
			//Moves the object forwards
			if (Input.GetAxis("Mouse Y") > 0) 
			{
				//transform.Translate(transform.TransformDirection(transform.forward) * m_Movement);
				Debug.Log ("Rör musen upp!");
			}
			//Moves the object backwards
			if (Input.GetAxis ("Mouse Y") < 0) 
			{
				//transform.Translate(transform.TransformDirection(transform.forward) * m_Movement);
				Debug.Log ("Rör musen Ner!");
			}
			//m_Movement = 0;
		}

	}
*/
}