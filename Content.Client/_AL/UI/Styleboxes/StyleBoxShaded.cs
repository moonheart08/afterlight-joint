using Robust.Client.Graphics;

namespace Content.Client._AL.UI.Styleboxes;

public sealed class StyleBoxShaded : StyleBox
{
    public StyleBox Base { get; }
    public ShaderInstance Shader { get; }
    public StyleBoxShaded(StyleBox @base, ShaderInstance shader)
    {
        Base = @base;
        Shader = shader;
        Padding = new Thickness(Base.PaddingLeft, Base.PaddingTop, Base.PaddingRight, Base.PaddingBottom);
    }


    protected override void DoDraw(DrawingHandleScreen handle, UIBox2 box, float uiScale)
    {
        var cur = handle.GetShader();

    }
}
