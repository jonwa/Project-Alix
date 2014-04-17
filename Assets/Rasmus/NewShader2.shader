Shader "Custom/TextureLek" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white"  {}
		_Speed ("Speed", Range (0,100)) = 10
		_Height ("Height", Range (0,0.2)) = 0.05
		_Disorient ("Disorient", Range (0,0.5)) = 0.05
		_Delay ("Delay", Range (-1,1)) = 0.5
	}
	SubShader 
	{
		Tags { "RenderType"="Transparent" }
		
		Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		
		#include "UnityCG.cginc"

		sampler2D _MainTex;
		float _Speed;
		float _Height;
		float _Disorient;
		float _Delay;
		
		////////////
		struct vertexInput
		{
			float4 vertex : POSITION;
			float4 texCoord : TEXCOORD;
		};
		
		struct fragmentInput
		{
			float4 pos : POSITION;
			half2 uv : TEXCOORD;
		};
		
		fragmentInput vert( vertexInput v )
		{
			fragmentInput o;
			
			o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
			o.uv = v.texCoord;
			//Here's where the magic happens
			if(_SinTime.z > _Delay)
			{
				if(o.uv.x - _Height < tan(_Time.x * _Speed) && o.uv.x + _Height > tan(_Time.x * _Speed))
				{
					o.uv.y += _Disorient;
				}
			}
			
			return o;
		}
		
		half4 frag( fragmentInput l ) : COLOR
		{
			return tex2D( _MainTex, l.uv);	
		}
		
		////////////
		ENDCG
		}
	} 
	FallBack "Diffuse"
}
