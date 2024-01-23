using System.Numerics;
using Content.Client._AL.UI.Sheets;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Utility;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.Client._AL.UI.ALStylesheetHelpers;


namespace Content.Client._AL.UI.Widgets;

// TODO: Replace OptionButton with our own version, so we can stylize it like a drawer.
[Virtual]
public class EnumSelector : OptionButton
{
    public const string EnumSelectorTextureProperty = "selectorTexture";

    public Type? CurrentType { get; private set; }

    public EnumSelector()
    {
        // TODO: Figure out how to calculate the minimum width of the control based on the selectable items.
        //HorizontalExpand = false;
        Margin = new Thickness(2);
        OptionStyleClasses.Add(Style.EnumSelectorOptionClass);
    }

    public Enum Selected => (Enum) SelectedMetadata!;

    public T GetSelected<T>()
        where T : Enum
    {
        return (T) Selected;
    }

    public void Setup(Type selectable)
    {
        CurrentType = selectable;
        var targets = Enum.GetValues(selectable);
        DebugTools.AssertEqual(Enum.GetUnderlyingType(selectable), typeof(int));
        var tValues = Enum.GetValuesAsUnderlyingType(selectable);

        var idx = 0;
        foreach (var v in targets)
        {
            var name = Localize(selectable, Enum.GetName(selectable, v)!);
            var enumVal = (int) tValues.GetValue(idx)!;
            if (TryGetStyleProperty(EnumPropertyName(selectable, name, EnumSelectorTextureProperty), out Texture? tex))
                AddItem(tex!, name, enumVal);
            else
                AddItem(name, enumVal);

            SetItemMetadata(enumVal, v);
            idx++;
        }
    }

    public static string EnumPropertyName(Type t, string enumName, string subProp)
    {
        return $"uiprop-{t.Name}-{enumName}-{subProp}";
    }

    private string Localize(Type t, string enumName)
    {
        return Loc.GetString($"ui-enumselector-{t.Name}-{enumName}");
    }

    public override void ButtonOverride(Robust.Client.UserInterface.Controls.Button button)
    {
        //TODO: This really should be a stylesheet thing but that's a refactor I don't want to take upon myself right now.
        button.Margin = new Thickness(4);
    }
}

[Stylesheet]
public sealed class EnumSelectorSheet : BaseSubsheet
{
    public override StyleRule[] GetRules(BaseStyle origin)
    {
        return new StyleRule[]
        {
            Element().Class(Style.EnumSelectorOptionClass).Normal()
                .Prop(Style.StyleBox, origin.ButtonBackgrounds[2]),
            Element().Class(Style.EnumSelectorOptionClass).Hover()
                .Prop(Style.StyleBox, origin.ButtonBackgrounds[2]),
            Element().Class(Style.EnumSelectorOptionClass).Pressed()
                .Prop(Style.StyleBox, origin.ButtonBackgrounds[2]),
            Element().Class(Style.EnumSelectorOptionClass).Disabled()
                .Prop(Style.StyleBox, origin.ButtonBackgrounds[2]),
        };
    }
}
