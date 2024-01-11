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

    public static string? TryGetLocKey(this Control self)
    {
        if (self.Name is null)
            return null;
        foreach (var ctrl in self.GetSelfAndLogicalAncestors())
        {
            if (ctrl.NameScope is not null)
            {
                return $"ui-{ctrl.GetType()}-{self.Name}";
            }
        }

        return null;
    }

    public static string? TryGetLocString(this Control self, ILocalizationManager manager, string? parameter = null)
    {
        if (TryGetLocKey(self) is not { } key)
            return null;

        if (parameter is not null && manager.TryGetString($"{key}-{parameter}", out var res))
        {
            return res;
        }

        manager.TryGetString(key, out var res2);
        return res2;
    }
}
