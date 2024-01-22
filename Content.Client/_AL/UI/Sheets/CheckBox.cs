using System.Numerics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.Client._AL.UI.ALStylesheetHelpers;


namespace Content.Client._AL.UI.Sheets;

[Stylesheet]
public sealed class CheckBox : BaseSubsheet
{
    public override StyleRule[] GetRules(BaseStyle origin)
    {
        return new StyleRule[]
        {
            E<TextureRect>().Class(Robust.Client.UserInterface.Controls.CheckBox.StyleClassCheckBox)
                .Prop(TextureRect.StylePropertyTexture, origin.LoadTexture($"{origin.FileRoot}/checkbox_off.png"))
                .Prop(TextureRect.StylePropertyTextureSizeTarget, new Vector2(28, 28)),
            E<TextureRect>().Class(Robust.Client.UserInterface.Controls.CheckBox.StyleClassCheckBoxChecked)
                .Prop(TextureRect.StylePropertyTexture, origin.LoadTexture($"{origin.FileRoot}/checkbox_on.png"))
                .Prop(TextureRect.StylePropertyTextureSizeTarget, new Vector2(28, 28)),
        };
    }
}
