using System.Linq;
using Content.Client._AL.UI.Interfaces;
using Robust.Client.Graphics;

namespace Content.Client._AL.UI.Widgets;

public class ContainerButton : Robust.Client.UserInterface.Controls.ContainerButton, IBrightnessAware
{
    protected StyleBox ActualStyleBox
    {
        get
        {
            if (TryGetStyleProperty<StyleBox>(StylePropertyStyleBox, out var box))
            {
                return box;
            }

            return UserInterfaceManager.ThemeDefaults.ButtonStyle;
        }
    }

    public float Luminance()
    {
        return ActualStyleBox.Luminance();
    }
}
