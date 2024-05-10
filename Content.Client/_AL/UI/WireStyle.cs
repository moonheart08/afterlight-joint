using System.Linq;
using Content.AL.UIKit;
using Content.AL.UIKit.Colorspace;
using Content.AL.UIKit.Widgets;
using Content.Client.Shuttles.UI;
using Content.Client.UserInterface.Controls;
using Robust.Client.Graphics;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.AL.UIKit.ALStylesheetHelpers;
using Button = Content.AL.UIKit.Widgets.Button;

namespace Content.Client._AL.UI;

public sealed class DisplayStyle : BaseStyle
{
    public override string FileRoot => "/Textures/_AL/Interface";

    public override int BaseFontSize => 11;

    public override Color[] PrimaryPalette => new[]
    {
        ALStyle.PrimaryColor,
        ALStyle.PrimaryDesatColor.WithLightness(0.70f),
        ALStyle.PrimaryDesatColor.WithLightness(0.60f),
        ALStyle.PrimaryColor.WithLightness(0.50f),
        ALStyle.PrimaryColor.WithLightness(0.40f)
    };

    public override Color[] SecondaryPalette => new[]
    {
        ALStyle.SecondaryColor,
        ALStyle.SecondaryColor.WithLightness(0.65f),
        ALStyle.SecondaryColor.WithLightness(0.50f),
        ALStyle.SecondaryColor.WithLightness(0.35f),
        ALStyle.SecondaryColor.WithLightness(0.20f),
    };

    public FontStack FiraFont = new FiraFontStack();

    public override FontStack Font => FiraFont;
    public override FontStack MonoFont => FiraFont;

    public DisplayStyle(IResourceCache resCache, ALStyle main) : base(resCache)
    {
        var wireButton = LoadTexture($"{this.FileRoot}/wire_button.png").ToPatchStyleBox(PanelMargin);
        var stripebackInfill = new StyleBoxTexture
        {
            Texture =  LoadTexture($"{FileRoot}/display_fill_bg.png"),
            Mode = StyleBoxTexture.StretchMode.Tile
        };

        var ourRules = new StyleRule[]
        {
            // Margins!
            E<Button>().Margin(2),
            E<BorderedPanel>().Margin(2),
            E<HBar>().Margin(2),
            E<AL.UIKit.Widgets.Stack>().Margin(4),
            E<Text>().Margin(2),
            E<RichText>().Margin(2),
            E<Grid>().Margin(4),
            E<VBorderedPanel>().Margin(2),
            E<HBorderedPanel>().Margin(2),
            // Margins on legacy things!
            E<Label>().Margin(2),
            E<RichTextLabel>().Margin(2),
            E<Robust.Client.UserInterface.Controls.Button>().Margin(2),
            E<Robust.Client.UserInterface.Controls.ContainerButton>().Margin(2),

            Button().Normal().Prop(ALStyleConsts.StyleBox, wireButton.Modulate(PrimaryPalette[1])),
            Button().Hover().Prop(ALStyleConsts.StyleBox, wireButton.Modulate(PrimaryPalette[0])),
            Button().Pressed().Prop(ALStyleConsts.StyleBox, wireButton.Modulate(PrimaryPalette[2])),
            Button().Disabled().Prop(ALStyleConsts.StyleBox, wireButton.Modulate(PrimaryPalette[3])),

            Element().Prop(ALStyle.DisplayStylesheet, this),
            Element().Prop(ALStyle.MainStylesheet, main),
            Element().Prop(Label.StylePropertyFontColor, PrimaryPalette[0]),
            E<VPanel>().Class("TerminalDisplay")
                .Prop(PanelContainer.StylePropertyPanel, ButtonBackgrounds[0].Modulate(Color.FromHex("#111111"))),
            E<PanelContainer>().Class("ShutleDockButtons")
                .Prop(PanelContainer.StylePropertyPanel, stripebackInfill),
            E<StripeBack>()
                .Prop(StripeBack.StylePropertyEdgeColor, PrimaryPalette[0])
                .Prop(StripeBack.StylePropertyBackground, stripebackInfill),
        };

        Stylesheet = new(BaseRules.Concat(ourRules).ToArray());
    }

    public override Stylesheet Stylesheet { get; }
}
