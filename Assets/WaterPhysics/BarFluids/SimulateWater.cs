using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;


public class SimulateWater : MonoBehaviour 
{
	const int WIDTH = 100;
	const int HEIGHT = 100;

	[StructLayout(LayoutKind.Sequential)]
	public struct bar
	{
		public float Position; //Height
		public float Velocity; 
		public float h;		//column width
	}

	public ComputeShader _Water;
	private ComputeBuffer _BarBuffer;

	void Start () 
	{

	}

	void InitiateBuffers()
	{
		bar[] values = new bar[WIDTH*HEIGHT];
		for(int i=0; i < WIDTH*HEIGHT; ++i)
		{
			values[i].Position = 5.0f;
			values[i].Velocity = 0.0f;
			values[i].h		   = 1.0f;
		}

//		Debug.Log(Marshal.SizeOf(bar));
		_BarBuffer = new ComputeBuffer(WIDTH*HEIGHT, sizeof(float)*3);
		_BarBuffer.SetData(values);
	}

	void Update () 
	{
		
	}
}
