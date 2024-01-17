using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Input;

namespace Content.Client._AL.UI.Widgets;

[Virtual]
public class PinboardDraggableContainer : Container
{
    private bool _dragging;

    public PinboardDraggableContainer()
    {
        MouseFilter = MouseFilterMode.Stop;
    }

    protected override void KeyBindDown(GUIBoundKeyEventArgs args)
    {
        base.KeyBindDown(args);

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

        if (!_dragging)
            return;

        var loc = GetValue(PinboardContainer.PinLocation);

        loc += args.Relative;

        SetValue(PinboardContainer.PinLocation, loc);
        Parent?.InvalidateArrange();
    }

}
