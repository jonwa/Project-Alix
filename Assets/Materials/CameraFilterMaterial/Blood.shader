Shader "Custom/Blood" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white"  {}
		_NoiseTex ("Noise", 2D) = "White"{}
		_Lerp ("Lerp", Range (0,1)) = 0.5
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
		sampler2D _NoiseTex;
		float _Lerp;
		
		/////////
		struct vertexInput
		{
			float4 vertex : POSITION;
			float4 texCoord : TEXCOORD;
			float4 texCoord2 : TEXCOORD1;
		};
		
		struct fragmentInput
		{
			float4 pos : POSITION;
			half2 uv : TEXCOORD;
			half2 uv2 : TEXCOORD1;
		};
		
		//float rand(vec2 co)
		//{
		//	return fract(sin(dot(co.xy ,vec2(12.9898,78.233))) * 43758.5453);
		//};
		
		fragmentInput vert( vertexInput v )
		{
			fragmentInput o;
			
			o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
			o.uv = v.texCoord;
			o.uv2 = v.texCoord2;
			
			return o;
		}
		
		half4 frag( fragmentInput l ) : COLOR
		{
			float4 maincol = tex2D(_MainTex, l.uv);
			float4 texcol = tex2D(_NoiseTex, l.uv2);
			
			float4 Mix = lerp(tex2D(_NoiseTex, l.uv), tex2D(_MainTex, l.uv), texcol.x);
		
			//float4 NewText = tex2D(_MainTex, l.uv);
			return float4(Mix);
		}
		
		/////
		ENDCG
		}
	} 
	FallBack "Diffuse"
}

