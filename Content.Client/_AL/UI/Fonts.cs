// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace Content.Client._AL.UI;

public static class Fonts
{
    public static readonly FontStack NotoSans = new NotoFontStack();
    public static readonly FontStack NotoSansDisplay = new NotoFontStack(variant: "Display");
    public static readonly FontStack NotoMono = new SingleFont("/EngineFonts/NotoSans/NotoSansMono-Regular.ttf");
}
