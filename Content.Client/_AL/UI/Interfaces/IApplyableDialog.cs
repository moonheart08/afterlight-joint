namespace Content.Client._AL.UI.Interfaces;

public interface IApplyableDialog
{
    public event Action? OnModified;

    public void RegisterOption(IDialogOption option);

    public abstract void Apply();
}

