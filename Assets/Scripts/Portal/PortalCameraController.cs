using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Portal))]
public class PortalCameraController : MonoBehaviour 
{
	private Camera m_MyCamera;
	private PortalPairHandler m_PairHandler;
	// Use this for initialization
	void Start () 
	{
		m_PairHandler = transform.parent.GetComponent<PortalPairHandler>();
	}

	public Camera GetCamera()
	{
		if(m_MyCamera == null)
		{
			m_MyCamera = GetComponent<Camera>();
		}
		return m_MyCamera;
	}

	// Update is called once per frame
	void Update () 
	{
		//Transform playerTransform = Camera.main.transform.parent;
		//float angle = playerTransform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y;
		//m_TargetCamera.transform.eulerAngles = new Vector3(0, playerTransform.rotation.eulerAngles.y-180+angle, 0);
	
		Transform	targetPortal = GetComponent<Portal>().GetT argetPortal();
		Camera 		targetCam 	 = targetPortal.GetComponent<PortalCameraController>().GetCamera();
		Camera 		cam 		 = Camera.main;
		Quaternion  q 			 = Quaternion.FromToRotation(-targetPortal.up, cam.transform.forward);


		targetCam.transform.position = transform.position + (cam.transform.position - targetPortal.position);
		targetCam.transform.LookAt(targetCam.transform.position + q * transform.up, targetPortal.transform.forward);
		targetCam.nearClipPlane = (targetCam.transform.position - transform.position).magnitude - 0.3f;

	}
}
