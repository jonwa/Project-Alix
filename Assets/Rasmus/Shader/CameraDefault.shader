Shader "Custom/CameraDefault" 
{
	Properties 
	{
		_MainTex    ("RenderTexture", 2D) = "white"  {}
		_DefaultTex ("Noise", 2D) = "White"{}
		_EffectTex  ("Third", 2D) = "White"{}
		
		_Clamp  ("Default Clamp", Range (0,1)) = 0.4
		_Lerp   ("Defualt Lerp", Range (0,1)) = 0.5
		_Random ("Random", Range (0,1)) = 0.5
		
		_LerpEffect 		 ("LerpEffect", Range (0,1)) = 0
		_Alpha 				 ("RemoveWhite", Range (0,1)) = 0
		_BlackAndWhite 		 ("BlackAndWhite", Range (0,1)) = 0
		_BlackAndWhiteEffect ("BlackAndWhiteEffect", Range (0,1)) = 0
	}
	SubShader 
	{
		Tags { "RenderType"="Transparent" }
		
		Pass
		{
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
		int   _Alpha;
		int   _BlackAndWhite;
		int   _BlackAndWhiteEffect;

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
			//Setup for defaultShader
			float4 FinalColor;
			float4 RendTexCol = tex2D(_MainTex, l.uv);
			float4 SecondCol  = tex2D(_DefaultTex, l.uv2);
			float4 EffectCol  = tex2D(_EffectTex, l.uv);
			float4 ColorDef   = float4(clamp(SecondCol.x, 0, _Clamp));
			float4 ColorMix1  = lerp(RendTexCol, ColorDef, _Lerp);
			FinalColor = ColorMix1;
			
			//Setup for Effects
			if(_BlackAndWhite != 0)
			{
				if(_BlackAndWhiteEffect != 0)
				{
					float4 ColorAlpha = EffectCol;
					if(_Alpha != 0)
					{
						ColorAlpha     = lerp(EffectCol, FinalColor, EffectCol.x);
					}
					float4 ColorBWLerp  = lerp(FinalColor, ColorAlpha, _LerpEffect);
					float4 ColorBWFinal = (ColorBWLerp.x);
					FinalColor 			= ColorBWFinal;
				}
				else
				{
					float4 ColorBW    = (FinalColor.x);
					float4 ColorAlpha = EffectCol;
					if(_Alpha != 0)
					{
						ColorAlpha     = lerp(EffectCol, ColorBW, EffectCol.x);
					}
					float4 ColorBWEffect = lerp(ColorBW, ColorAlpha, _LerpEffect);
					FinalColor 			 = ColorBWEffect;
				}
			}
			else if(_Alpha != 0)
			{
				//Removing the white
				float4 ColorAlpha     = lerp(EffectCol, FinalColor, EffectCol.x);
				float4 ColorAlphaLerp = lerp(FinalColor, ColorAlpha, _LerpEffect);
				FinalColor = ColorAlphaLerp;
			}
			else 
			{
				//only blend in the effect
				float4 ColorNormal = lerp(FinalColor, EffectCol, _LerpEffect);
				FinalColor = ColorNormal;
			}
			
			return FinalColor;
		}
		
		/////
		ENDCG
		}
	} 
	FallBack "Diffuse"
}
