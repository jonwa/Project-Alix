Shader "Custom/UpdatedTv" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white"  {}
		_SecondTex ("Noise", 2D) = "White"{}
		_Clamp ("Clamp", Range (0,1)) = 0.4
		_Lerp ("Lerp", Range (0,1)) = 0.5
		
		_Speed ("Speed", Range (0,100)) = 10
		_Height ("Height", Range (0,0.2)) = 0.05
		_Disorient ("Disorient", Range (0,0.5)) = 0.05
		_Delay ("Delay", Range (-1,1)) = 0.5
		_BlackAndWhite ("BlackAndWhite", Range (0,1)) = 0.5
		
		_Random ("Random", Range (0,1)) = 0.5
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
		sampler2D _SecondTex;
		float4 _SecondTex_ST;
		float _Clamp;
		float _Lerp;
		float _Speed;
		float _Height;
		float _Disorient;
		float _Delay;
		float _BlackAndWhite;
		float _Random;

		/////////
		struct vertexInput
		{
			float4 vertex : POSITION;
			float4 texCoord : TEXCOORD0;
			float4 texCoord2 : TEXCOORD1;
		};
		
		struct fragmentInput
		{
			float4 pos : POSITION;
			half2 uv : TEXCOORD0;
			half2 uv2 : TEXCOORD1;
		};
		
		fragmentInput vert( vertexInput v )
		{
			fragmentInput o;
			
			o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
			o.uv = v.texCoord;
			o.uv2 = TRANSFORM_TEX(v.texCoord2, _SecondTex);
			
			//NewNoiseEffect
			o.uv2.x += _Random;
			o.uv2.y += _Random;
			
			//For random noiseeffect
			//o.uv2.x += tan(_Time.z * 2) + o.uv2.x;
			//o.uv2.y  -= tan(_Time.z * 2) + o.uv2.x;
			
			//For moving lines
			if(_SinTime.z > _Delay)
			{
				if(o.uv.y - _Height < tan(_Time.x * _Speed) && o.uv.y + _Height > tan(_Time.x * _Speed))
				{
					o.uv.x += _Disorient;
				}
			}
			
			return o;
		}
		
		half4 frag( fragmentInput l ) : COLOR
		{
			float4 maincol = tex2D(_MainTex, l.uv);
			float4 texcol = tex2D(_SecondTex, l.uv2);
			float4 test = float4(clamp(texcol.x, 0, _Clamp));
			
			float4 test2 = lerp(maincol, test, _Lerp);
			
			float4 test3 = float4(test2.x);
			
			float4 test4 = float4(lerp(test2, test3, _BlackAndWhite));
		
			return test4;//tex2D( _NoiseTex, l.uv);
		}
		
		/////
		ENDCG
		}
	} 
	FallBack "Diffuse"
}
