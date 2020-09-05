Shader "THOR_Thunderstorm/THOR_LightningCloud"
{
    Properties 
    {
        [NoScaleOffset]_Alpha ("Alpha", 2D) = "white" {}
        _ColorCore ("Color Core", Color) = (0.07843138,0.3921569,0.7843137,1)
        _ColorGlow ("Color Glow", Color) = (0.5,0.5,0.5,1)
        _Evolution ("Evolution", Range(0, 1)) = 0
        _Multi ("Multi", Float ) = 1
        _Angle ("Angle", Float ) = 0
    }

    SubShader 
    {
        Tags
        {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }

        Pass 
        {
            Name "FORWARD"
            Tags { "LightMode"="Always" }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0

            uniform float4 _ColorCore;
            uniform sampler2D _Alpha;
            uniform float _Evolution;
            uniform float4 _ColorGlow;
            uniform float _Multi;
            uniform float _Angle;

            struct VertexInput 
            {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };

            struct VertexOutput 
            {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };

            VertexOutput vert (VertexInput v) 
            {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }

            float4 frag(VertexOutput i) : COLOR 
            {
                float  uv_cos = cos(_Angle);
                float  uv_sin = sin(_Angle);
                float2 uv_piv = float2(0.5,0.5);
                float2 uv = (mul(i.uv0 - uv_piv, float2x2(uv_cos, -uv_sin, uv_sin, uv_cos)) + uv_piv);
                float  _Alpha_var = tex2D(_Alpha, uv).a;
                float3 emissive = (( _ColorCore.rgb*_Alpha_var + _ColorGlow.rgb * (1.0 - _Alpha_var) ) * _Alpha_var * saturate(_Evolution*3.333333) *saturate(_Evolution*-2.5+2.5) ) * _Multi;
                return fixed4(emissive,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
