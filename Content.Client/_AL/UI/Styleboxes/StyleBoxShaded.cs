// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

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
