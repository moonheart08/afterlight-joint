using System.Numerics;
using Content.Client._AL.UI.Interfaces;
using Linguini.Syntax.Ast;
using Robust.Client.Graphics;

namespace Content.Client._AL.UI.Styleboxes;

public sealed class StyleBoxZoomed: StyleBox, IBrightnessAware
{
    public StyleBox Base { get; }

    public float Scale { get; }


    protected override float GetDefaultContentMargin(StyleBox.Margin margin)
    {
        return Base.GetContentMargin(margin);
    }

    public StyleBoxZoomed(StyleBox @base, float scale)
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
