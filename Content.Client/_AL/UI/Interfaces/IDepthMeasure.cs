using Robust.Client.UserInterface;

namespace Content.Client._AL.UI.Interfaces;

public interface IDepthMeasure<TSelf>
{
    protected void OnDepthUpdate(int n);

    public virtual void CheckChanges(Control self)
    {
        var count = 0;
        while (self.Parent is not null)
        {
            self = self.Parent;
            if (self is IDepthMeasure<TSelf>)
                count++;
        }

        OnDepthUpdate(count);
    }
}

