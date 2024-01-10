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
        var left = by.X < 0 ? float.Abs(by.X) : 0.0f;
        var right = by.X > 0 ? float.Abs(by.X) : 0.0f;
        var top = by.Y > 0 ? float.Abs(by.Y) : 0.0f;
        var bottom = by.Y < 0 ? float.Abs(by.Y) : 0.0f;
        if (left != 0.0f)
            b.SetContentMarginOverride(StyleBox.Margin.Left, left);
        if (right != 0.0f)
            b.SetContentMarginOverride(StyleBox.Margin.Right, right);
        if (top != 0.0f)
            b.SetContentMarginOverride(StyleBox.Margin.Top, top);
        if (bottom != 0.0f)
            b.SetContentMarginOverride(StyleBox.Margin.Bottom, bottom);
        return b;
    }

}
