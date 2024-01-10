using Content.Client._AL.UI.Interfaces;
using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets;

[Virtual]
public class Box : BoxContainer
{
    public Box()
    {
        Margin = new Thickness(4);
    }
}
