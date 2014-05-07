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
			
			o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
			o.color = _MyColor;
			o.color.x = clamp(v.vertex.x, 0.2, 0.5);
			
			return o;
		}
		
		half4 frag( fragmentInput l ) : COLOR
		{
			return l.color;
		}
		
		/////
		ENDCG
		}
	} 
	FallBack "Diffuse"
}
