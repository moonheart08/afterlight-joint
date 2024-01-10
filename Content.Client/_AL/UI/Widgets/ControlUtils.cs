using Robust.Client.UserInterface;

namespace Content.Client._AL.UI.Widgets;

public static class ControlUtils
{
    public static T? GetImplementingParent<T>(this Control self)
        where T: notnull
    {
        var s = self;
        while (true)
        {
            s = s.Parent;
            if (s is null)
                return default;
            if (s is T impl)
                return impl;
        }
    }
}
