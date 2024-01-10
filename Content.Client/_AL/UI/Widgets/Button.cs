using System.Linq;
using Content.Client._AL.UI.Interfaces;
using Robust.Client.Graphics;
using Robust.Client.UserInterface.Controls;
using Serilog.Parsing;

namespace Content.Client._AL.UI.Widgets;

public sealed class Button : ContainerButton
{
    public Text TextWidget { get; }

    /// <summary>
    ///     The text displayed by the button.
    /// </summary>
    [ViewVariables]
    public string? Text { get => TextWidget.Text; set => TextWidget.Text = value; }


    protected override void StylePropertiesChanged()
    {
        base.StylePropertiesChanged();
        TextWidget.Update();

    }

    public Button()
    {
        HorizontalExpand = false;
        Margin = new Thickness(2);
        AddStyleClass(StyleClassButton);
        TextWidget = new Text
        {
            StyleClasses = { StyleClassButton },
            HorizontalAlignment = HAlignment.Center,
        };
        AddChild(TextWidget);
    }
}
