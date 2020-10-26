Shader "Unlit/RotationShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                float angulo = cos(_Time * 0.05) * 360;
                float4x4 rotationMatrix = float4x4(
                    1, 0, 0, 0, 
                    0, cos(angulo), -sin(angulo), 0,
                    0, sin(angulo), cos(angulo), 0,
                    0, 0, 0, 1);
                float4 rotacion = mul(rotationMatrix, v.vertex);
                v2f o;
                o.vertex = UnityObjectToClipPos(rotacion);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                return col;
            }
            ENDCG
        }
    }
}
