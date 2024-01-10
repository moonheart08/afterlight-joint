using Content.Client._AL.UI.Interfaces;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Utility;

namespace Content.Client._AL.UI.Widgets;

public sealed class RichText : RichTextLabel
{
    private const float SwitchToDarkLevel = 0.65f;

    public RichText()
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

    public FormattedMessage? FormattedText { get; set; }


    public string Text
    {
        set => FormattedText = FormattedMessage.FromMarkup(value);
    }

    public Type[]? TagsAllowed = null;

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
            if (FormattedText is not null)
                SetMessage(FormattedText, tagsAllowed: TagsAllowed, defaultColor: color);
        }
    }


}
