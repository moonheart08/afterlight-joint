// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Numerics;

namespace Content.Client._AL.UI.Widgets;

public interface IPinboardAware
{
    public void PositionUpdated(Vector2 pos);
}

