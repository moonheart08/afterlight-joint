using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using Content.Client._AL.UI.Styleboxes;
using Content.Client._AL.UI.Widgets;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.Client._AL.UI.ALStylesheetHelpers;

namespace Content.Client._AL.UI;

public sealed class ALStyle : BaseStyle
{
    public override string FileRoot => "/Textures/_AL/Interface";

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

    public static readonly Vector2 WindowExtrusion = new(0, 3);
    public static readonly Vector2 ButtonExtrusion = new(0, 3);
    public static readonly Vector2 ButtonExtrusionPartial = new(0, 2);
    public static readonly Vector2 SliderExtrusion = new(0, 2);

    public const float SwitchToDarkLevel = 0.65f;

    [SuppressMessage("ReSharper", "AccessToStaticMemberViaDerivedType")]
    public ALStyle(IResourceCache resCache) : base(resCache)
    {
        var ourRules = new StyleRule[]
        {
            Element().Class(Style.WindowBackground).Prop(PanelContainer.StylePropertyPanel, PanelBackgrounds[2]),
            Element().Class(Style.WindowContentsBackground).Prop(PanelContainer.StylePropertyPanel, PanelBackgrounds[0].Extrude(WindowExtrusion)),

            /* AL's button overrides. This just extrudes them out. */
            Button().Normal().Prop(Style.StyleBox, ButtonBackgrounds[2].Extrude(ButtonExtrusion)),
            Button().Hover().Prop(Style.StyleBox, ButtonBackgrounds[3].Extrude(ButtonExtrusionPartial)),
            Button().Pressed().Prop(Style.StyleBox, ButtonBackgrounds[1]),
            Button().Disabled().Prop(Style.StyleBox, ButtonBackgrounds[0].Extrude(ButtonExtrusion)),

            Button().Positive().Normal().Prop(Style.StyleBox, ButtonPositiveBackgrounds[2].Extrude(ButtonExtrusion)),
            Button().Positive().Hover().Prop(Style.StyleBox, ButtonPositiveBackgrounds[3].Extrude(ButtonExtrusionPartial)),
            Button().Positive().Pressed().Prop(Style.StyleBox, ButtonPositiveBackgrounds[1]),
            Button().Positive().Disabled().Prop(Style.StyleBox, ButtonPositiveBackgrounds[0].Extrude(ButtonExtrusion)),

            Button().Negative().Normal().Prop(Style.StyleBox, ButtonNegativeBackgrounds[2].Extrude(ButtonExtrusion)),
            Button().Negative().Hover().Prop(Style.StyleBox, ButtonNegativeBackgrounds[3].Extrude(ButtonExtrusionPartial)),
            Button().Negative().Pressed().Prop(Style.StyleBox, ButtonNegativeBackgrounds[1]),
            Button().Negative().Disabled().Prop(Style.StyleBox, ButtonNegativeBackgrounds[0].Extrude(ButtonExtrusion)),
            Element<HBar>().Prop(Style.BarStyleboxes, SecondarySolidBackgrounds[0..4].ToArray()),

            /* Sliders */
            Element<Slider>()
                .Prop(Slider.StylePropertyBackground, LoadTexture($"{FileRoot}/slider_fill.png").ToPatchStyleBox(14).Modulate("#141111FF"))
                .Prop(Slider.StylePropertyForeground, LoadTexture($"{FileRoot}/slider_outline.png").ToPatchStyleBox(14).Modulate(SecondaryPalette[4]).Extrude(SliderExtrusion))
                .Prop(Slider.StylePropertyGrabber, LoadTexture($"{FileRoot}/slider_grabber.png").ToPatchStyleBox(14).Zoom(2))
                .Prop(Slider.StylePropertyFill, LoadTexture($"{FileRoot}/slider_fill.png").ToPatchStyleBox(14).Modulate(PrimaryPalette[1])),


            /* Legacy/built-in window compat */
            Element().Class(DefaultWindow.StyleClassWindowPanel)
                .Prop(PanelContainer.StylePropertyPanel, PanelBackgrounds[0].Extrude(WindowExtrusion)),
            Element().Class(Style.BorderedWindowPanel)
                .Prop(PanelContainer.StylePropertyPanel, PanelBackgrounds[0].Extrude(WindowExtrusion)),

            /* Font color stuff */
            Element().BrighterThan(SwitchToDarkLevel).Prop(Style.FontColorLightBg, SecondaryPalette[4]),
        };

        Stylesheet = new(BaseRules.Concat(ourRules).ToArray());
    }

    public override Stylesheet Stylesheet { get; }
}
