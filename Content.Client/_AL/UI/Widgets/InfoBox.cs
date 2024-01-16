using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets;

public sealed class InfoBox : BackgroundPanel
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
