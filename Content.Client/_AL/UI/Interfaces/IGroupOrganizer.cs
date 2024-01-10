using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Interfaces;

public interface IGroupOrganizer
{
    public Dictionary<string, ButtonGroup> Groups { get; }

    public ButtonGroup GetButtonGroup(string group)
    {
        if (!Groups.TryGetValue(group, out var g))
        {
            g = new();
            Groups[group] = g;
        }

        return g;
    }
}

