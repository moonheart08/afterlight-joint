// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets;

public abstract class Scrollable : ScrollContainer
{
    protected Scrollable()
    {
        ReturnMeasure = true;
    }

    protected override void ChildAdded(Control newChild)
    {
        base.ChildAdded(newChild);

        //FIXME: Doesn't work somehow.
        /*if (ChildCount > 1)
        {
            throw new Exception(
                "Scrollable controls cannot contain more than one child, as they are a modifier to another control.");
        }*/
    }
}

[Virtual]
public class VScrollable : Scrollable
{
    public VScrollable()
    {
        HScrollEnabled = false;
        VScrollEnabled = true;
        HorizontalExpand = true;
        VerticalExpand = true;
    }
}

[Virtual]
public class HScrollable : Scrollable
{
    public HScrollable()
    {
        HScrollEnabled = true;
        VScrollEnabled = false;
        HorizontalExpand = true;
        VerticalExpand = true;
    }
}
