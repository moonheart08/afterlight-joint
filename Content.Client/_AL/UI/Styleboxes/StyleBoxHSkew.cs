// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Numerics;
using Content.Client._AL.UI.Interfaces;
using Robust.Client.Graphics;

namespace Content.Client._AL.UI.Styleboxes;

public sealed class StyleBoxHSkew : StyleBox, IBrightnessAware
{
    public StyleBox Base { get; }
    /// <summary>
    ///     A skew value in radians.
    /// </summary>
    public float Skew { get; }

    protected override float GetDefaultContentMargin(Margin margin)
    {
        return Base.GetContentMargin(margin);
    }

    public StyleBoxHSkew(StyleBox @base, float skew)
    {
        Base = @base;
        Skew = skew;
        Padding = new Thickness(Base.PaddingLeft, Base.PaddingTop, Base.PaddingRight, Base.PaddingBottom);
    }

    protected override void DoDraw(DrawingHandleScreen handle, UIBox2 box, float uiScale)
    {
        var skew = Matrix3.Identity;
        skew[0, 1] = float.Tan(Skew);


        var oldXform = handle.GetTransform();
        var xform = oldXform;
        skew.Multiply(xform);
        handle.SetTransform(skew);

        Base.Draw(handle, box, uiScale);

        handle.SetTransform(oldXform);
    }

    public float Luminance()
    {
        return Base.Luminance();
    }
}
