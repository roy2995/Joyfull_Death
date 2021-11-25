Shader "Unlit/curtain_2"
{
    Properties
    {
        _Cutoff("Cutoff", Range(0,1)) = .5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha

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
                float4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };

            float _Cutoff;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.color = v.color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float leftCurtain = i.uv.y;
                float rightCurtain = 1 - i.uv.y;
                float color = 0;

                if(i.uv.x < 0.5)
                {
                    color = leftCurtain;
                }
                else
                {
                    color = rightCurtain;
                }

                if(color < _Cutoff)
                {
                    return i.color;
                }
                else
                {
                    return float4(0,0,0,0);
                }
            }
            ENDCG
        }
    }
}
