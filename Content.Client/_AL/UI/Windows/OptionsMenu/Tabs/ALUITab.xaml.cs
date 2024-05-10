﻿// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Content.AL.UIKit.Widgets;
using Content.AL.UIKit.Widgets.Smart;
using Content.AL.UIKit.Widgets;
using Content.Client.UserInterface.Screens;
using Content.Shared.CCVar;
using JetBrains.Annotations;
using Robust.Client.AutoGenerated;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface.XAML;
using Robust.Shared;
using Robust.Shared.Configuration;

namespace Content.Client._AL.UI.Windows.OptionsMenu.Tabs;

[GenerateTypedNameReferences]
// ReSharper disable once InconsistentNaming
public sealed partial class ALUITab : VGrowStack
{
    [Dependency] private readonly IResourceCache _cache = default!;

    public ALUITab()
    {
        IoCManager.InjectDependencies(this);
        RobustXamlLoader.Load(this);
        var m = Margin;
        m.Top = 0;
        Margin = m;

        StyleConfigGroup.OnModified += UpdateTestPane;

    }

    protected override void EnteredTree()
    {
        base.EnteredTree();
        StyleConfigGroup.Set = ALStyleConfig.FromCVars();
        UICVarsGroup.Set = UICVarsConfig.FromCVars();
    }

    public void Apply()
    {
        var cfg = (ALStyleConfig) StyleConfigGroup.Set;
        var cfg2 = (UICVarsConfig) UICVarsGroup.Set;
        cfg.ToCVars();
        cfg2.ToCVars();
    }

    private void UpdateTestPane()
    {
        TestPane.Stylesheet = new ALStyle(_cache, (ALStyleConfig)StyleConfigGroup.Set).Stylesheet;
    }
}


// ReSharper disable once InconsistentNaming
public sealed class UICVarsConfig : IFieldSet
{
    public UIScale Scale;
    public ScreenType Layout;

    public static UICVarsConfig FromCVars()
    {
        var cfg = IoCManager.Resolve<IConfigurationManager>();
        if (!Enum.TryParse(cfg.GetCVar(CCVars.UILayout), out ScreenType layout))
            layout = ScreenType.Default;
        return new UICVarsConfig()
        {
            Scale = cfg.GetCVar(CVars.DisplayUIScale).AsUIScale() ?? UIScale.ScaleAuto,
            Layout =  layout,
        };
    }

    public void ToCVars()
    {
        var cfg = IoCManager.Resolve<IConfigurationManager>();
        cfg.SetCVar(CVars.DisplayUIScale, Scale.AsFloat());
        cfg.SetCVar(CCVars.UILayout, Layout.ToString());
    }

    public object? ReadField(string fieldName)
    {
        return fieldName switch
        {
            nameof(Scale) => Scale,
            nameof(Layout) => Layout,
            _ => null,
        };
    }

    public bool WriteField(string fieldName, object value)
    {
        object? discard = fieldName switch
        {
            nameof(Scale) => Scale = (UIScale)value,
            nameof(Layout) => Layout = (ScreenType)value,
            _ => null,
        };

        return discard != null;
    }
}

[PublicAPI]
public enum UIScale
{
    ScaleAuto,
    Scale50,
    Scale75,
    Scale100,
    Scale125,
    Scale150,
    Scale175,
    Scale200,
    Scale225,
    Scale250,
    Scale275,
    Scale300
}

public static class UIScaleExtensions
{
    public static float AsFloat(this UIScale scale)
    {
        if (scale == UIScale.ScaleAuto)
            return 0;
        return (((int) scale) * 0.25f) + 0.25f;
    }

    public static UIScale? AsUIScale(this float scale)
    {
        var v = (scale / 0.25f);
        if (v == 0)
            return UIScale.ScaleAuto;

        return (UIScale) (int)float.Floor(v - 1);
    }
}