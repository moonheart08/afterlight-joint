// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Numerics;
using Content.AL.UIKit;
using Content.AL.UIKit.Sheets;
using Content.Client._AL.UI.Sheets;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.AL.UIKit.ALStylesheetHelpers;

namespace Content.Client._AL.UI.Widgets;

[Stylesheet]
public sealed class WindowStylesheet : BaseSubsheet
{
    public override StyleRule[] GetRules(BaseStyle origin)
    {
        var (WindowTextures, _, _) =
            origin.LoadIndefiniteNinePatchSet($"{origin.FileRoot}/window_cross_{{0}}.png", 0);
        return new StyleRule[]
        {
            Element().Class(ALStyleConsts.WindowBackground).Prop(PanelContainer.StylePropertyPanel, origin.PanelBackgrounds[0]),
            Element().Class(ALStyleConsts.WindowContentsBackground).Prop(PanelContainer.StylePropertyPanel, origin.PanelBackgrounds[0]),
            E<TextureButton>().Class(DefaultWindow.StyleClassWindowCloseButton)
                .Prop(TextureButton.StylePropertyTexture, WindowTextures[2]),
            E<TextureButton>().Class(DefaultWindow.StyleClassWindowCloseButton)
                .Prop(nameof(Control.SetWidth), 32.0f)
                .Prop(nameof(Control.SetHeight), 32.0f),

            E<TextureButton>().Hover().Class(DefaultWindow.StyleClassWindowCloseButton)
                .Prop(TextureButton.StylePropertyTexture, WindowTextures[3]),
            E<TextureButton>().Pressed().Class(DefaultWindow.StyleClassWindowCloseButton)
                .Prop(TextureButton.StylePropertyTexture, WindowTextures[1]),

            E<TextureRect>().Class("WindowIcon")
                .Prop(TextureRect.StylePropertyTextureSizeTarget, new Vector2(28, 28)),
        };
    }
}
