// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Content.Client._AL.UI.Interfaces;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets;

[Virtual]
public class HBar : PanelContainer, IDepthMeasure<BorderedPanel>
{
    protected override void StylePropertiesChanged()
    {
        base.StylePropertiesChanged();
        ((IDepthMeasure<BorderedPanel>)this).CheckChanges(this);
    }

    protected override void Parented(Control newParent)
    {
        base.Parented(newParent);
        ((IDepthMeasure<BorderedPanel>)this).CheckChanges(this);
    }

    protected override void EnteredTree()
    {
        base.EnteredTree();
        ((IDepthMeasure<BorderedPanel>)this).CheckChanges(this);
    }

    public HBar()
    {
        HorizontalAlignment = HAlignment.Stretch;
        HorizontalExpand = true;
        Margin = new Thickness(4);
        VerticalAlignment = VAlignment.Center;
        VerticalExpand = false;
        MinHeight = 3;
    }

    public void OnDepthUpdate(int n)
    {
        if (TryGetStyleProperty(Style.BarStyleboxes, out StyleBox[]? boxes))
        {
            if (boxes is null)
                return;

            PanelOverride = boxes[n % boxes.Length];
        }
        return;
    }
}

public sealed class VBar : HBar
{
    public VBar()
    {
        HorizontalAlignment = HAlignment.Center;
        HorizontalExpand = false;
        Margin = new Thickness(4);
        VerticalAlignment = VAlignment.Stretch;
        VerticalExpand = true;
        MinWidth = 3;
    }
}
