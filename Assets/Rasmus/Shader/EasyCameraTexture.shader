Shader "Custom/EasyCameraTexture" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white"  {}
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
		float4 _MainTex_ST;
		
		/////////
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
			o.uv = TRANSFORM_TEX(v.texCoord, _MainTex);
			
			return o;
		}
		
		half4 frag( fragmentInput l ) : COLOR
		{
		
			return tex2D(_MainTex, l.uv);
		}
		
		/////
		ENDCG
		}
	} 
	FallBack "Diffuse"
}

