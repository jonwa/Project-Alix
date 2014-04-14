﻿using UnityEngine;
using System.Collections;

/*Class for throwing an object
Created by: Rasmus 07/04
 */

[RequireComponent(typeof(Rigidbody))]
public class Throw : ObjectComponent {
	#region PublicMemberVariables
	public float m_Force  = 10f;
	public string m_Input = "f";
	#endregion

	#region PrivateMemberVariables
	private Transform m_CameraTransform;
	#endregion

	// Use this for initialization
	void Start () {
		m_CameraTransform  = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Add a force on the rigidbody and release the object
	public override void Interact ()
	{
		if(Input.GetKey(m_Input))
		{
			rigidbody.AddForce(m_CameraTransform.forward * (m_Force / rigidbody.mass ));
			//Camera.main.SendMessage("ReleaseObject");
		}
	}
}