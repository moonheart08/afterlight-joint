using Content.Client.UserInterface.Systems.Chat.Controls;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.Client._AL.UI.ALStylesheetHelpers;

namespace Content.Client._AL.UI.Sheets;

[Stylesheet]
public sealed class Chat: BaseSubsheet
{
    public override StyleRule[] GetRules(BaseStyle origin)
    {
        MutableSelectorChild FilterButton(Func<MutableSelectorElement, MutableSelectorElement>? mod = null)
        {
            mod ??= x => x;
            return E<ChannelFilterButton>().ParentOf(mod(E<TextureRect>()));
        }

        var sideStyle = origin.PanelBackgroundTextures[0].ToPatchStyleBox(3);
        sideStyle.ExpandMarginRight = 10;
        return new StyleRule[]
        {
            FilterButton().Prop(Control.StylePropertyModulateSelf, origin.SecondaryPalette[0]),
            E<PanelContainer>().Class("ChatBoxPanelBackground")
                .Prop(PanelContainer.StylePropertyPanel, origin.LoadTexture($"{origin.FileRoot}/panel_transparent.png").ToPatchStyleBox(36))
                .Prop(Control.StylePropertyModulateSelf, origin.SecondaryPalette[4].WithAlpha((byte)0xCC)),

            E<PanelContainer>().Class("ChatBoxPanelBackground")
                .Class("HasBackground")
                .Prop(PanelContainer.StylePropertyPanel, origin.PanelBackgrounds[0])
                .Prop(Control.StylePropertyModulateSelf, Color.FromHex("#DFDFDF")),

            E<PanelContainer>().Class("SeparatedChatSidePanel")
                .Prop(PanelContainer.StylePropertyPanel, sideStyle)
        };
    }
}
