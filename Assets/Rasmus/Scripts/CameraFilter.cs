using UnityEngine;
using System.Collections;

public class CameraFilter : MonoBehaviour 
{
	public Material mat;
	public Material mat2;
	private int   m_Effects = 0;
	private float m_Timer   = 0;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("o"))
		{
			UseEffect(1, 5);
		}
		if(m_Timer > 0)
		{
			m_Timer -= Time.deltaTime;
		}
		else if(m_Effects != 0)
		{
			m_Effects = 0;
		}
	}

	public void UseEffect(int effect, float time)
	{
		m_Effects = effect;
		m_Timer	  = time;
	}

	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		if(m_Effects == 1){
			Graphics.Blit (source, destination, mat);
		}
		else if(m_Effects == 2)
		{
			Graphics.Blit (source, destination, mat2);
		}
		else
		{
			Graphics.Blit (source, destination);
		}
	}
}
