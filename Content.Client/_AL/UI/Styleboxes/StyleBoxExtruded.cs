// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Numerics;
using Content.Client._AL.UI.Interfaces;
using Robust.Client.Graphics;

namespace Content.Client._AL.UI.Styleboxes;

public sealed class StyleboxExtruded : StyleBox, IBrightnessAware
{
    public StyleBox Base { get; }

    public StyleBox? Extrusion { get; }

    public Color Modulate { get; }

    public Vector2 Offset { get; }

    protected override float GetDefaultContentMargin(Margin margin)
    {
        return Base.GetContentMargin(margin);
    }

    public StyleboxExtruded(StyleBox @base, Vector2 offset, StyleBox? extrusion = default, Color? modulate = null)
    {
        modulate ??= Color.DarkGray;
        Modulate = modulate.Value;
        Base = @base;
        Offset = offset;
        Padding = new Thickness(
                Base.PaddingLeft,
                Base.PaddingTop,
                Base.PaddingRight,
                Base.PaddingBottom
            );
        Extrusion = extrusion;
    }

    protected override void DoDraw(DrawingHandleScreen handle, UIBox2 box, float uiScale)
    {
        var oldXform = handle.GetTransform();
        var old = handle.Modulate;
        handle.Modulate = Modulate;
        (Extrusion ?? Base).Draw(handle, box, uiScale);
        handle.Modulate = old;
        Base.Draw(handle, box.Translated(-Offset), uiScale);
    }

    public float Luminance()
    {
        return Base.Luminance();
    }
}
