using System.Linq;
using Content.Client._AL.UI.Interfaces;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Serilog.Parsing;

namespace Content.Client._AL.UI.Widgets;

public class Button : ContainerButton
{
    [Dependency] private ILocalizationManager _localization = default!;

    public Text TextWidget { get; }

    /// <summary>
    ///     The text displayed by the button.
    /// </summary>
    [ViewVariables]
    public string? Text { get => TextWidget.Text; set => TextWidget.Text = value; }

    public string? GroupName { get; set; }


    protected override void StylePropertiesChanged()
    {
        base.StylePropertiesChanged();
        TextWidget.Update();
        UpdateGroupAssignment();
    }

    protected override void Parented(Control newParent)
    {
        base.Parented(newParent);
        UpdateGroupAssignment();
    }

    protected override void EnteredTree()
    {
        base.EnteredTree();
        UpdateGroupAssignment();
        if (this.TryGetLocString(_localization) is { } s)
            Text = s;
        if (string.IsNullOrEmpty(Text) && Name is not null)
            Text = Name;
    }

    protected void UpdateGroupAssignment()
    {
        if (GroupName is { } gn && this.GetImplementingParent<IGroupOrganizer>() is {} org)
        {
            Group = org.GetButtonGroup(gn);
        }
    }

    public Button()
    {
        IoCManager.InjectDependencies(this);
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
