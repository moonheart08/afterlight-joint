using Robust.Client.UserInterface;

namespace Content.Client._AL.UI.Interfaces;

public interface IApplyableDialog
{
    public event Action? OnModified;

    public abstract void Modified(Control control);

    public abstract void Apply();
}

