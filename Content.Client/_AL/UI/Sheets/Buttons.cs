// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
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
            Button().Normal().Prop(Style.StyleBox, origin.ButtonBackgrounds[2]),
            Button().Hover().Prop(Style.StyleBox, origin.ButtonBackgrounds[3]),
            Button().Pressed().Prop(Style.StyleBox, origin.ButtonBackgrounds[1]),
            Button().Disabled().Prop(Style.StyleBox, origin.ButtonBackgrounds[0]),

            Button().Positive().Normal().Prop(Style.StyleBox, origin.ButtonPositiveBackgrounds[2]),
            Button().Positive().Hover().Prop(Style.StyleBox, origin.ButtonPositiveBackgrounds[3]),
            Button().Positive().Pressed().Prop(Style.StyleBox, origin.ButtonPositiveBackgrounds[1]),
            Button().Positive().Disabled().Prop(Style.StyleBox, origin.ButtonPositiveBackgrounds[0]),

            Button().Negative().Normal().Prop(Style.StyleBox, origin.ButtonNegativeBackgrounds[2]),
            Button().Negative().Hover().Prop(Style.StyleBox, origin.ButtonNegativeBackgrounds[3]),
            Button().Negative().Pressed().Prop(Style.StyleBox, origin.ButtonNegativeBackgrounds[1]),
            Button().Negative().Disabled().Prop(Style.StyleBox, origin.ButtonNegativeBackgrounds[0]),
            E<Popup>().Class(OptionButton.StyleClassPopup).ParentOf(E<PanelContainer>())
                .Prop(PanelContainer.StylePropertyPanel, origin.PanelBackgrounds[0])
        };
    }
}
