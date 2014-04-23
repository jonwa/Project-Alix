using UnityEngine;
using System.Collections;

/* Description: PortalRenderer handles rendering from camera from this portals renderTexture
 * 
 * 
 * 
 */

[RequireComponent(typeof(Portal))]
[RequireComponent(typeof(Camera))]
public class PortalRenderer : MonoBehaviour {

	#region PrivateMemberVariables
	private Camera		  m_Camera;
	private RenderTexture m_RenderTarget;
	private Material	  m_Material;
	#endregion

	void Start()
	{
        Debug.Log(renderer.material.renderQueue);

		m_Camera 			   = GetComponent<Camera>();
		m_RenderTarget		   = new RenderTexture(256,256,24);
		m_Camera.targetTexture = m_RenderTarget;
	}

	public Material RenderTargetMaterial
	{
		get { return m_Material; }
		set { m_Material = value;}
	}
	
}
