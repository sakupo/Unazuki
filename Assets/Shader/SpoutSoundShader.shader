Shader "Custom/SpoutSoundShader"
{
	Properties
	{
		_Color1("Color1", Color) = (1,1,1,1)
		_Color2("Color2", Color) = (1,1,1,1)
		_Volume("volume", float) = 0.5

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

		fixed4 _Color1;
		fixed4 _Color2;
		float _Volume;

		float4 frag(v2f_img i) : SV_Target
		{
			if (i.uv.y < _Volume) {
				return float4 (_Color1);
			}else {
				return float4 (_Color2);
			}
			
		}

		ENDCG
		}
	}
}
