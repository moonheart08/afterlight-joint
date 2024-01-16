using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets.Smart;

public sealed class FieldCheckBox : CheckBox
{
    public string? TargetField { get; set; }

    private new FieldGroup? Group { get; set; }

    public FieldCheckBox()
    {
        OnToggled += OnOnToggled;
    }

    protected override void Parented(Control newParent)
    {
        base.Parented(newParent);
        EnsureGrouped();
    }

    protected override void EnteredTree()
    {
        base.EnteredTree();
        EnsureGrouped();
    }

    private void EnsureGrouped()
    {
        var set = this.GetImplementingParent<FieldGroup>();
        if (set is null || Group == set)
            return;
        if (Group is { } g)
        {
            g.OnReset -= GroupOnReset;
        }
        Group = set;
        set.OnReset += GroupOnReset;
        GroupOnReset();
    }

    private void GroupOnReset()
    {
        EnsureGrouped();
        Pressed = (bool)Group!.ReadField(TargetField!)!;
    }

    private void OnOnToggled(ButtonToggledEventArgs obj)
    {
        EnsureGrouped();
        Group!.WriteField(TargetField!, Pressed);
    }
}
