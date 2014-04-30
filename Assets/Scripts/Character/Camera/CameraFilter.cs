using UnityEngine;
using System.Collections;

/*Description: Script for adding an effect to the camera for fixed time

Made by: Rasmus 30/04
 */

public class CameraFilter : MonoBehaviour 
{
	#region PublicMemberVariables
	public Material[] m_Materials;
	public float[]    m_Duration;
	public int        m_WhatEffect;
	#endregion

	#region PrivateMemberVariables
	private bool  m_EffectActive = false;
	private float m_Timer   	 = 0;
	#endregion

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("o"))
		{
			UseEffect(m_WhatEffect);
		}
		if(m_EffectActive == true)
		{
			m_Timer -= Time.deltaTime;
			if(m_Timer <= 0)
			{
				m_EffectActive = false;
			}
		}
	}

	public void UseEffect(int effect)
	{
		m_WhatEffect   = effect;
		m_EffectActive = true;
		m_Timer		   = m_Duration[m_WhatEffect];
	}

	//For future use with triggers
	public void UseSelectedEffect()
	{
		UseEffect(m_WhatEffect);
	}

	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		if(m_EffectActive == true)
		{
			Graphics.Blit (source, destination, m_Materials[m_WhatEffect]);
		}
		else
		{
			Graphics.Blit (source, destination);
		}
	}
}
