Shader "Custom/Lek" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white"  {}
		_MyColor ( "Any Color", color ) = (1.0, 0.0, 0.0, 0.0)
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
		float4 _MyColor;

		/////////
		struct vertexInput
		{
			float4 vertex : POSITION;
		};
		
		struct fragmentInput
		{
			float4 pos : POSITION;
			float4 color : COLOR0;
		};
		
		fragmentInput vert( vertexInput v )
		{
			fragmentInput o;
			
			//if(v.vertex.x < 15)
			//{
			//	v.vertex.y += _Time*20;
			//}
			
			o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
			o.color = _MyColor;
			o.color.x = clamp(v.vertex.x, 0.2, 0.5);
			
			return o;
		}
		
		half4 frag( fragmentInput l ) : COLOR
		{
			//float4 test = _MyColor;
			//test.x = sin(_Time * 20);
			//if(l.pos.x > 0)
			//{
			//	return float4(0.0, 0.0, 1.0, 0.0);
			//}
			//else
			//{
			//	return l.color;//test;//float4(1.0, 0.0, 0.0, 0.0);
			//}
			return l.color;
		}
		
		/////
		ENDCG
		}
	} 
	FallBack "Diffuse"
}
