using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets;

public abstract class Scrollable : ScrollContainer
{
    protected override void ChildAdded(Control newChild)
    {
        base.ChildAdded(newChild);

        if (ChildCount > 1)
            throw new Exception(
                "Scrollable controls cannot contain more than one child, as they are a modifier to another control.");

    }
}
