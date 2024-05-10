using Content.AL.UIKit;
using Content.AL.UIKit.Sheets;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.AL.UIKit.ALStylesheetHelpers;
using CTooltip = Robust.Client.UserInterface.CustomControls.Tooltip;

namespace Content.Client._AL.UI.Sheets;

[Stylesheet]
public sealed class Tooltip : BaseSubsheet
{
    public override StyleRule[] GetRules(BaseStyle origin)
    {
        return new StyleRule[]
        {
            E<CTooltip>()
                .Prop(CTooltip.StylePropertyPanel,
                    origin.LoadTexture($"{origin.FileRoot}/tiny_panel_transparent.png").ToPatchStyleBox(8)),
        };
    }
}
