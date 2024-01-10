using System.Numerics;
using Content.Client._AL.UI.Interfaces;
using Content.Client._AL.UI.Styleboxes;
using Robust.Client.Graphics;

namespace Content.Client._AL.UI;

public static class StyleBoxExtensions
{
    public static float Luminance(this StyleBox? box)
    {
        switch (box)
        {
            case StyleBoxFlat flat:
                return Color.ToHsl(flat.BackgroundColor).Z;
            case StyleBoxTexture tex:
            {
                var texture = tex.Texture!;
                var pix = texture.GetPixel(texture.Width / 2, texture.Height / 2);
                return Color.ToHsl(pix).Z;
            }
            case IBrightnessAware b:
                return b.Luminance();
            case null:
                return 0.0f;
            default:
                throw new NotImplementedException($"Not yet implemented for a stylebox of type {box.GetType()}");
        }
    }

    public static StyleboxExtruded Extrude(this StyleBox box, Vector2 by, StyleBox? extrusion = default)
    {
        var b = new StyleboxExtruded(box, by, extrusion);

        return b;
    }

}
