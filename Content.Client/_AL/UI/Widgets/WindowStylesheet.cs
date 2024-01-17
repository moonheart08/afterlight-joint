using System.Numerics;
using Content.Client._AL.UI.Sheets;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.Client._AL.UI.ALStylesheetHelpers;

namespace Content.Client._AL.UI.Widgets;

[Stylesheet]
public sealed class WindowStylesheet : BaseSubsheet
{
    public override StyleRule[] GetRules(BaseStyle origin)
    {
        var theme = origin.UserInterface.CurrentTheme;
        var (WindowTextures, _, _) =
            origin.LoadIndefiniteNinePatchSet($"{origin.FileRoot}/window_cross_{{0}}.png", 0);
        return new StyleRule[]
        {
            Element().Class(Style.WindowBackground).Prop(PanelContainer.StylePropertyPanel, origin.PanelBackgrounds[0]),
            Element().Class(Style.WindowContentsBackground).Prop(PanelContainer.StylePropertyPanel, origin.PanelBackgrounds[0]),
            E<TextureButton>().Class(DefaultWindow.StyleClassWindowCloseButton).ParentOf(E<TextureRect>())
                .Prop(TextureRect.StylePropertyTexture, WindowTextures[2])
                .Prop(TextureRect.StylePropertyTextureSizeTarget, new Vector2(32, 32)),

            E<TextureButton>().Hover().Class(DefaultWindow.StyleClassWindowCloseButton).ParentOf(E<TextureRect>())
                .Prop(TextureButton.StylePropertyTexture, WindowTextures[3]),
            E<TextureButton>().Pressed().Class(DefaultWindow.StyleClassWindowCloseButton).ParentOf(E<TextureRect>())
                .Prop(TextureButton.StylePropertyTexture, WindowTextures[1]),
        };
    }
}
