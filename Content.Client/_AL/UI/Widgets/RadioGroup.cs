// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Linq;
using Content.Client._AL.UI.Interfaces;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets;

public sealed class RadioGroup : Control, IGroupOrganizer
{
    public Dictionary<string, ButtonGroup> Groups { get; } = new();
}
