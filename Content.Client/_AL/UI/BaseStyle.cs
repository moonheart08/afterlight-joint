using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using Content.Client._AL.UI.Sheets;
using Content.Client._AL.UI.Styleboxes;
using Content.Client._AL.UI.Widgets;
using Content.Client.Resources;
using Content.Client.UserInterface.Controls;
using Robust.Client.Graphics;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using Robust.Shared.Reflection;
using Robust.Shared.Sandboxing;
using Robust.Shared.Utility;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.Client._AL.UI.ALStylesheetHelpers;

namespace Content.Client._AL.UI;

public abstract class BaseStyle
{
    [Dependency] public readonly IUserInterfaceManager UserInterface = default!;
    [Dependency] public readonly IReflectionManager Reflection = default!;
    [Dependency] public readonly ISandboxHelper SandboxHelper = default!;

    public abstract string FileRoot { get; }
    /// <summary>
    ///     A five color, intense palette used for primary colors.
    /// </summary>
    public abstract Color[] PrimaryPalette { get; }
    /// <summary>
    ///     A five color, dull palette used for secondary colors i.e. window backgrounds.
    /// </summary>
    public abstract Color[] SecondaryPalette { get; }

    public readonly IResourceCache ResourceCache;

    #region Textures
    public Texture[] PanelBackgroundTextures;
    public StyleBox[] PanelBackgrounds;
    public Texture[] ButtonBackgroundTextures;
    public StyleBox[] ButtonBackgrounds;
    public Texture[] ButtonPositiveBackgroundTextures;
    public StyleBox[] ButtonPositiveBackgrounds;
    public Texture[] ButtonNegativeBackgroundTextures;
    public StyleBox[] ButtonNegativeBackgrounds;

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
        IoCManager.InjectDependencies(this);
        ResourceCache = resCache;
        /* Panel textures */
        PrimarySolidBackgrounds = PrimaryPalette.Select(x => (StyleBox)new StyleBoxFlat(x)).ToArray();
        SecondarySolidBackgrounds = SecondaryPalette.Select(x => (StyleBox)new StyleBoxFlat(x)).ToArray();
        (PanelBackgroundTextures, PanelBackgrounds, _)
            = LoadIndefiniteNinePatchSet($"{FileRoot}/panel_bg_{{0}}.png", PanelMargin);
        (ButtonBackgroundTextures, ButtonBackgrounds, _)
            = LoadIndefiniteNinePatchSet($"{FileRoot}/button_bg_{{0}}.png", PanelMargin);
        (ButtonPositiveBackgroundTextures, ButtonPositiveBackgrounds, _)
            = LoadIndefiniteNinePatchSet($"{FileRoot}/button_positive_bg_{{0}}.png", PanelMargin);
        (ButtonNegativeBackgroundTextures, ButtonNegativeBackgrounds, _)
            = LoadIndefiniteNinePatchSet($"{FileRoot}/button_negative_bg_{{0}}.png", PanelMargin);



        BaseRules = new StyleRule[]
        {
            Element().Prop(Style.BackgroundPanelStyleboxes, PanelBackgrounds),
            Element().Prop(Style.PrimaryPalette, PrimaryPalette),
            Element().Prop(Style.SecondaryPalette, SecondaryPalette),

            /* TEXT AND FONTS */
            Element().Prop(Style.Font, Font.GetFont(BaseFontSize)),
            Element().Class(Style.Bold)
                .Prop(Style.Font, Font.GetFont(BaseFontSize, FontStack.FontKind.Bold)),
            Element().Prop(Style.FontColor, SecondaryPalette[0]),


            /* Horizontal and vertical bars */
            E<HBar>().Prop(Style.StyleBox, SecondarySolidBackgrounds[0]),

            /* Sliders */
            E<Slider>()
                .Prop(Slider.StylePropertyBackground, LoadTexture($"{FileRoot}/slider_fill.png").ToPatchStyleBox(14).Modulate("#141111FF"))
                .Prop(Slider.StylePropertyForeground, LoadTexture($"{FileRoot}/slider_outline.png").ToPatchStyleBox(14).Modulate(SecondaryPalette[4]))
                .Prop(Slider.StylePropertyGrabber, LoadTexture($"{FileRoot}/slider_grabber.png").ToPatchStyleBox(14).Zoom(2))
                .Prop(Slider.StylePropertyFill, LoadTexture($"{FileRoot}/slider_fill.png").ToPatchStyleBox(14).Modulate(PrimaryPalette[1])),
            E<TextureButton>().ParentOf(E<TextureRect>())
                .Prop(TextureRect.StylePropertyTextureStretch, TextureRect.StretchMode.KeepCentered)
        }
            // Load all the stylesheet pieces.
            .Concat(GetRulesFromAttribute<StylesheetAttribute>()).ToArray();
    }



    #region Texture loading utilities

    public bool TryLoadTexture(string target, [NotNullWhen(true)] out Texture? texture)
    {
        var success = ResourceCache.TryGetResource<TextureResource>(new ResPath(target), out var res);
        texture = null;
        if (res is null)
            return success;
        texture = res;
        return success;
    }

    public Texture LoadTexture(string target)
    {
        return ResourceCache.GetTexture(target);
    }

    public Texture[] LoadTextureSet(string target, int amount)
    {
        var tx = new Texture[amount];
        for (var i = 0; i < amount; i++)
        {
            tx[i] = ResourceCache.GetTexture(string.Format(target, i));
        }

        return tx;
    }

    public (Texture[] textures, int found) LoadIndefiniteTextureSet(string target)
    {
        var tx = new List<Texture>();
        var i = 0;
        while (ResourceCache.ContentFileExists(string.Format(target, i)))
        {
            tx.Add(ResourceCache.GetTexture(string.Format(target, i)));
            i++;
        }

        return (tx.ToArray(), i);
    }

    public (Texture[] textures, StyleBox[] boxes, int found) LoadIndefiniteNinePatchSet(string target, int margin)
    {
        var (textures, found) = LoadIndefiniteTextureSet(target);
        return (textures, textures.ToPatchStyleBoxes(margin), found);
    }
    #endregion

    #region Subsheets

    public List<BaseSubsheet> GetFromAttribute<T>()
        where T: Attribute
    {
        var tys = Reflection.FindTypesWithAttribute<T>();
        var outp = new List<BaseSubsheet>();

        foreach (var t in tys)
        {
            var value = (BaseSubsheet) SandboxHelper.CreateInstance(t);
            outp.Add(value);
        }

        return outp;
    }

    public StyleRule[] GetRules(List<BaseSubsheet> sheets)
    {
        var outp = new List<StyleRule>();
        foreach (var sheet in sheets)
        {
            outp.AddRange(sheet.GetRules(this));
        }

        return outp.ToArray();
    }

    public StyleRule[] GetRulesFromAttribute<T>()
        where T: Attribute
    {
        return GetRules(GetFromAttribute<T>());
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
        return new StyleBoxScaled(box, amount);
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
