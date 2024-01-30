// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Content.Client._AL.UI.Interfaces;
using Robust.Client.UserInterface;

namespace Content.Client._AL.UI.Widgets.Smart;

public sealed class ApplyButton : Button
{
    private IApplyableDialog? _previousDialog = default;

    public ApplyButton()
    {
        Text = "Apply";
        OnPressed += OnOnPressed;
        Disabled = true;
    }

    private void EnsureRegistered()
    {
        var applyTo = this.GetImplementingParent<IApplyableDialog>();
        if (applyTo is null || _previousDialog == applyTo)
            return;

        if (_previousDialog is not null)
            _previousDialog.OnModified -= ApplyToOnOnModified;
        applyTo.OnModified += ApplyToOnOnModified;
        _previousDialog = applyTo;
    }

    protected override void Parented(Control newParent)
    {
        base.Parented(newParent);
        EnsureRegistered();
    }

    protected override void EnteredTree()
    {
        base.EnteredTree();
        EnsureRegistered();
    }

    private void ApplyToOnOnModified()
    {
        Disabled = false;
    }

    private void OnOnPressed(ButtonEventArgs obj)
    {
        var applyTo = this.GetImplementingParent<IApplyableDialog>();
        applyTo?.Apply();
        Disabled = true;
    }


}
