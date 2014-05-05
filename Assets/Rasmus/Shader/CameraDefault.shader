Shader "Custom/CameraDefault" 
{
	Properties 
	{
		_MainTex ("RenderTexture", 2D) = "white"  {}
		_DefaultTex ("Noise", 2D) = "White"{}
		_EffectTex ("Third", 2D) = "White"{}
		
		_Clamp ("Clamp", Range (0,1)) = 0.4
		_Lerp ("Lerp", Range (0,1)) = 0.5
		_LerpEffect ("LerpEffect", Range (0,1)) = 0
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
		sampler2D _DefaultTex;
		sampler2D _EffectTex;
		float _Clamp;
		float _Lerp;
		float _Random;
		float _LerpEffect;

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
			o.uv2 = v.texCoord2;
			
			//NewNoiseEffect
			o.uv2.x += _Random;
			o.uv2.y += _Random;
			
			return o;
		}
		
		half4 frag( fragmentInput l ) : COLOR
		{
			float4 FincalColor;
			float4 RendTexCol = tex2D(_MainTex, l.uv);
			float4 SecondCol  = tex2D(_DefaultTex, l.uv2);
			float4 EffectCol  = tex2D(_EffectTex, l.uv);
			float4 Color1     = float4(clamp(SecondCol.x, 0, _Clamp));
			float4 Color2     = lerp(RendTexCol, Color1, _Lerp);
			FincalColor = Color2;
			if(_LerpEffect != 0)
			{
				float4 Color3     = lerp(EffectCol, Color2, EffectCol.x);
				float4 Color4     = lerp(Color2, Color3, _LerpEffect);
				FincalColor = Color4;
			}
			else
			{
				float4 Color4     = lerp(Color2, EffectCol, _LerpEffect);
				FincalColor = Color4;
			}
			
			
		
			return FincalColor;//tex2D( _NoiseTex, l.uv);
		}
		
		/////
		ENDCG
		}
	} 
	FallBack "Diffuse"
}
