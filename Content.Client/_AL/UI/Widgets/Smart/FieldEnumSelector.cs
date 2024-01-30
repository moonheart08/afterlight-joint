// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Robust.Client.UserInterface;

namespace Content.Client._AL.UI.Widgets.Smart;

public sealed class FieldEnumSelector : EnumSelector
{
    public string? TargetField { get; set; }

    private new FieldGroup? Group { get; set; }

    public FieldEnumSelector()
    {
        OnItemSelected += OnOnItemSelected;
    }

    private void OnOnItemSelected(ItemSelectedEventArgs obj)
    {
        EnsureGrouped();
        SelectId(obj.Id);
        Group!.WriteField(TargetField!, Selected);
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
        Setup(Group!.ReadField(TargetField!)!.GetType());
        GroupOnReset();

    }

    private void GroupOnReset()
    {
        EnsureGrouped();
        Select((int)Group!.ReadField(TargetField!)!);
    }
}
