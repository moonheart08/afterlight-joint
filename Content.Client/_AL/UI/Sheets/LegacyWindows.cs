// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Content.AL.UIKit;
using Content.AL.UIKit.Sheets;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.AL.UIKit.ALStylesheetHelpers;

namespace Content.Client._AL.UI.Sheets;

[Stylesheet]
public sealed class LegacyWindows : BaseSubsheet
{
    public override StyleRule[] GetRules(BaseStyle origin)
    {
        return new StyleRule[]
        {
            Element<Label>().Class(DefaultWindow.StyleClassWindowTitle)
                .Prop(ALStyleConsts.Font, origin.Font.GetFont(14, FontStack.FontKind.Bold)),
            Element().Class(DefaultWindow.StyleClassWindowPanel)
                .Prop(PanelContainer.StylePropertyPanel, origin.PanelBackgrounds[0]),
            Element().Class(ALStyleConsts.BorderedWindowPanel)
                .Prop(PanelContainer.StylePropertyPanel, origin.PanelBackgrounds[0]),
        };
    }
}
