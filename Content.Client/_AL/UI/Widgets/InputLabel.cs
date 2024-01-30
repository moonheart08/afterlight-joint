// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Content.Client._AL.UI.Sheets;
using Content.Client.Stylesheets;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.Client._AL.UI.ALStylesheetHelpers;

namespace Content.Client._AL.UI.Widgets;

[Virtual]
public class InputLabel : Text
{
}

[Stylesheet]
public sealed class InputLabelStyle : BaseSubsheet
{
    public override StyleRule[] GetRules(BaseStyle origin)
    {
        return new StyleRule[]
        {
            Element<InputLabel>().Prop(Style.Font,
                origin.Font.GetFont(origin.BaseFontSize, FontStack.FontKind.Bold))
        };
    }
}
