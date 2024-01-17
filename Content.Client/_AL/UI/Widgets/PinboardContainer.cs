using System.Numerics;
using Robust.Client.Animations;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Animations;
using Robust.Shared.Input;

namespace Content.Client._AL.UI.Widgets;

public sealed class PinboardContainer : Container
{
    public static readonly AttachedProperty<Vector2> PinLocation = AttachedProperty<Vector2>.Create("PinLocation", typeof(PinboardContainer), defaultValue: Vector2.Zero);

    // XAMLIL magic, these are used to recognize attachedprops from XAML. It will ICE if you remove one without the other, as well. :)
    public static Vector2 GetPinLocation(Control c)
        => c.GetValue(PinLocation);
    public static void SetPinLocation(Control c, Vector2 loc)
        => c.SetValue(PinLocation, loc);

    public Vector2 ScrollLocation = Vector2.Zero;
    [ViewVariables(VVAccess.ReadWrite)]
    [Animatable]
    public float Zoom { get; set; }= 1.0f;
    public Vector2 ChildAvailableSpace { get; set; } = new(1024, 1024);

    private Animation Zoomies = new Animation()
    {
        AnimationTracks =
        {
            new AnimationTrackControlProperty()
            {
                InterpolationMode = AnimationInterpolationMode.Cubic,
                KeyFrames =
                {
                    new AnimationTrackProperty.KeyFrame(0.2f, 0.0f),
                    new AnimationTrackProperty.KeyFrame(2.0f, 3.0f),
                },
                Property = nameof(PinboardContainer.Zoom)
            }
        }
    };

    public bool DoCursorScroll = true;

    private bool _dragging = false;

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

        if (!_dragging || !DoCursorScroll)
            return;

        ScrollLocation += args.Relative;
        InvalidateArrange();
    }

    public PinboardContainer()
    {
        RectClipContent = true;
        MouseFilter = MouseFilterMode.Stop;
        //PlayAnimation(Zoomies, "glonk");
    }



    protected override Vector2 MeasureOverride(Vector2 availableSize)
    {
        foreach (var c in Children)
        {
            c.Measure(ChildAvailableSpace);
        }

        return MinSize;
    }

    protected override Vector2 ArrangeOverride(Vector2 finalSize)
    {
        foreach (var c in Children)
        {
            var desired = c.DesiredSize;
            var pos = c.GetValue(PinLocation);
            c.Arrange(UIBox2.FromDimensions(pos + ScrollLocation, desired));
        }

        return finalSize;
    }

    protected override void RenderChildOverride(IRenderHandle renderHandle, ref int total, Control control, Vector2i position, Color modulate,
        UIBox2i? scissorBox, Matrix3 coordinateTransform)
    {
        var screen = renderHandle.DrawingHandleScreen;
        var oldXform = screen.GetTransform();
        var xform = oldXform;
        var scale = Matrix3.CreateScale(Zoom, Zoom);
        xform.Multiply(scale);
        var posOffs = GlobalPixelPosition + (PixelSize / 2);
        var relPos = position - posOffs;
        position = (Vector2i)scale.Transform(relPos) + posOffs;
        screen.SetTransform(xform);
        var ccxform = coordinateTransform;
        ccxform.Multiply(scale);
        base.RenderChildOverride(renderHandle, ref total, control, position, modulate, scissorBox, ccxform);
        screen.SetTransform(oldXform);
    }
}
