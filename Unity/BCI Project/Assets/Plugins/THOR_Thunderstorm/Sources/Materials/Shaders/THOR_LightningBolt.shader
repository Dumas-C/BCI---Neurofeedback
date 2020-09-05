Shader "THOR_Thunderstorm/THOR_LightningBolt" 
{
    Properties 
    {
        [NoScaleOffset]_Alpha ("Alpha", 2D) = "white" {}
        _ColorCore ("Color Core", Color) = (1,0.8413793,0.5,1)
        _ColorGlow ("Color Glow", Color) = (0.0172,0.086,0.172,1)
        _Evolution ("Evolution", Range(0, 1)) = 0
        _Multi ("Multi", Float ) = 0
        _EnableDepthBlend ("EnableDepthBlend", Float) = 0
        _DepthBlend ("DepthBlend", Float ) = 1
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

            uniform sampler2D _CameraDepthTexture;
            uniform float4 _ColorGlow;
            uniform sampler2D _Alpha;
            uniform float _Evolution;
            uniform float4 _ColorCore;
            uniform float _Multi;
            uniform Float _EnableDepthBlend;
            uniform float _DepthBlend;

            struct VertexInput
            {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };

            struct VertexOutput
            {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 projPos : TEXCOORD1;
            };

            VertexOutput vert (VertexInput v)
            {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }

            float4 frag(VertexOutput i) : COLOR
            {
                float depthBlendPow = 1;
                if (_EnableDepthBlend >= 0.5)
                {
                    float sceneZ = max(0,LinearEyeDepth(UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                    float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                    float depthBlend = saturate((sceneZ - partZ) / _DepthBlend);
					depthBlendPow = depthBlend*depthBlend;// *depthBlend;
                }
                float4 _Alpha_var = tex2D(_Alpha,i.uv0);
                float  Alpha = _Alpha_var.a * _Alpha_var.a;
                float  alphaPow = Alpha*Alpha;
                float3 ColorMix = (_ColorCore.rgb*alphaPow) + ((1.0 - alphaPow) * _ColorGlow.rgb);
                float  evolSat = saturate(_Evolution*-1.633333+1.653333);
                float  evolSatPow = evolSat*evolSat*evolSat;
                float  oneMinusEvol2 = 1.0 - saturate(_Evolution*4.0+0.0);
                float  remapEvol = saturate( 1.0 + ( (i.uv0.g - oneMinusEvol2) * -1.0 ) / ((oneMinusEvol2 - 0.1) - oneMinusEvol2) );
                float  UVAnimation = (remapEvol*remapEvol);
                float3 emissive = (ColorMix * clamp(_Evolution*7.5 + 3.0, 3.0, 10.0) * evolSatPow * (Alpha*UVAnimation) * (_Multi*depthBlendPow)) *depthBlendPow;
                return fixed4(emissive,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
