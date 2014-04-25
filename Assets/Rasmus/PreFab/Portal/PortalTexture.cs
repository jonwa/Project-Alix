using UnityEngine;
using System.Collections;

public class PortalTexture : MonoBehaviour 
{
	private Camera 		  m_Camera;
	private RenderTexture m_Texture;
	private bool 		  m_Active = true;
	public GameObject[]   m_Children;
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
		if(Input.GetKeyDown("u"))
		{
			m_Active = !m_Active;
			ChangePortal();
		}
	}

	public void ChangeHouse()
	{
		m_Camera.GetComponent<CheckPlayer>().ChangeHouse();
	}

	public RenderTexture GetTextureForPortal()
	{
		return m_Texture;
	}

	private void ChangePortal()
	{
		if(m_Active)
		{
			for(int i=0; i<m_Children.Length; i++)
			{
				m_Children[i].SetActive(false);
			}
		}
		else
		{
			for(int i=0; i<m_Children.Length; i++)
			{
				m_Children[i].SetActive(true);
			}
		}
	}
}
