using Content.Client._AL.UI.Interfaces;
using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets;

[Virtual]
public class Stack : BoxContainer
{
    public Stack()
    {
        Margin = new Thickness(4);
    }
}

[Virtual]
public class VStack : Stack
{
    public VStack()
    {
        Orientation = LayoutOrientation.Vertical;
        HorizontalExpand = false;
        VerticalExpand = false;
    }
}

[Virtual]
public class VGrowStack : VStack
{
    public VGrowStack()
    {
        VerticalExpand = true;
    }
}

[Virtual]
public class VFill : VGrowStack
{
}

[Virtual]
public class HStack : Stack
{
    public HStack()
    {
        Orientation = LayoutOrientation.Horizontal;
        HorizontalExpand = false;
        VerticalExpand = false;
    }
}

[Virtual]
public class HGrowStack : HStack
{
    public HGrowStack()
    {
        HorizontalExpand = true;
    }
}

[Virtual]
public class HFill : HGrowStack
{
}
