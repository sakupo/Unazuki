Shader "Custom/MenuItemShader"
{
    Properties {
        _Color ("Color", Color) = (1,1,1,0)
    }
    SubShader {
        Tags { "RenderType"="Opaque" }

        Stencil {
            Ref 1
            Comp NotEqual
            Pass keep
        }

        CGPROGRAM
        #pragma surface surf Lambert

        fixed4 _Color;

        struct Input {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o) {
            o.Albedo = _Color.rgb;
            o.Alpha = _Color.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
