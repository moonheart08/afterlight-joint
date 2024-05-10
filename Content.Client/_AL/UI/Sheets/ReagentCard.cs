using Content.AL.UIKit;
using Content.AL.UIKit.Sheets;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.AL.UIKit.ALStylesheetHelpers;

namespace Content.Client._AL.UI.Sheets;

[Stylesheet]
public sealed class ReagentCard : BaseSubsheet
{
    public override StyleRule[] GetRules(BaseStyle origin)
    {
        return new StyleRule[]
        {
            E<BoxContainer>().Class("ReagentCardInnerButtonBox")
                .Margin(2),
            E<Label>().Class("ReagentCardReagentName")
                .Prop(Label.StylePropertyFont, origin.Font.GetFont(12, FontStack.FontKind.Bold))
        };
    }
}
