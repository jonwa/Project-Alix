using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Portal))]
public class PortalCameraController : MonoBehaviour 
{
	private Camera m_MyCamera;
	private PortalPairHandler m_PairHandler;
	Material mat;
	RenderTexture rt;
	// Use this for initialization
	void Start () 
	{
		rt = new RenderTexture(512,512,24);
		MeshRenderer[] mr = gameObject.GetComponentsInChildren<MeshRenderer>();
		foreach(MeshRenderer m in mr)
		{
			if(m.transform.name == "Quad")
			{
				m.material = new Material(m.material);
				m.material.mainTexture = rt;
				mat = m.material;
                //... Test!
                Debug.Log(m.renderer.material.renderQueue);
                m.renderer.material.renderQueue = 100;
			}
		}

		m_PairHandler = transform.parent.GetComponent<PortalPairHandler>();
	}

	public Camera GetCamera()
	{
		if(m_MyCamera == null)
		{
			m_MyCamera = GetComponentInChildren<Camera>();
		}
		return m_MyCamera;
	}

	// Update is called once per frame
	void Update () 
	{
		//Transform playerTransform = Camera.main.transform.parent;
		//float angle = playerTransform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y;
		//m_TargetCamera.transform.eulerAngles = new Vector3(0, playerTransform.rotation.eulerAngles.y-180+angle, 0);

		Transform	targetPortal = GetComponent<Portal>().GetTargetPortal();
		Camera 		targetCam 	 = targetPortal.GetComponent<PortalCameraController>().GetCamera();
		Camera 		cam 		 = Camera.main;
		targetCam.targetTexture  = rt; //(rt.colorBuffer, rt.depthBuffer);


        Vector3 pos = targetPortal.transform.InverseTransformPoint(cam.transform.position);
        pos.x      -= pos.x;
        pos.z      -= pos.z;

        m_MyCamera.transform.localPosition = pos;
		//FRÅGA SEBASTIAN OM DENNA FORMELN!
		float scale = Mathf.Pow((Vector3.Distance(targetPortal.transform.position, cam.transform.position)), 1.5f);
//		Debug.Log("Scale: " + scale.ToString());
		m_MyCamera.fieldOfView = 60.0f-scale;
        Quaternion rot = Quaternion.Inverse(targetPortal.transform.rotation) * cam.transform.rotation;
        rot = Quaternion.AngleAxis(180.0f, Vector3.up) * rot;
		m_MyCamera.transform.localRotation = rot;






        //Weird controlls.. doesnt work.. V
        //Quaternion  q 			 = Quaternion.FromToRotation(targetPortal.up, cam.transform.forward);
        //targetCam.transform.position = transform.position + (cam.transform.position - targetPortal.position);
        //targetCam.transform.LookAt(targetCam.transform.position + q * transform.up, targetPortal.transform.forward);
        //targetCam.nearClipPlane = (targetCam.transform.position - transform.position).magnitude - 0.3f;

	}
}
