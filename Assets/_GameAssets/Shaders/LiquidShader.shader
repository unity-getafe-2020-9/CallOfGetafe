Shader "Getafe/LiquidShader"
{
    Properties
    {
        _LiquidAmount("Liquid Amount", Range(-3,2)) = 0
        _BaseColor("Base Color", Color) = (1,1,0,1)
        _TopColor("Top Color", Color) = (0,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque"}
        ZWrite On
        Cull Off
        AlphaToMask On//Determina el corte

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
                float liquidEdge : TEXCOORD1;
            };

            float _LiquidAmount;
            float4 _BaseColor;
            float4 _TopColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                //mul --> Multiplica una matriz por otra
                float3 worldPosition = mul(unity_ObjectToWorld, v.vertex.xyz);
                //La y determina la orientación. liquidEdge es el umbral del líquido
                o.liquidEdge = worldPosition.y + _LiquidAmount;
                return o;
            }

            //VFACE es positivo para caras frontales y negativo para posteriores
            fixed4 frag(v2f i, fixed facing : VFACE) : SV_Target
            {
                fixed4 renderBase = _BaseColor * -i.liquidEdge;
                fixed4 renderTop = _TopColor * -i.liquidEdge;
                //facing determina que se renderiza la cara exterior y la interior.
                return facing > 0 ? renderBase : renderTop;
            }
            ENDCG
        }
    }
}
