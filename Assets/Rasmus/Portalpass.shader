Shader "Custom/PortalPass" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white"  {}
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
			o.uv = v.texCoord;
			
			//if(o.uv.x != 1.0f && o.uv.y != 1.0f && o.uv.z != 1.0f)
			//{
			//	o.uv = v.texCoord;
			//}
			
			return o;
		}
		
		half4 frag( fragmentInput l ) : COLOR
		{
			float4 NewText = tex2D(_MainTex, l.uv);
			return tex2D(_MainTex, l.uv);
		}
		
		/////
		ENDCG
		}
	} 
	FallBack "Diffuse"
}

