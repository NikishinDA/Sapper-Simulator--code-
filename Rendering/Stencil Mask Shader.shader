Shader "StencilMask"
{
    Properties
    {
		_StencilReference ("Reference", Range(0,255)) = 0
    }
    SubShader
    {
        Tags { 
                "Queue" = "Geometry-1"
                "RenderPipeline" = "UniversalPipeline"}
        LOD 100
            Blend Zero One
            ZWrite Off
        Pass
        {
            Stencil
			{
				Ref [_StencilReference]
				Comp Always
				Pass Replace
			}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return 0;
            }
            ENDCG
        }
    }
}
