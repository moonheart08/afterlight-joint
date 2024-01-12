using Content.Client._AL.UI.Misc;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Robust.Client.UserInterface.StylesheetHelpers;

namespace Content.Client._AL.UI;

public static class ALStylesheetHelpers
{
    public static MutableSelectorElement E<T>()
        where T: Control
    {
        return Element<T>();
    }

    public static MutableSelectorChild ParentOf(this MutableSelector selector, MutableSelector other)
    {
        return Child().Parent(selector).Child(other);
    }

    public static MutableSelectorChild ParentOf<TOther>(this MutableSelector selector)
        where TOther: Control
    {
        return selector.ParentOf(Element<TOther>());
    }

    public static MutableSelectorElement Button()
    {
        var e = new MutableSelectorElement() {Type = typeof(ContainerButton)}.Class(ContainerButton.StyleClassButton);
        return e;
    }

    public static MutableSelectorElement Button<T>()
    {
        var e = new MutableSelectorElement() {Type = typeof(T)};
        return e;
    }

    public static MutableSelectorElement Positive(this MutableSelectorElement i)
    {
        return i.Class(Style.Positive);
    }

    public static MutableSelectorElement Negative(this MutableSelectorElement i)
    {
        return i.Class(Style.Negative);
    }

    public static MutableSelectorElement Normal(this MutableSelectorElement i)
    {
        return i.Pseudo(ContainerButton.StylePseudoClassNormal);
    }

    public static MutableSelectorElement Hover(this MutableSelectorElement i)
    {
        return i.Pseudo(ContainerButton.StylePseudoClassHover);
    }

    public static MutableSelectorElement Pressed(this MutableSelectorElement i)
    {
        return i.Pseudo(ContainerButton.StylePseudoClassPressed);
    }

    public static MutableSelectorElement Disabled(this MutableSelectorElement i)
    {
        return i.Pseudo(ContainerButton.StylePseudoClassDisabled);
    }

    public static MutableSelectorLuminance BrighterThan(this MutableSelector selector, float lum)
    {
        return new(selector, lum, SelectorLuminance.SelectorMode.GreaterThan);
    }

    public static MutableSelectorLuminance DarkerThan(this MutableSelector selector, float lum)
    {
        return new(selector, lum, SelectorLuminance.SelectorMode.LessThan);
    }
}
