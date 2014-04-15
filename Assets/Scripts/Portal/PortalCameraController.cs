using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Portal))]
public class PortalCameraController : MonoBehaviour 
{
	public Camera m_TargetCamera;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Transform playerTransform = Camera.main.transform.parent;

		float angle = playerTransform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y;
		m_TargetCamera.transform.eulerAngles = new Vector3(0, playerTransform.rotation.eulerAngles.y-180+angle, 0);
		 

	}
}
