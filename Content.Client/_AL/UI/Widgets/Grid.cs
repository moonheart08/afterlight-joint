using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets;

[Virtual]
public class Grid : GridContainer
{
    public Grid()
    {
        Margin = new(4);
    }
}

[Virtual]
public class GrowGrid : Grid
{
    public GrowGrid()
    {
        HorizontalExpand = true;
        VerticalExpand = true;
    }
}
