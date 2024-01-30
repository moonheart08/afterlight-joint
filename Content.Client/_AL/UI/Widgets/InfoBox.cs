// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets;

public sealed class InfoBox : BorderedPanel
{
    public Text Label { get; } = new();

    public string Header
    {
        set
        {
            Label.Text = value;
        }
    }

    private BoxContainer Inner { get; } = new() { Orientation = BoxContainer.LayoutOrientation.Vertical};
    private PanelContainer InnerPanel { get; } = new() { VerticalExpand = true };

    public InfoBox()
    {
        Label.AddStyleClass(Style.Bold);
        Label.HorizontalAlignment = HAlignment.Center;
        Label.HorizontalExpand = true;
        AddChild(Inner);
        Inner.AddChild(Label);
        Inner.AddChild(InnerPanel);
        InnerPanel.Margin = new Thickness(-3);
        XamlChildren = InnerPanel.Children;
    }

    public override void OnDepthUpdate(int n)
    {
        base.OnDepthUpdate(n);
        InnerPanel.PanelOverride = PanelOverride;
    }
}
