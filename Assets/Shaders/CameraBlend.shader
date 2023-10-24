// taken from: https://docs.unity3d.com/Packages/com.unity.postprocessing@2.1/manual/Writing-Custom-Effects.html
Shader "Hidden/Custom/CameraBlend"
{
    HLSLINCLUDE

        #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

        TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
        TEXTURE2D_SAMPLER2D(_BlendCamera1 , sampler_BlendCamera1);
        TEXTURE2D_SAMPLER2D(_BlendCamera2 , sampler_BlendCamera2);
        TEXTURE2D_SAMPLER2D(_BlendCamera3 , sampler_BlendCamera3);
        TEXTURE2D_SAMPLER2D(_BlendCamera4 , sampler_BlendCamera4);
        TEXTURE2D_SAMPLER2D(_BlendCamera5 , sampler_BlendCamera5);
        TEXTURE2D_SAMPLER2D(_BlendCamera6 , sampler_BlendCamera6);
        TEXTURE2D_SAMPLER2D(_BlendCamera7 , sampler_BlendCamera7);
        int _BlendMode1;
        int _BlendMode2;
        int _BlendMode3;
        int _BlendMode4;
        int _BlendMode5;
        int _BlendMode6;

        
        // algorithms taken from: https://www.deepskycolors.com/archivo/2010/04/21/formulas-for-Photoshop-blending-modes.html
        float3 blend(float4 cam1, float4 cam2, int blendMode) {
            float3 col = cam1.rgb;

            // darken
            if(blendMode == 0) {
                col = min(col, cam2.rgb);
            }
            // multiply 
            else if(blendMode == 1) {
                col *= cam2.rgb;
            }
            // color burn 
            else if(blendMode == 2) {
                col = float3(1,1,1) - (float3(1,1,1) - col) / cam2.rgb;
            }
            // linear burn 
            else if(blendMode == 3) {
                col += cam2.rgb - float3(1,1,1);
            }
            // lighten 
            else if(blendMode == 4) {
                col = max(col, cam2.rgb);
            }
            // screen 
            else if(blendMode == 5) {
                col = float3(1,1,1) - (float3(1,1,1) - col) * (float3(1,1,1) - cam2);
            }
            // color dodge 
            else if(blendMode == 6) {
                col /= float3(1,1,1) - cam2.rgb;
            }
            // linear dodge 
            else if(blendMode == 7) {
                col += cam2.rgb;
            }
            // overlay 
            else if(blendMode == 8) {
                // NOTE: TARGET = cam1; BLEND = cam2
                float luminance = dot(cam1.rgb, float3(0.2126729, 0.7151522, 0.0721750));
                col = (luminance > 0.5) * (float3(1,1,1) - (float3(1,1,1)-2*(cam1.rgb-0.5)) * (float3(1,1,1)-cam2.rgb)) +
                      (luminance <= 0.5) * ((2*cam1.rgb) * cam2.rgb);
            }
            // soft light 
            else if(blendMode == 9) {
                float luminance = dot(cam2.rgb, float3(0.2126729, 0.7151522, 0.0721750));
                col = (luminance > 0.5) * (float3(1,1,1) - (float3(1,1,1)-cam1.rgb) * (float3(1,1,1)-(cam2.rgb-0.5))) +
                      (luminance <= 0.5) * (cam1.rgb * (cam2.rgb+0.5));
            }
            // hard light 
            else if(blendMode == 10) {
                float luminance = dot(cam2.rgb, float3(0.2126729, 0.7151522, 0.0721750));
                col = (luminance > 0.5) * (float3(1,1,1) - (float3(1,1,1)-cam1.rgb) * (float3(1,1,1)-2*(cam2.rgb-0.5))) +
                      (luminance <= 0.5) * (cam1.rgb * (2*cam2.rgb));
            }
            // vivid light 
            else if(blendMode == 11) {
                float luminance = dot(cam2.rgb, float3(0.2126729, 0.7151522, 0.0721750));
                col = (luminance > 0.5) * (cam1.rgb / (float3(1,1,1)-2*(cam2.rgb-0.5))) +
                      (luminance <= 0.5) * (float3(1,1,1) - (float3(1,1,1)-cam1.rgb) / (2*cam2.rgb));
            }
            // linear light 
            else if(blendMode == 12) {
                float luminance = dot(cam2.rgb, float3(0.2126729, 0.7151522, 0.0721750));
                col = (luminance > 0.5) * (cam1.rgb + 2*(cam2.rgb-0.5)) +
                      (luminance <= 0.5) * (cam1.rgb + 2*cam2.rgb - 1);
            }
            // pinlight 
            else if(blendMode == 13) {
                float luminance = dot(cam2.rgb, float3(0.2126729, 0.7151522, 0.0721750));
                col = (luminance > 0.5) * (max(cam1.rgb,2*(cam2.rgb-0.5))) +
                      (luminance <= 0.5) * (min(cam1.rgb,2*cam2.rgb));
            }
            // difference 
            else if(blendMode == 14) {
                col = abs(cam1.rgb - cam2.rgb);
            }
            // exclusion 
            else if(blendMode == 15) {
                col = 0.5 - 2*(cam1.rgb-0.5)*(cam2.rgb-0.5);
            }

            return col;
        }

        float4 Frag(VaryingsDefault i) : SV_Target
        {
            // float4 cam1 = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
            // float4 cam2 = SAMPLE_TEXTURE2D(_BlendCamera, sampler_BlendCamera, i.texcoord);

            // read each camera's values
            float4 cam1 = SAMPLE_TEXTURE2D(_BlendCamera1, sampler_BlendCamera1, i.texcoord);
            float4 cam2 = SAMPLE_TEXTURE2D(_BlendCamera2, sampler_BlendCamera2, i.texcoord);
            float4 cam3 = SAMPLE_TEXTURE2D(_BlendCamera3, sampler_BlendCamera3, i.texcoord);
            float4 cam4 = SAMPLE_TEXTURE2D(_BlendCamera4, sampler_BlendCamera4, i.texcoord);
            float4 cam5 = SAMPLE_TEXTURE2D(_BlendCamera5, sampler_BlendCamera5, i.texcoord);
            float4 cam6 = SAMPLE_TEXTURE2D(_BlendCamera6, sampler_BlendCamera6, i.texcoord);
            float4 cam7 = SAMPLE_TEXTURE2D(_BlendCamera7, sampler_BlendCamera7, i.texcoord);

            // then blend each camera, one by one
            cam1.rgb = blend(cam1, cam2, _BlendMode1);
            cam1.rgb = blend(cam1, cam3, _BlendMode2);
            cam1.rgb = blend(cam1, cam4, _BlendMode3);
            cam1.rgb = blend(cam1, cam5, _BlendMode4);
            cam1.rgb = blend(cam1, cam6, _BlendMode5);
            cam1.rgb = blend(cam1, cam7, _BlendMode6);

            return cam1;
        }

    ENDHLSL

    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            HLSLPROGRAM

                #pragma vertex VertDefault
                #pragma fragment Frag

            ENDHLSL
        }
    }
}

// public enum BlendMode {
//     Darken = 0,
//     Multiply = 1,
//     ColorBurn = 2,
//     LinearBurn = 3,
//     Lighten = 4,
//     Screen = 5,
//     ColorDodge = 6,
//     LinearDodge = 7,
//     Overlay = 8,
//     SoftLight = 9,
//     HardLight = 10,
//     VividLight = 11,
//     LinearLight = 12,
//     PinLight = 13,
//     Difference = 14,
//     Exclusion = 15
// }