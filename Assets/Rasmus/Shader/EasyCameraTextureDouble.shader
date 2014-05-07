Shader "Custom/EasyCameraTextureDouble" 
{
	Properties 
	{
		_MainTex ("Main", 2D) = "white"  {}
		_SecondTex ("Second", 2D) = "White" {}
		_ThirdTex ("Third", 2D) = "White" {}
		_Lerp ("Lerp", Range (0,1)) = 0.5
		_Lerp2 ("Lerp2", Range (0,1)) = 0.5
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
		sampler2D _ThirdTex;
		float _Lerp;
		float _Lerp2;
		
		/////////
		struct vertexInput
		{
			float4 vertex : POSITION;
			float4 texCoord : TEXCOORD;
			float4 texCoord2 : TEXCOORD1;
			//float4 texCoord3 : TEXCOORD0;
		};
		
		struct fragmentInput
		{
			float4 pos : POSITION;
			half2 uv : TEXCOORD;
			half2 uv2 : TEXCOORD1;
			//half2 uv3 : TEXCOORD0;
		};
		
		fragmentInput vert( vertexInput v )
		{
			fragmentInput o;
			
			o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
			o.uv = v.texCoord;
			o.uv2 = v.texCoord2;
			//o.uv3 = v.texCoord3;
			
			return o;
		}
		
		half4 frag( fragmentInput l ) : COLOR
		{
			float4 maincol = tex2D(_MainTex, l.uv);
			float4 secondcol = tex2D(_SecondTex, l.uv2);
			float4 thirdcol = tex2D(_ThirdTex, l.uv2);
			
			float4 Mix = lerp(thirdcol, secondcol, _Lerp2);
			
			float4 Mix2 = lerp(maincol, Mix, _Lerp);
		
			return float4(Mix2);
		}
		
		/////
		ENDCG
		}
	} 
	FallBack "Diffuse"
}

