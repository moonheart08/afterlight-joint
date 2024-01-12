namespace Content.Client._AL.UI.Widgets.Decorative;

/// <summary>
///     A set of vertical bars meant to look like a grille. Decorative, no function.
/// </summary>
public sealed class BarPatch : VStack
{
    public BarPatch()
    {
        VerticalExpand = false;
        VerticalAlignment = VAlignment.Center;
        HorizontalExpand = true;
        HorizontalAlignment = HAlignment.Stretch;
    }

    public int Count
    {
        set
        {
            RemoveAllChildren();
            for (int i = 0; i < value; i++)
            {
                AddChild(new HBar { Margin = new (2)});
            }
        }
    }
}
