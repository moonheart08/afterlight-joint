using Content.Client.UserInterface.Controls;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.Client._AL.UI.ALStylesheetHelpers;

namespace Content.Client._AL.UI.Sheets;

[Stylesheet]
public sealed class ContentMenuButtons : BaseSubsheet
{
    public override StyleRule[] GetRules(BaseStyle origin)
    {
        return new StyleRule[]
        {
            E<MenuButton>().ParentOf<BoxContainer>().ParentOf<Label>()
                .Prop(StyleSelectors.Font, origin.Font.GetFont(origin.BaseFontSize + 2, FontStack.FontKind.Bold)),

            E<MenuButton>().Normal().ParentOf<BoxContainer>().ParentOf<Label>()
                .Prop(StyleSelectors.FontColor, origin.PrimaryPalette[1]),
            E<MenuButton>().Hover().ParentOf<BoxContainer>().ParentOf<Label>()
                .Prop(StyleSelectors.FontColor, origin.PrimaryPalette[0]),
            E<MenuButton>().Pressed().ParentOf<BoxContainer>().ParentOf<Label>()
                .Prop(StyleSelectors.FontColor, origin.PrimaryPalette[2]),
            E<MenuButton>().Disabled().ParentOf<BoxContainer>().ParentOf<Label>()
                .Prop(StyleSelectors.FontColor, origin.PrimaryPalette[3]),

            E<MenuButton>().Normal().ParentOf<BoxContainer>().ParentOf<TextureRect>()
                .Prop(StyleSelectors.ModulateSelf, origin.PrimaryPalette[1]),
            E<MenuButton>().Hover().ParentOf<BoxContainer>().ParentOf<TextureRect>()
                .Prop(StyleSelectors.ModulateSelf, origin.PrimaryPalette[0]),
            E<MenuButton>().Pressed().ParentOf<BoxContainer>().ParentOf<TextureRect>()
                .Prop(StyleSelectors.ModulateSelf, origin.PrimaryPalette[2]),
            E<MenuButton>().Disabled().ParentOf<BoxContainer>().ParentOf<TextureRect>()
                .Prop(StyleSelectors.ModulateSelf, origin.PrimaryPalette[3]),
        };
    }
}
