namespace Content.Client._AL.UI;

public static class Fonts
{
    public static readonly FontStack NotoSans = new NotoFontStack();
    public static readonly FontStack NotoSansDisplay = new NotoFontStack(variant: "Display");
    public static readonly FontStack NotoMono = new SingleFont("/EngineFonts/NotoSans/NotoSansMono-Regular.ttf");
}
