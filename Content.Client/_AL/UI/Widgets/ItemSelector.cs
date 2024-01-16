using System.Runtime.InteropServices;

namespace Content.Client._AL.UI.Widgets;

[Virtual]
public class ItemSelector : Button
{
    public ItemSelector()
    {
        // TODO: Compute needed width from selectable items.
        HorizontalExpand = true;
    }


}
