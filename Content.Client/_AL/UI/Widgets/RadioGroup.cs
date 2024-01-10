using Content.Client._AL.UI.Interfaces;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets;

public sealed class RadioGroup : Control, IGroupOrganizer
{
    public Dictionary<string, ButtonGroup> Groups { get; } = new();
}
