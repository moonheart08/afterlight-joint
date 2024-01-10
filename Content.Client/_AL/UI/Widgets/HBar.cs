using Content.Client._AL.UI.Interfaces;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets;

[Virtual]
public class HBar : PanelContainer, IDepthMeasure<BackgroundPanel>
{
    protected override void StylePropertiesChanged()
    {
        base.StylePropertiesChanged();
        ((IDepthMeasure<BackgroundPanel>)this).CheckChanges(this);
    }

    protected override void Parented(Control newParent)
    {
        base.Parented(newParent);
        ((IDepthMeasure<BackgroundPanel>)this).CheckChanges(this);
    }

    protected override void EnteredTree()
    {
        base.EnteredTree();
        ((IDepthMeasure<BackgroundPanel>)this).CheckChanges(this);
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
        if (TryGetStyleProperty(StyleSelectors.BarStyleboxes, out StyleBox[]? boxes))
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
