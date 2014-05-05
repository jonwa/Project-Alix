using UnityEngine;
using System.Collections;

/*Description: Script for adding an effect to the camera for fixed time

Made by: Rasmus 30/04
 */

public class CameraFilter : MonoBehaviour 
{
	#region PublicMemberVariables
	public Material   m_DefaultMaterial;
	public Material[] m_Materials;
	public float[]    m_Duration;
	public int        m_WhatEffect;
	#endregion

	#region PrivateMemberVariables
	private bool    m_EffectActive = false;
	private float   m_Timer   	   = 0;
	private float   m_EffectLerp   = 0;
	private Texture m_Texture;
	#endregion

	// Use this for initialization
	void Start () 
	{
		m_DefaultMaterial.SetFloat("_LerpEffect", 0f);
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
				m_EffectActive = false;
				m_DefaultMaterial.SetFloat("_LerpEffect", 0.0f);
			}
			if(m_Timer > 1)
			{
				m_EffectLerp = 1;
			}
			else
			{
				m_EffectLerp = m_Timer;
			}
		}
	}

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

	public void SelectEffect(int effect)
	{
		m_WhatEffect = effect;
	}

	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		if(m_EffectActive == true)
		{
			m_Texture = m_Materials[m_WhatEffect].GetTexture("_SecondTex");
			m_DefaultMaterial.SetTexture("_EffectTex", m_Texture);
			m_DefaultMaterial.SetFloat("_LerpEffect", m_EffectLerp);
		}
		//if(m_EffectActive == true)
		//{
			//m_DefaultMaterial.
			//if(m_WhatEffect == 5)
			//{
			//	Material test = new Material(m_Materials[5]);
			//	test.SetTexture("_SecondTex", m_Materials[0].GetTexture("_NoiseTex"));
			//	test.SetTexture("_ThirdTex", m_Materials[1].GetTexture("_NoiseTex"));
			//	//test.Lerp(test, m_Materials[3], 0.5f);
			//	//test.Lerp(test, m_Materials[4], 0.5f);
			//
			//	Graphics.Blit (source, destination, test);
			//}
			//else
			//{
			//	Graphics.Blit (source, destination, m_Materials[m_WhatEffect]);
			//}
		//}
		//else
		//{
		//	Graphics.Blit (source, destination, m_DefaultMaterial);
		//}
		Graphics.Blit (source, destination, m_DefaultMaterial);
	}
}
