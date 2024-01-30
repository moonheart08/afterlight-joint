// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets;

[Virtual]
public class Grid : GridContainer
{
    public Grid()
    {
        Margin = new(4);
    }
}

[Virtual]
public class GrowGrid : Grid
{
    public GrowGrid()
    {
        HorizontalExpand = true;
        VerticalExpand = true;
    }
}
