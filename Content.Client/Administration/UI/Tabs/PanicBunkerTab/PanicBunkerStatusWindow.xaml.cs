﻿using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.Administration.UI.Tabs.PanicBunkerTab;

[GenerateTypedNameReferences]
public sealed partial class PanicBunkerStatusWindow : Content.AL.UIKit.Widgets.Window
{
    public PanicBunkerStatusWindow()
    {
        RobustXamlLoader.Load(this);
    }
}
