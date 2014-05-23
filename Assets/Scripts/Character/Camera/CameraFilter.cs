using UnityEngine;
using System.Collections;

/*Description: Script for adding an effect to the camera for fixed time

Made by: Rasmus 30/04
Modified: Rasmus 06/05
 */

public class CameraFilter : MonoBehaviour 
{
	#region PublicMemberVariables
	public Material     m_DefaultMaterial;
	public GameObject[] m_Materials;
	#endregion

	#region PrivateMemberVariables
	private int     m_WhatEffect;
	private bool    m_EffectActive = false;
	private float   m_Timer   	   = 0;
	private float   m_EffectLerp   = 0;
	private Texture m_Texture;

	private bool    m_FadeOut;
	private bool    m_RemoveWhite;
	private bool    m_BlackAndWhite;
	private bool    m_BlackAndWhiteEffect;
	private float   m_Duration;
	private float   m_Lerp;
	#endregion

	// Use this for initialization
	void Start () 
	{
		ResetDefualt();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("o"))
		{
			UseEffect(m_WhatEffect);
		}
		m_DefaultMaterial.SetFloat("_Random", Random.Range(0f, 1f));
		TestShaders();
		if(m_EffectActive == true)
		{
			m_Timer -= Time.deltaTime;
			if(m_Timer <= 0)
			{
				ResetDefualt();
			}
		}
	}

	public bool GetEffectActive()
	{
		return m_EffectActive;
	}
	public int GetWhatEffect()
	{
		return m_WhatEffect;
	}

	private void ResetDefualt()
	{
		m_EffectActive = false;
		m_DefaultMaterial.SetFloat("_LerpEffect", 0.0f);
		m_DefaultMaterial.SetInt("_Alpha", 0);
		m_DefaultMaterial.SetInt("_BlackAndWhite", 0);
		m_DefaultMaterial.SetInt("_BlackAndWhiteEffect", 0);
	}

	#region test
	private void TestShaders()
	{
		if(Input.GetKeyDown("1"))
		{
			UseEffect(0);
		}
		if(Input.GetKeyDown("2"))
		{
			UseEffect(1);
		}
		if(Input.GetKeyDown("3"))
		{
			UseEffect(2);
		}
		if(Input.GetKeyDown("4"))
		{
			UseEffect(3);
		}
		if(Input.GetKeyDown("5"))
		{
			UseEffect(4);
		}
		if(Input.GetKeyDown("6"))
		{
			UseEffect(5);
		}
		if(Input.GetKeyDown("7"))
		{
			UseEffect(6);
		}
		if(Input.GetKeyDown("8"))
		{
			UseEffect(7);
		}
		if(Input.GetKeyDown("9"))
		{
			UseEffect(8);
		}
		if(Input.GetKeyDown("0"))
		{
			UseEffect(9);
		}
	}
	#endregion

	public void UseEffect(int effect)
	{
		m_WhatEffect   			= effect;
		m_Texture 				= m_Materials[m_WhatEffect].renderer.material.mainTexture;
		m_EffectActive 			= true;

		m_FadeOut 				= m_Materials[m_WhatEffect].GetComponent<ShaderData>().m_FadeOut;
		m_RemoveWhite 			= m_Materials[m_WhatEffect].GetComponent<ShaderData>().m_RemoveWhite;
		m_BlackAndWhite			= m_Materials[m_WhatEffect].GetComponent<ShaderData>().m_BlackAndWhite;
		m_BlackAndWhiteEffect   = m_Materials[m_WhatEffect].GetComponent<ShaderData>().m_BlackAndWhiteEffect;
		m_Duration				= m_Materials[m_WhatEffect].GetComponent<ShaderData>().m_Duration;
		m_Lerp					= m_Materials[m_WhatEffect].GetComponent<ShaderData>().m_Lerp;

		m_Timer		   			= m_Duration;
	}

	//For future use with triggers
	public void UseSelectedEffect()
	{
		UseEffect(m_WhatEffect);
	}

	public void SelectEffect(int effect)
	{
		m_WhatEffect = effect;
	}

	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		if(m_EffectActive == true)
		{
			SetVariables();
		}
		Graphics.Blit (source, destination, m_DefaultMaterial);
	}

	private void SetVariables()
	{
		m_DefaultMaterial.SetTexture("_EffectTex", m_Texture);
		if(m_RemoveWhite == true)
		{
			m_DefaultMaterial.SetInt("_Alpha", 1);
		}
		if(m_BlackAndWhite == true)
		{
			m_DefaultMaterial.SetInt("_BlackAndWhite", 1);
		}
		if(m_BlackAndWhiteEffect == true)
		{
			m_DefaultMaterial.SetInt("_BlackAndWhiteEffect", 1);
		}
		GetLerp();
		m_DefaultMaterial.SetFloat("_LerpEffect", m_EffectLerp);
	}

	private void GetLerp()
	{
		if(m_FadeOut == true)
		{
			if(m_Timer > m_Lerp)
			{
				m_EffectLerp = m_Lerp;
			}
			else
			{
				m_EffectLerp = m_Timer;
			}
		}
		else
		{
			m_EffectLerp = m_Lerp;
		}
	}
}



















