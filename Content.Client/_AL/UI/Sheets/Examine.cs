using Content.AL.UIKit;
using Content.AL.UIKit.Sheets;
using Content.Client.Examine;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.AL.UIKit.ALStylesheetHelpers;

namespace Content.Client._AL.UI.Sheets;

[Stylesheet]
public sealed class Examine : BaseSubsheet
{
    public override StyleRule[] GetRules(BaseStyle origin)
    {
        return new StyleRule[]
        {
            E<ExamineButton>()
                .Margin(4),

            E<ExamineButton>().ParentOf<TextureRect>()
                .SetSize(new(32, 32)),

            Element().Class(ExamineSystem.StyleClassEntityTooltip)
                .Prop(PanelContainer.StylePropertyPanel,
                    origin.LoadTexture($"{origin.FileRoot}/tiny_panel_transparent.png").ToPatchStyleBox(8)),
        };
    }
}
