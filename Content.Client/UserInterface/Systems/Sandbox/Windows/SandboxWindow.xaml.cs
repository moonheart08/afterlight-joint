﻿using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.UserInterface.Systems.Sandbox.Windows;

[GenerateTypedNameReferences]
public sealed partial class SandboxWindow : Content.AL.UIKit.Widgets.Window
{
    public SandboxWindow()
    {
        RobustXamlLoader.Load(this);
    }
}
