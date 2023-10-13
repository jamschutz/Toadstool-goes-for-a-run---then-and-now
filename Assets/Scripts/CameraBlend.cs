using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(CameraBlendRenderer), PostProcessEvent.AfterStack, "Custom/CameraBlend")]
public sealed class CameraBlend : PostProcessEffectSettings
{
    [Range(0, 15), Tooltip("Blend mode1")]
    public IntParameter blendMode1 = new IntParameter { value = 0 };
    [Range(0, 15), Tooltip("Blend mode2")]
    public IntParameter blendMode2 = new IntParameter { value = 0 };
    [Range(0, 15), Tooltip("Blend mode3")]
    public IntParameter blendMode3 = new IntParameter { value = 0 };
    [Range(0, 15), Tooltip("Blend mode4")]
    public IntParameter blendMode4 = new IntParameter { value = 0 };
    [Range(0, 15), Tooltip("Blend mode5")]
    public IntParameter blendMode5 = new IntParameter { value = 0 };
    [Range(0, 15), Tooltip("Blend mode6")]
    public IntParameter blendMode6 = new IntParameter { value = 0 };

    [Tooltip("Render texture for the camera")]
    public TextureParameter camera1 = new TextureParameter();

    [Tooltip("Render texture for the camera")]
    public TextureParameter camera2 = new TextureParameter();

    [Tooltip("Render texture for the camera")]
    public TextureParameter camera3 = new TextureParameter();

    [Tooltip("Render texture for the camera")]
    public TextureParameter camera4 = new TextureParameter();

    [Tooltip("Render texture for the camera")]
    public TextureParameter camera5 = new TextureParameter();

    [Tooltip("Render texture for the camera")]
    public TextureParameter camera6 = new TextureParameter();

    [Tooltip("Render texture for the camera")]
    public TextureParameter camera7 = new TextureParameter();
}

public sealed class CameraBlendRenderer : PostProcessEffectRenderer<CameraBlend>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/CameraBlend"));
        sheet.properties.SetInt("_BlendMode1", settings.blendMode1);
        sheet.properties.SetInt("_BlendMode2", settings.blendMode2);
        sheet.properties.SetInt("_BlendMode3", settings.blendMode3);
        sheet.properties.SetInt("_BlendMode4", settings.blendMode4);
        sheet.properties.SetInt("_BlendMode5", settings.blendMode5);
        sheet.properties.SetInt("_BlendMode6", settings.blendMode6);
        sheet.properties.SetTexture("_BlendCamera1", settings.camera1);
        sheet.properties.SetTexture("_BlendCamera2", settings.camera2);
        sheet.properties.SetTexture("_BlendCamera3", settings.camera3);
        sheet.properties.SetTexture("_BlendCamera4", settings.camera4);
        sheet.properties.SetTexture("_BlendCamera5", settings.camera5);
        sheet.properties.SetTexture("_BlendCamera6", settings.camera6);
        sheet.properties.SetTexture("_BlendCamera7", settings.camera7);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}

public enum BlendMode {
    Darken = 0,
    Multiply = 1,
    ColorBurn = 2,
    LinearBurn = 3,
    Lighten = 4,
    Screen = 5,
    ColorDodge = 6,
    LinearDodge = 7,
    Overlay = 8,
    SoftLight = 9,
    HardLight = 10,
    VividLight = 11,
    LinearLight = 12,
    PinLight = 13,
    Difference = 14,
    Exclusion = 15
}