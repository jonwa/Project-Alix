Shader "Custom/TextureLek" 
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
			if(o.uv.x - 0.1 < sin(_Time.x * 100) && o.uv.x + 0.1 > sin(_Time.x * 100))
			{
				o.uv.y += 0.2;
			}
			
			//_SinTime : Time (t);
			
			return o;
		}
		
		half4 frag( fragmentInput l ) : COLOR
		{
			//if(l.uv.x > 0.5)
			//{
			//	return float4 (0.5);
			//}
			//else
			//{
				return tex2D( _MainTex, l.uv);	
			//}
		}
		
		/////
		ENDCG
		}
	} 
	FallBack "Diffuse"
}
