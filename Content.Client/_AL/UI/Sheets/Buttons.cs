using Robust.Client.UserInterface;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.Client._AL.UI.ALStylesheetHelpers;

namespace Content.Client._AL.UI.Sheets;

[Stylesheet]
public sealed class Buttons : BaseSubsheet
{
    public override StyleRule[] GetRules(BaseStyle origin)
    {
        return new StyleRule[]
        {
            Button().Normal().Prop(StyleSelectors.StyleBox, origin.ButtonBackgrounds[2]),
            Button().Hover().Prop(StyleSelectors.StyleBox, origin.ButtonBackgrounds[3]),
            Button().Pressed().Prop(StyleSelectors.StyleBox, origin.ButtonBackgrounds[1]),
            Button().Disabled().Prop(StyleSelectors.StyleBox, origin.ButtonBackgrounds[0]),

            Button().Positive().Normal().Prop(StyleSelectors.StyleBox, origin.ButtonPositiveBackgrounds[2]),
            Button().Positive().Hover().Prop(StyleSelectors.StyleBox, origin.ButtonPositiveBackgrounds[3]),
            Button().Positive().Pressed().Prop(StyleSelectors.StyleBox, origin.ButtonPositiveBackgrounds[1]),
            Button().Positive().Disabled().Prop(StyleSelectors.StyleBox, origin.ButtonPositiveBackgrounds[0]),

            Button().Negative().Normal().Prop(StyleSelectors.StyleBox, origin.ButtonNegativeBackgrounds[2]),
            Button().Negative().Hover().Prop(StyleSelectors.StyleBox, origin.ButtonNegativeBackgrounds[3]),
            Button().Negative().Pressed().Prop(StyleSelectors.StyleBox, origin.ButtonNegativeBackgrounds[1]),
            Button().Negative().Disabled().Prop(StyleSelectors.StyleBox, origin.ButtonNegativeBackgrounds[0]),
        };
    }
}
