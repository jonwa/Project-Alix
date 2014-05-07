Shader "Custom/Blood" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white"  {}
		_SecondTex ("Noise", 2D) = "White"{}
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
		sampler2D _SecondTex;
		float4 _SecondTex_ST;
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
		
		fragmentInput vert( vertexInput v )
		{
			fragmentInput o;
			
			o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
			o.uv = v.texCoord;
			o.uv2 = TRANSFORM_TEX(v.texCoord2, _SecondTex);
			
			return o;
		}
		
		half4 frag( fragmentInput l ) : COLOR
		{
			float4 maincol = tex2D(_MainTex, l.uv);
			float4 texcol = tex2D(_SecondTex, l.uv2);
			
			if(_Lerp > 1)
			{
				_Lerp = 1;
			}
			
			float4 Mix = lerp(tex2D(_SecondTex, l.uv), tex2D(_MainTex, l.uv), texcol.x);
			float4 Mix2 = lerp(tex2D(_MainTex, l.uv), Mix, _Lerp);
		
			return float4(Mix2);
		}
		
		/////
		ENDCG
		}
	} 
	FallBack "Diffuse"
}

