using Content.Client._AL.UI.Interfaces;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets;

[Virtual]
public class Text : Label
{
    public Text()
    {
        Margin = new Thickness(2);
    }
}
