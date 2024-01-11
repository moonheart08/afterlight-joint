using Content.Client._AL.UI.Interfaces;
using Robust.Client.UserInterface;

namespace Content.Client._AL.UI.Widgets.Smart;

public sealed class ApplyButton : Button
{
    public ApplyButton()
    {
        Text = "Apply";
        OnPressed += OnOnPressed;
        Disabled = true;
    }

    protected override void Parented(Control newParent)
    {
        base.Parented(newParent);
        var applyTo = this.GetImplementingParent<IApplyableDialog>();
        if (applyTo is null)
            return;
        applyTo.OnModified += ApplyToOnOnModified;
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
