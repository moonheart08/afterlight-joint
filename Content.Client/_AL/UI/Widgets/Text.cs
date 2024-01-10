using Content.Client._AL.UI.Interfaces;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets;

public sealed class Text : Label
{
    private const float SwitchToDarkLevel = 0.65f;

    public Text()
    {
        Margin = new Thickness(2);
    }

    protected override void Parented(Control newParent)
    {
        base.Parented(newParent);
        Update();
    }

    protected override void EnteredTree()
    {
        base.EnteredTree();
        Update();
    }

    protected override void StylePropertiesChanged()
    {
        base.StylePropertiesChanged();
        Update();
    }

    public void Update()
    {
        var luminosity = 0.0f;
        {
            var parent = (Control)this;
            while (parent is not null)
            {
                parent = parent.Parent;
                if (parent is IBrightnessAware b)
                {
                    luminosity = b.Luminance();
                    break;
                }
            }
        }
        if (luminosity >= SwitchToDarkLevel && TryGetStyleProperty(StyleSelectors.FontColorLightBg, out Color color))
        {
            FontColorOverride = color;
        }
        else
        {
            FontColorOverride = null;
        }
    }
}
