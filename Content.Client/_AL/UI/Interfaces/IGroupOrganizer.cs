using System.Linq;
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

    /// <summary>
    ///     Returns the available group, if there is only one. Otherwise, throws.
    /// </summary>
    /// <returns>A buttongroup.</returns>
    public ButtonGroup GetGroup()
    {
        if (Groups.Count == 1)
        {
            return Groups.Values.First();
        }

        throw new Exception("Ambiguous GetGroup!");
    }
}

