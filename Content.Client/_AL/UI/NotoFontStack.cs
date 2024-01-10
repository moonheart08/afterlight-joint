namespace Content.Client._AL.UI;

public sealed class NotoFontStack : FontStack
{
    private string _variant;

    public NotoFontStack(string variant = "")
    {
        _variant = variant;
    }

    public override string FontPrimary => $"/Fonts/NotoSans{_variant}/NotoSans{_variant}-{{0}}.ttf";

    public override string FontSymbols => "/Fonts/NotoSans/NotoSansSymbols-{1}.ttf";

    public override string[] Extra => new[] { "/Fonts/NotoSans/NotoSansSymbols2-Regular.ttf" };


}
