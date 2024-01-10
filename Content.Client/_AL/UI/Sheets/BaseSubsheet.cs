using Robust.Client.UserInterface;

namespace Content.Client._AL.UI.Sheets;

public abstract class BaseSubsheet
{
    public abstract StyleRule[] GetRules(BaseStyle origin);

    public BaseSubsheet()
    {
    }
}
