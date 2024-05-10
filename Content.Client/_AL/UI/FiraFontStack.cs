using Content.AL.UIKit;

namespace Content.Client._AL.UI;

public sealed class FiraFontStack : FontStack
{
    public override string FontPrimary => "/Fonts/FiraMono/FiraMono-{0}.ttf";

    public override string FontSymbols => "/Fonts/NotoSans/NotoSansSymbols-{1}.ttf";

    public override string[] Extra => Array.Empty<string>();


    public override FontKind[] AvailableKinds => new[] {FontKind.Bold, FontKind.Regular};
}
