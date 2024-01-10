using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using Content.Client._AL.UI.Styleboxes;
using Content.Client._AL.UI.Widgets;
using Content.Client.Resources;
using Robust.Client.Graphics;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.Client._AL.UI.ALStylesheetHelpers;

namespace Content.Client._AL.UI;

public abstract class BaseStyle
{
    protected abstract string FileRoot { get; }
    /// <summary>
    ///     A five color, intense palette used for primary colors.
    /// </summary>
    public abstract Color[] PrimaryPalette { get; }
    /// <summary>
    ///     A five color, dull palette used for secondary colors i.e. window backgrounds.
    /// </summary>
    public abstract Color[] SecondaryPalette { get; }

    private readonly IResourceCache _resourceCache;

    #region Textures
    public Texture[] PanelBackgroundTextures;
    public StyleBox[] PanelBackgrounds;
    public Texture[] ButtonBackgroundTextures;
    public StyleBox[] ButtonBackgrounds;

    public StyleBox[] PrimarySolidBackgrounds;
    public StyleBox[] SecondarySolidBackgrounds;
    public virtual int PanelMargin => 3;
    #endregion

    #region Fonts
    public virtual int BaseFontSize => 12;
    public virtual FontStack Font => Fonts.NotoSans;
    public virtual FontStack DisplayFont => Fonts.NotoSansDisplay;
    public virtual FontStack MonoFont => Fonts.NotoMono;
    #endregion

    public StyleRule[] BaseRules { get; }

    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    public BaseStyle(IResourceCache resCache)
    {
        _resourceCache = resCache;
        /* Panel textures */
        PrimarySolidBackgrounds = PrimaryPalette.Select(x => (StyleBox)new StyleBoxFlat(x)).ToArray();
        SecondarySolidBackgrounds = SecondaryPalette.Select(x => (StyleBox)new StyleBoxFlat(x)).ToArray();
        (PanelBackgroundTextures, PanelBackgrounds, _)
            = LoadIndefiniteNinePatchSet($"{FileRoot}/panel_bg_{{0}}.png", PanelMargin);
        (ButtonBackgroundTextures, ButtonBackgrounds, _)
            = LoadIndefiniteNinePatchSet($"{FileRoot}/button_bg_{{0}}.png", PanelMargin);

        /* Slider textures */
        var sliderBackBox =

        BaseRules = new StyleRule[]
        {
            Element().Prop(StyleSelectors.BackgroundPanelStyleboxes, PanelBackgrounds),
            Element().Prop(StyleSelectors.PrimaryPalette, PrimaryPalette),
            Element().Prop(StyleSelectors.SecondaryPalette, SecondaryPalette),

            /* TEXT AND FONTS */
            Element().Prop(StyleSelectors.Font, Font.GetFont(_resourceCache, BaseFontSize)),
            Element().Prop(StyleSelectors.FontColor, SecondaryPalette[0]),
            Element().Prop(StyleSelectors.FontColorLightBg, SecondaryPalette[4]),

            /* BUTTONS */
            Button().Normal().Prop(StyleSelectors.StyleBox, ButtonBackgrounds[2]),
            Button().Hover().Prop(StyleSelectors.StyleBox, ButtonBackgrounds[3]),
            Button().Pressed().Prop(StyleSelectors.StyleBox, ButtonBackgrounds[1]),
            Button().Disabled().Prop(StyleSelectors.StyleBox, ButtonBackgrounds[0]),

            /* Horizontal and vertical bars */
            Element<HBar>().Prop(StyleSelectors.StyleBox, SecondarySolidBackgrounds[0]),

            /* Sliders */
            Element<Slider>()
                .Prop(Slider.StylePropertyBackground, LoadTexture($"{FileRoot}/slider_fill.png").ToPatchStyleBox(14).Modulate("#141111FF"))
                .Prop(Slider.StylePropertyForeground, LoadTexture($"{FileRoot}/slider_outline.png").ToPatchStyleBox(14).Modulate(SecondaryPalette[4]))
                .Prop(Slider.StylePropertyGrabber, LoadTexture($"{FileRoot}/slider_grabber.png").ToPatchStyleBox(14).Zoom(2))
                .Prop(Slider.StylePropertyFill, LoadTexture($"{FileRoot}/slider_fill.png").ToPatchStyleBox(14).Modulate(PrimaryPalette[1])),
        };
    }



    #region Texture loading utilities

    protected Texture LoadTexture(string target)
    {
        return _resourceCache.GetTexture(target);
    }

    protected Texture[] LoadTextureSet(string target, int amount)
    {
        var tx = new Texture[amount];
        for (var i = 0; i < amount; i++)
        {
            tx[i] = _resourceCache.GetTexture(string.Format(target, i));
        }

        return tx;
    }

    protected (Texture[] textures, int found) LoadIndefiniteTextureSet(string target)
    {
        var tx = new List<Texture>();
        var i = 0;
        while (_resourceCache.ContentFileExists(string.Format(target, i)))
        {
            tx.Add(_resourceCache.GetTexture(string.Format(target, i)));
            i++;
        }

        return (tx.ToArray(), i);
    }

    protected (Texture[] textures, StyleBox[] boxes, int found) LoadIndefiniteNinePatchSet(string target, int margin)
    {
        var (textures, found) = LoadIndefiniteTextureSet(target);
        return (textures, textures.ToPatchStyleBoxes(margin), found);
    }
    #endregion

    public abstract Stylesheet Stylesheet { get; }

}

public static class StyleExtensions
{
    public static StyleBoxTexture ToPatchStyleBox(this Texture texture, int margin)
    {
            var box = new StyleBoxTexture {Texture = texture};
            box.SetPatchMargin(StyleBox.Margin.All, margin);
            return box;
    }

    public static StyleBox Modulate(this StyleBoxTexture box, Color color)
    {
        box.Modulate = color;
        return box;
    }

    public static StyleBox Modulate(this StyleBoxTexture box, string color)
    {
        return box.Modulate(Color.FromHex(color));
    }

    public static StyleBox MinSize(this StyleBox box, Vector2i size)
    {
        box.ContentMarginBottomOverride = size.Y;
        box.ContentMarginTopOverride = size.Y;
        box.ContentMarginLeftOverride = size.X;
        box.ContentMarginRightOverride = size.X;
        return box;
    }

    public static StyleBox Zoom(this StyleBox box, float amount)
    {
        return new StyleBoxZoomed(box, amount);
    }

    public static StyleBox[] ToPatchStyleBoxes(this Texture[] textures, int margin)
    {
        return textures.Select(x =>
        {
            var box = new StyleBoxTexture {Texture = x};
            box.SetPatchMargin(StyleBox.Margin.All, margin);
            return (StyleBox) box;
        }).ToArray();
    }
}
