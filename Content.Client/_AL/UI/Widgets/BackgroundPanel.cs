using System.Numerics;
using Content.Client._AL.UI.Interfaces;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets;

[Virtual]
public class BackgroundPanel : PanelContainer, IDepthMeasure<BackgroundPanel>, IBrightnessAware
{
    public BackgroundPanel()
    {
        Margin = new Thickness(2);
    }

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

    public virtual void OnDepthUpdate(int n)
    {
        if (TryGetStyleProperty(Style.BackgroundPanelStyleboxes, out StyleBox[]? boxes))
        {
            if (boxes is null)
                return;

            PanelOverride = boxes[n % boxes.Length];
        }
        return;
    }

    public float Luminance()
    {
        return PanelOverride.Luminance();
    }
}

public sealed class VBackgroundPanel : BackgroundPanel
{
    public readonly VStack Inner = new() {Margin = new Thickness(4)};

    public VBackgroundPanel()
    {
        Margin = new Thickness(2);
        AddChild(Inner);
        XamlChildren = Inner.Children;
    }
}

public sealed class HBackgroundPanel : BackgroundPanel
{
    public readonly HStack Inner = new() {Margin = new Thickness(4)};

    public HBackgroundPanel()
    {
        Margin = new Thickness(2);
        AddChild(Inner);
        XamlChildren = Inner.Children;
    }
}
