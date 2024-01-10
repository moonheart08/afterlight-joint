using System.Numerics;
using Content.Client._AL.UI.Interfaces;
using Robust.Client.Graphics;

namespace Content.Client._AL.UI.Styleboxes;

public sealed class StyleboxExtruded : StyleBox, IBrightnessAware
{
    public StyleBox Base { get; }

    public StyleBox? Extrusion { get; }

    public Vector2 Offset { get; }

    protected override float GetDefaultContentMargin(Margin margin)
    {
        return Base.GetContentMargin(margin);
    }

    public StyleboxExtruded(StyleBox @base, Vector2 offset, StyleBox? extrusion = default)
    {
        Base = @base;
        Offset = offset;
        Padding = new Thickness(Base.PaddingLeft, Base.PaddingTop, Base.PaddingRight, Base.PaddingBottom);
        Extrusion = extrusion;
    }

    protected override void DoDraw(DrawingHandleScreen handle, UIBox2 box, float uiScale)
    {
        var oldXform = handle.GetTransform();
        var old = handle.Modulate;
        handle.Modulate = Color.LightGray;
        (Extrusion ?? Base).Draw(handle, box, uiScale);
        handle.Modulate = old;
        var offs = Matrix3.CreateTranslation((-Offset) * uiScale);
        var xform = oldXform;
        xform.Multiply(offs);
        handle.SetTransform(xform);

        Base.Draw(handle, box, uiScale);

        handle.SetTransform(oldXform);
    }

    public float Luminance()
    {
        return Base.Luminance();
    }
}
