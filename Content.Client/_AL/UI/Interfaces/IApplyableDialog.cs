namespace Content.Client._AL.UI.Interfaces;

public interface IApplyableDialog
{
    public abstract bool Modified { get; }

    public abstract void Apply();
}

