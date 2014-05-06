using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Locked))]
public class PortalTexture : MonoBehaviour 
{
	private Camera 		  m_Camera;
	private RenderTexture m_Texture;
	private bool 		  m_Active  = false;
	private bool 		  m_Allowed;
	private int           m_LastInt;

	public  GameObject[]  m_Children;
	// Use this for initialization
	void Start () 
	{
		m_Texture = new RenderTexture(512,512,24);
		m_Camera = GetComponentInChildren<Camera>().camera;

		m_Allowed = GetComponent<Locked>().GetLocked();
		ChangePortal();
		m_LastInt = Camera.main.GetComponent<HouseCall>().GetTargetHouse();
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_Camera.targetTexture = m_Texture;
		if(m_LastInt != Camera.main.GetComponent<HouseCall>().GetTargetHouse())
		{
			m_LastInt = Camera.main.GetComponent<HouseCall>().GetTargetHouse();
			UpdatePortal();
		}
	}

	private void UpdatePortal()
	{
		if(GetComponent<Locked>().GetLocked() == false)
		{
			for(int i=0; i<m_Children.Length; i++)
			{
				m_Children[i].SetActive(true);
			}
		}
	}

	public RenderTexture GetTextureForPortal()
	{
		return m_Texture;
	}

	public void ChangePortal()
	{
		if(m_Active && !m_Allowed)
		{
			for(int i=0; i<m_Children.Length; i++)
			{
				m_Children[i].SetActive(true);
			}
		}
		else
		{
			for(int i=0; i<m_Children.Length; i++)
			{
				m_Children[i].SetActive(false);
			}
		}
	}
}
