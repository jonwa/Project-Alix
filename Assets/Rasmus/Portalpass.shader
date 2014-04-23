Shader "Custom/PortalPass" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white"  {}
		_NoiseTex ("Noise", 2D) = "White"{}
		_Clamp ("Clamp", Range (0,1)) = 0.3
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
		float _Clamp;
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
			//o.uv2.x = fract(sin(dot(o.uv2 ,vec2(12.9898,78.233))) * 43758.5453);;
			
			
			o.uv2.x += tan(_Time.z * 30); + o.uv2.y;
			o.uv2.y += tan(_Time.z * 3) + o.uv2.x;
			
			return o;
		}
		
		half4 frag( fragmentInput l ) : COLOR
		{
			float4 maincol = tex2D(_MainTex, l.uv);
			float4 texcol = tex2D(_NoiseTex, l.uv2);
			float4 test = float4(clamp(texcol.x, 0, _Clamp));
			
			float4 test2 = lerp(maincol, test, _Lerp);
		
			//float4 NewText = tex2D(_MainTex, l.uv);
			return float4(test2);
		}
		
		/////
		ENDCG
		}
	} 
	FallBack "Diffuse"
}

