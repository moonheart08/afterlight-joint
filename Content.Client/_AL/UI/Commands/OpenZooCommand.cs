using Content.Client._AL.UI.Windows;
using Robust.Shared.Toolshed;

namespace Content.Client._AL.UI.Commands;

[ToolshedCommand]
public sealed class OpenZooCommand : ToolshedCommand
{
    [CommandImplementation]
    public void Open()
    {
        var w = new ALZoo();

        w.Open();
    }
}
