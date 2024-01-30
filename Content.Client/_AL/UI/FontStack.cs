// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Linq;
using Content.Client.Resources;
using Robust.Client.Graphics;
using Robust.Client.ResourceManagement;
using Robust.Shared.Utility;

namespace Content.Client._AL.UI;

public abstract class FontStack
{
    [Dependency] private readonly IResourceCache _resourceCache = default!;

    /// <summary>
    ///     The primary font path, with string substitution markers.
    /// </summary>
    /// <remarks>
    ///     If using the default GetFont function, the replacements are as follows:
    ///     0 is the font kind.
    ///     1 is the font kind with BoldItalic replaced with Bold when it occurs.
    /// </remarks>
    public abstract string FontPrimary { get; }
    /// <summary>
    ///     The symbols font path, with string substitution markers.
    /// </summary>
    /// <remarks>
    ///     If using the default GetFont function, the replacements are as follows:
    ///     0 is the font kind.
    ///     1 is the font kind with BoldItalic replaced with Bold when it occurs.
    /// </remarks>
    public abstract string FontSymbols { get; }

    /// <summary>
    ///     The fallback font path, exactly. (no string substitutions.)
    /// </summary>
    public virtual string FontFallback => "/EngineFonts/NotoSans/NotoSans-Regular.ttf";

    /// <summary>
    ///     Any extra fonts that should be stuck in after Symbols but before the fallback.
    /// </summary>
    public abstract string[] Extra { get; }

    public virtual FontKind[] AvailableKinds => new[] {FontKind.Regular, FontKind.Bold, FontKind.Italic, FontKind.BoldItalic};

    /// <summary>
    ///     This should return the paths of every font in this stack given the abstract members.
    /// </summary>
    /// <param name="kind">Which font kind to use.</param>
    /// <returns></returns>
    protected virtual string[] GetFontPaths(FontKind kind)
    {
        var sv = kind.SimplifyCompound().AsFileName();
        var s = kind.AsFileName();
        var l =  new List<string>()
        {
            string.Format(FontPrimary, s, sv),
            string.Format(FontSymbols, s, sv),
        };
        l.AddRange(Extra);
        l.Add(FontFallback);
        return l.ToArray();
    }

    /// <summary>
    ///     Retrieves an in-style font, of the provided size and kind.
    /// </summary>
    /// <param name="size">Size of the font to provide.</param>
    /// <param name="kind">Optional font kind. Defaults to Regular.</param>
    /// <returns>A Font resource.</returns>
    public Font GetFont(int size, FontKind kind = FontKind.Regular)
    {
        ALDebugTools.AssertContains(AvailableKinds, kind);
        var paths = GetFontPaths(kind);

        return _resourceCache.GetFont(paths, size);
    }

    protected FontStack()
    {
        IoCManager.InjectDependencies(this);
    }

    /// <summary>
    ///     The available kinds of font.
    /// </summary>
    public enum FontKind
    {
        Regular,
        Bold,
        Italic,
        BoldItalic
    }
}

public static class FontKindExtensions
{
    public static string AsFileName(this FontStack.FontKind kind)
    {
        return kind switch
        {
            FontStack.FontKind.Regular => "Regular",
            FontStack.FontKind.Bold => "Bold",
            FontStack.FontKind.Italic => "Italic",
            FontStack.FontKind.BoldItalic => "BoldItalic",
            _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, null)
        };
    }

    public static bool IsBold(this FontStack.FontKind kind)
    {
        return kind == FontStack.FontKind.Bold || kind == FontStack.FontKind.BoldItalic;
    }

    public static bool IsItalic(this FontStack.FontKind kind)
    {
        return kind == FontStack.FontKind.Italic || kind == FontStack.FontKind.BoldItalic;
    }

    public static FontStack.FontKind SimplifyCompound(this FontStack.FontKind kind)
    {
        return kind switch
        {
            FontStack.FontKind.BoldItalic => FontStack.FontKind.Bold,
            _ => kind
        };
    }
}
