using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using Content.Client._AL.UI.Styleboxes;
using Content.Client._AL.UI.Widgets;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.Client._AL.UI.ALStylesheetHelpers;

namespace Content.Client._AL.UI;

public sealed class ALStyle : BaseStyle
{

    protected override string FileRoot => "/Textures/_AL/Interface";

    public override Color[] PrimaryPalette => new[]
    {
        Color.FromHex("#EE9705"),
        Color.FromHex("#C37F0A"),
        Color.FromHex("#7F560D"),
        Color.FromHex("#4E360E"),
        Color.FromHex("#4E360E")
    };

    public override Color[] SecondaryPalette => new[]
    {
        Color.FromHex("#DCD4C5"),
        Color.FromHex("#BAAB99"),
        Color.FromHex("#846F5F"),
        Color.FromHex("#574E4D"),
        Color.FromHex("#393838")
    };

    public static readonly Vector2 ButtonExtrusion = new(0, 3);
    public static readonly Vector2 ButtonExtrusionPartial = new(0, 2);
    public static readonly Vector2 SliderExtrusion = new(0, 2);

    [SuppressMessage("ReSharper", "AccessToStaticMemberViaDerivedType")]
    public ALStyle(IResourceCache resCache) : base(resCache)
    {
        var ourRules = new StyleRule[]
        {
            Button().Normal().Prop(StyleSelectors.StyleBox, ButtonBackgrounds[2].Extrude(ButtonExtrusion)),
            Button().Hover().Prop(StyleSelectors.StyleBox, ButtonBackgrounds[3].Extrude(ButtonExtrusionPartial)),
            Button().Pressed().Prop(StyleSelectors.StyleBox, ButtonBackgrounds[1]),
            Button().Disabled().Prop(StyleSelectors.StyleBox, ButtonBackgrounds[0].Extrude(ButtonExtrusion)),
            Element<HBar>().Prop(StyleSelectors.BarStyleboxes, SecondarySolidBackgrounds[1..4].ToArray()),

            /* Sliders */
            Element<Slider>()
                .Prop(Slider.StylePropertyBackground, LoadTexture($"{FileRoot}/slider_fill.png").ToPatchStyleBox(14).Modulate("#141111FF"))
                .Prop(Slider.StylePropertyForeground, LoadTexture($"{FileRoot}/slider_outline.png").ToPatchStyleBox(14).Modulate(SecondaryPalette[4]).Extrude(SliderExtrusion))
                .Prop(Slider.StylePropertyGrabber, LoadTexture($"{FileRoot}/slider_grabber.png").ToPatchStyleBox(14).Zoom(2))
                .Prop(Slider.StylePropertyFill, LoadTexture($"{FileRoot}/slider_fill.png").ToPatchStyleBox(14).Modulate(PrimaryPalette[0])),
        };

        Stylesheet = new(BaseRules.Concat(ourRules).ToArray());
    }

    public override Stylesheet Stylesheet { get; }
}
