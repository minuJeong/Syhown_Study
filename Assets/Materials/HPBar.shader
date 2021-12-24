Shader "Unlit/HPBar"
{
    Properties
    {
        _Value("Value", Range(0.0, 1.0)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float _Value;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                if (i.uv.x > _Value)
                {
                    discard;
                }

                fixed4 color = fixed4(1.0f, 0.0f, 0.0f, 1.0f);

                if (_Value < 0.3f)
                {
                    color.y = 1.0f;
                }
                return color;
            }
            ENDCG
        }
    }
}
