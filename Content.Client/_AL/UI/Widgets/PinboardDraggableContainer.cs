using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Input;

namespace Content.Client._AL.UI.Widgets;

[Virtual]
public class PinboardDraggableContainer : Container
{
    private bool _dragging;

    public bool Enabled { get; set; } = true;

    public PinboardDraggableContainer()
    {
        MouseFilter = MouseFilterMode.Stop;
    }

    protected override void KeyBindDown(GUIBoundKeyEventArgs args)
    {
        base.KeyBindDown(args);

        if (!Enabled)
            return;

        if (args.Function != EngineKeyFunctions.UIClick)
        {
            return;
        }

        _dragging = true;
    }

    protected override void KeyBindUp(GUIBoundKeyEventArgs args)
    {
        base.KeyBindDown(args);

        if (args.Function != EngineKeyFunctions.UIClick)
        {
            return;
        }

        _dragging = false;
    }

    protected override void MouseMove(GUIMouseMoveEventArgs args)
    {
        base.MouseMove(args);

        if (!Enabled)
            return;

        if (!_dragging)
            return;

        var loc = PinboardContainer.GetPinLocation(this);

        loc += args.Relative;

        PinboardContainer.SetPinLocation(this, loc);
        Parent?.InvalidateArrange();
    }

}
