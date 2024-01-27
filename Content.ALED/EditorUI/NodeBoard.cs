using System.Numerics;
using Content.Client._AL.UI;
using Content.Client._AL.UI.Interfaces;
using Content.Client._AL.UI.Sheets;
using Content.Client._AL.UI.Widgets;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Shared.Maths;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.Client._AL.UI.ALStylesheetHelpers;

namespace Content.ALED.EditorUI;

public sealed class NodeBoard : PinboardContainer, IBrightnessAware
{
    public const string NodeBoardStyle = "node-board-background";

    public NodeBoard()
    {
        HorizontalExpand = true;
        VerticalExpand = true;
        Margin = new(4);
    }

    protected override void Draw(DrawingHandleScreen handle)
    {
        base.Draw(handle);
        if (!TryGetStyleProperty(NodeBoardStyle, out StyleBox? box))
            return;

        box!.Draw(handle, UIBox2.FromDimensions(Vector2.Zero, PixelSize), UIScale);
    }

    public float Luminance()
    {
        if (!TryGetStyleProperty(NodeBoardStyle, out StyleBox? box))
            return 0.0f;

        return box.Luminance();
    }
}

[Stylesheet]
public sealed class NodeBoardSheet : BaseSubsheet
{
    public override StyleRule[] GetRules(BaseStyle origin)
    {
        return new StyleRule[]
        {
            E<NodeBoard>().Prop(NodeBoard.NodeBoardStyle, new StyleBoxFlat(Color.FromHex("#120808"))),
        };
    }
}
