// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Numerics;
using Content.Client._AL.UI.Interfaces;
using Linguini.Syntax.Ast;
using Robust.Client.Graphics;

namespace Content.Client._AL.UI.Styleboxes;

public sealed class StyleBoxScaled: StyleBox, IBrightnessAware
{
    public StyleBox Base { get; }

    public float Scale { get; }


    protected override float GetDefaultContentMargin(StyleBox.Margin margin)
    {
        return Base.GetContentMargin(margin);
    }

    public StyleBoxScaled(StyleBox @base, float scale)
    {
        Base = @base;
        Scale = scale;
        Padding = new Thickness(Base.PaddingLeft, Base.PaddingTop, Base.PaddingRight, Base.PaddingBottom);
    }

    protected override void DoDraw(DrawingHandleScreen handle, UIBox2 box, float uiScale)
    {
        box = box.Scale(Scale);

        Base.Draw(handle, box, uiScale);
    }

    public float Luminance()
    {
        return Base.Luminance();
    }
}
