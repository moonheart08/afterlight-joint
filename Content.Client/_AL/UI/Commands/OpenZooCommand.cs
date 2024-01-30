// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

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
