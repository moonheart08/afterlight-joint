// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Robust.Client.UserInterface;

namespace Content.Client._AL.UI.Interfaces;

public interface IDepthMeasure<TSelf>
{
    protected void OnDepthUpdate(int n);

    public virtual void CheckChanges(Control self)
    {
        var count = 0;
        while (self.Parent is not null)
        {
            self = self.Parent;
            if (self is IDepthMeasure<TSelf>)
                count++;
        }

        OnDepthUpdate(count);
    }
}

