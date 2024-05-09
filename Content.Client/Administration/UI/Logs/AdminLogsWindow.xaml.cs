﻿using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.Administration.UI.Logs;

[GenerateTypedNameReferences]
public sealed partial class AdminLogsWindow : Content.AL.UIKit.Widgets.Window
{
    public AdminLogsWindow()
    {
        RobustXamlLoader.Load(this);
    }
}
