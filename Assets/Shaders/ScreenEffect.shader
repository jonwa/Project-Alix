Shader "Custom/ScreenEffect" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Range1  ("Range 1", Range(0, 3)) = 2
		_Range2  ("Range 2", Range(0, 3)) = 4
		_Range3  ("Corner", Range(0, 5)) = 3
	}
	
	SubShader 
	{
		pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
		
		
			uniform sampler2D _MainTex;
			uniform float _Range1;
			uniform float _Range2;
			uniform float _Range3;
			
			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD;
			};
			
			float4 _MainTex_ST;
			v2f vert(appdata_full v)
			{				
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = float2(o.pos.x, o.pos.y) + float2(1.0) / float(2.0);//_texCoord;
				return o;

			}
			
			float4 frag(v2f i) : COLOR
			{
				float4 outCol = float4(i.uv + i.uv, i.uv + i.uv);
				
				float2 coords = i.uv;
				coords.x = pow(coords.x, _Range3) - pow(1.0 - coords.x, _Range3);
				coords.y = pow(coords.y, _Range3) - pow(1.0 - coords.y, _Range3);
				
				float dist = distance(coords, float2(0.0, 0.0));
				dist = 1.0 - smoothstep(_Range1, _Range2, dist);
				
				float2 ntex = i.uv;
				ntex.x += _Time*0.3;
				ntex.y += _Time*2.6;
				
				float4 outCols = tex2D(_MainTex, ntex) + float4(0.0, 0.0, 0.0, 0.0) * length(outCol.xyz); 
				outCols *= (5 * distance(i.uv, float2(0.5, 0.5)));
				//outCols += 900.0*sin(i.uv.y*900.0);
		
				return float4(float3(outCols.xyz), 0.0) * dist;
			}
			
			ENDCG	
		}
	} 
	FallBack "Diffuse"
}
