using UnityEngine;
using System.Collections;

public class WaterPhysicsSim : MonoBehaviour 
{
	const int NUM_TREADS = 8;

	int _kernelPos;

	public RenderTexture _texture;
	public ComputeShader _test;
	ComputeBuffer _buff;

	void Start () 
	{
		Debug.Log( SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.RGHalf));

		_texture = new RenderTexture(64,64,32);
		_texture.enableRandomWrite = true;
		_texture.wrapMode = TextureWrapMode.Clamp;
		_texture.Create();

		_kernelPos = _test.FindKernel("CSMain");
		_test.SetTexture(_kernelPos, "Result", _texture);
		Debug.Log(_kernelPos);
		_test.Dispatch(_kernelPos, 8,8,8);
		renderer.material.SetTexture("_MainTex", _texture);

	}

	void Update () 
	{
		
	}
}
