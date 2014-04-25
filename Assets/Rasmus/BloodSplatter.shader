//Shader "Custom/BloodSplatter" 
//{ 
//	Properties 
//	{ 
//		_DoNotUseTex ("Base (RGB)", 2D) = "white" {} 
//		_MainTex ("Texture", 2D) = "White"{}
//		_Lerp ("Lerp", Range (0,1)) = 0.5
//		_Color ("Color", Color) = (1,0,0,1)
//
//	}
//	 
//	SubShader 
//	{ 
//		Tags 
//		{
//			"Queue" = "Transparent" 
//		//	"IgnoreProjector" = "True"
//			//"RenderType" = "Transparent"
//		} 
//	 //	Lighting Off Cull Off ZWrite Off Fog { Mode Off } 
//	  // 	Blend SrcAlpha OneMinusSrcAlpha
//	   	Pass
//	   	{ 
//	   		CGPROGRAM
//			#pragma vertex vert
//			#pragma fragment frag
//		
//			#include "UnityCG.cginc"
//			
//	   		sampler2D _DoNotUseTex;
//			sampler2D _MainTex;
// 			float _Lerp;
//	   		
//	   		SetTexture [_MainTex] 
//	   		{ 
//	      		combine primary, texture * primary 
//      		} 
//   		
//   				struct vertexInput
//				{
//					float4 vertex : POSITION;
//					float4 texCoord : TEXCOORD0;
//					float4 texCoord2 : TEXCOORD1;
//				};
//				
//				struct fragmentInput
//				{
//					float4 pos : POSITION;
//					half2 uv : TEXCOORD0;
//					half2 uv2 : TEXCOORD1;
//				};
//				
//				fragmentInput vert( vertexInput v )
//				{
//					fragmentInput o;
//					
//					o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
//					o.uv = v.texCoord;
//					o.uv2 = v.texCoord2;
//					return o;
//				}
//   				half4 frag( fragmentInput l ) : COLOR
//				{
//					float4 doNotUse = tex2D(_DoNotUseTex, l.uv);
//					float4 mainCol = tex2D(_MainTex, l.uv2);
//					
//					float4 finish = lerp(doNotUse, mainCol, _Lerp);
//				
//					return float4(finish);
//				}
//				ENDCG
//		}
//		
//	} 
//}
//*/