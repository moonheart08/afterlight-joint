using Content.Client._AL.UI.Interfaces;
using Robust.Client.UserInterface;
using Robust.Shared.Sandboxing;

namespace Content.Client._AL.UI.Widgets.Smart;

public interface IFieldSet
{
    public object? ReadField(string fieldName);
    public bool WriteField(string fieldName, object value);
}

public sealed class FieldGroup : Control
{
    public event Action? OnModified;
    public event Action? OnReset;

    private Type _type = default!;
    private IFieldSet _set = default!;

    public Type Type
    {
        set
        {
            _type = value;
            Set = (IFieldSet)IoCManager.Resolve<ISandboxHelper>().CreateInstance(value);
        }
    }

    public IFieldSet Set
    {
        get => _set;
        set
        {
            _set = value;
            OnReset?.Invoke();
        }
    }

    public void Reset()
    {
        Set = (IFieldSet)IoCManager.Resolve<ISandboxHelper>().CreateInstance(_type);
        OnReset?.Invoke();
    }

    public object? ReadField(string fieldName)
    {
        return Set.ReadField(fieldName);
    }

    public bool WriteField(string fieldName, object value)
    {
        var res = Set.WriteField(fieldName, value);

        if (this.GetImplementingParent<IApplyableDialog>() is { } dialog)
        {
            dialog.Modified(this); // We changed!
            OnModified?.Invoke();
        }

        return res;
    }

}
