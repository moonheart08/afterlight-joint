// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Runtime.InteropServices;

namespace Content.Client._AL.UI.Widgets;

[Virtual]
public class ItemSelector : Button
{
    public ItemSelector()
    {
        // TODO: Compute needed width from selectable items.
        HorizontalExpand = true;
    }


}
