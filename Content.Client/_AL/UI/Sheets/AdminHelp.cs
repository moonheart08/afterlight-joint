using Content.AL.UIKit;
using Content.AL.UIKit.Sheets;
using Content.Client.Administration.UI.Bwoink;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.AL.UIKit.ALStylesheetHelpers;

namespace Content.Client._AL.UI.Sheets;

[Stylesheet]
public sealed class AdminHelp : BaseSubsheet
{
    public override StyleRule[] GetRules(BaseStyle origin)
    {
        return new StyleRule[]
        {
            E<BwoinkPanel>().ParentOf<HistoryLineEdit>()
                .Prop(HistoryLineEdit.StylePropertyStyleBox, origin.LoadTexture($"{origin.FileRoot}/tiny_panel_transparent.png").ToPatchStyleBox(8))
                .Margin(2),
            E<BwoinkPanel>().ParentOf<OutputPanel>()
                .Prop(OutputPanel.StylePropertyStyleBox, origin.LoadTexture($"{origin.FileRoot}/tiny_panel_transparent.png").ToPatchStyleBox(8))
                .Margin(2),
            E<BwoinkPanel>()
                .Margin(4),
        };
    }
}
