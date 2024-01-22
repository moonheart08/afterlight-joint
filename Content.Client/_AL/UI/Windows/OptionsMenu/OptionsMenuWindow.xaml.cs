﻿using System.Linq;
using Content.Client._AL.UI.Interfaces;
using Content.Client._AL.UI.Sheets;
using Content.Client._AL.UI.Widgets;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Configuration;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.Client._AL.UI.ALStylesheetHelpers;

namespace Content.Client._AL.UI.Windows.OptionsMenu;

[GenerateTypedNameReferences]
public sealed partial class OptionsMenuWindow : Window, IApplyableDialog
{
    [Dependency] private readonly IConfigurationManager _cfg = default!;

    public OptionsMenuWindow()
    {
        RobustXamlLoader.Load(this);
    }

    public event Action? OnModified;

    public void Modified(Control control)
    {
        // wink wonk
        OnModified?.Invoke();
    }

    public void Apply()
    {
        UiTab.Apply();
        _cfg.SaveToFile();
    }
}

[Stylesheet]
public sealed class OptionsMenuWindowStyle : BaseSubsheet
{
    public override StyleRule[] GetRules(BaseStyle origin)
    {
        // TODO: something better for this.
        if (!origin.TryLoadTexture($"{origin.FileRoot}/Icons/options_menu_icon.png", out var tex))
            return Array.Empty<StyleRule>();
        return new StyleRule[]
        {
            E<TextureRect>().Class(Window.GetWindowIconStyle(typeof(OptionsMenuWindow)))
                .Prop(TextureRect.StylePropertyTexture, tex)
                .Prop(Control.StylePropertyModulateSelf, origin.SecondaryPalette[0]),
        };
    }
}
