using System.Linq;
using Content.Client._AL.UI.Interfaces;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Serilog.Parsing;

namespace Content.Client._AL.UI.Widgets;

public class Button : ContainerButton
{
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
    }

    protected void UpdateGroupAssignment()
    {
        if (GroupName is { } gn && this.GetImplementingParent<IGroupOrganizer>() is {} org)
        {
            var group = org.GetButtonGroup(gn);
            if (group.Equals(Group)) // ENGINE BUG: Updating this after set with the same group is not caught and results in an exception.
                return;
            Group = org.GetButtonGroup(gn);
        }
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
