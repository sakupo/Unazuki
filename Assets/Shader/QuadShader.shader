Shader "Custom/QuadShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
    }

	CGINCLUDE
	#include "UnityCG.cginc"

	
	ENDCG

    SubShader
    {
		Pass
		{
		CGPROGRAM
		#pragma vertex vert_img
		#pragma fragment frag

		fixed4 _Color;

		float4 frag(v2f_img i) : SV_Target
		{
			return float4 (_Color);
		}

		ENDCG
		}
    }
}
