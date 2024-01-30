// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Robust.Client.UserInterface;

namespace Content.Client._AL.UI.Widgets.Smart;

public sealed class FieldInputLabel : InputLabel
{
    public string? TargetField { get; set; }

    private new FieldGroup? Group { get; set; }

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
        if (Group is null)
            return;
        Text = Loc.GetString($"fieldinput-{Group!.Set.GetType().Name}-{TargetField}");
    }
}
