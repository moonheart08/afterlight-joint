// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Robust.Client.UserInterface;

namespace Content.Client._AL.UI.Sheets;

public abstract class BaseSubsheet
{
    public abstract StyleRule[] GetRules(BaseStyle origin);

    public BaseSubsheet()
    {
    }
}
