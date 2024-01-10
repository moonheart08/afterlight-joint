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
            origin.LoadIndefiniteNinePatchSet($"{origin.FileRoot}/window_cross_lowres_{{0}}.png", 0);
        return new StyleRule[]
        {
            Element().Class(StyleSelectors.WindowBackground).Prop(PanelContainer.StylePropertyPanel, origin.PanelBackgrounds[0]),
            Element().Class(StyleSelectors.WindowContentsBackground).Prop(PanelContainer.StylePropertyPanel, origin.PanelBackgrounds[0]),
            Element().Class(DefaultWindow.StyleClassWindowCloseButton)
                .Prop(TextureButton.StylePropertyTexture, WindowTextures[2]),
            Element().Class(DefaultWindow.StyleClassWindowCloseButton).Hover()
                .Prop(TextureButton.StylePropertyTexture, WindowTextures[3]),
            Element().Class(DefaultWindow.StyleClassWindowCloseButton).Pressed()
                .Prop(TextureButton.StylePropertyTexture, WindowTextures[1]),
        };
    }
}
