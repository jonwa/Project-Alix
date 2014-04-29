using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Locked))]
public class PortalTexture : MonoBehaviour 
{
	private Camera 		  m_Camera;
	private RenderTexture m_Texture;
	private bool 		  m_Active  = false;
	private bool 		  m_Allowed;

	public  GameObject[]  m_Children;
	public  string		  m_Input = "u";
	// Use this for initialization
	void Start () 
	{
		m_Texture = new RenderTexture(512,512,24);
		m_Camera = GetComponentInChildren<Camera>().camera;

		m_Allowed = GetComponent<Locked>().GetLocked();
		ChangePortal();
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_Camera.targetTexture = m_Texture;
		if(Input.GetKeyDown(m_Input))
		{
			m_Active = !m_Active;
			ChangePortal();
		}
	}

	public void ChangeHouse(int house)
	{
		m_Camera.GetComponent<CheckPlayer>().ChangeHouse(house);
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
