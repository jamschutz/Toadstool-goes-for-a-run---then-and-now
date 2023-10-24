using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(VRamCorruptionRenderer), PostProcessEvent.AfterStack, "Custom/VRamCorruption")]
public sealed class VRamCorruption : PostProcessEffectSettings
{
    public FloatParameter shift = new FloatParameter { value = -0.5f };
    public TextureParameter texture = new TextureParameter();
}

public sealed class VRamCorruptionRenderer : PostProcessEffectRenderer<VRamCorruption>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Distortion"));
        sheet.properties.SetFloat("_ValueX", settings.shift);
        sheet.properties.SetTexture("_Texture", settings.texture);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}