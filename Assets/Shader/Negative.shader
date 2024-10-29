Shader "Hidden/Sample/Negative"
{
    Properties
    {
        _Intensity("Intensity", Range(0, 1)) = 1
    }
    SubShader
       {
           Tags { "RenderType"="Opaque" "RenderPipeline" = "UniversalPipeline"}
           ZTest Off ZWrite Off Cull Off
           Pass
           {
               Name "Negative"
    
               HLSLPROGRAM
               #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
               #include "Packages/com.unity.render-pipelines.core/Runtime/Utilities/Blit.hlsl"

               float _Intensity;
    
               #pragma vertex Vert
               #pragma fragment Frag
    
               half4 Frag(Varyings input) : SV_Target0
               {
                   float2 uv = input.texcoord.xy;
                   half4 color = SAMPLE_TEXTURE2D_X(_BlitTexture, sampler_LinearClamp, uv);
                   half3 negativeColor = 1 - color.rgb;
                   half4 negative = half4(lerp(color, negativeColor, _Intensity), color.a);
                   return negative;
               }
               ENDHLSL
           }
       }
}
