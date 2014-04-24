using UnityEngine;
using System.Collections;

public class PortalTexture : MonoBehaviour 
{
	private Camera 		  m_Camera;
	private RenderTexture m_Texture;
	// Use this for initialization
	void Start () 
	{
		m_Texture = new RenderTexture(512,512,24);
		m_Camera = GetComponentInChildren<Camera>().camera;
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_Camera.targetTexture = m_Texture;
	}

	public void ChangeHouse()
	{
		m_Camera.GetComponent<CheckPlayer>().ChangeHouse();
	}

	public RenderTexture GetTextureForPortal()
	{
		return m_Texture;
	}
}
