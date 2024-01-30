﻿using System.Numerics;
using Content.Client._AL.UI.Interfaces;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client._AL.UI.Widgets;

[Virtual]
[GenerateTypedNameReferences]
public partial class Window : BaseWindow, IDepthMeasure<BorderedPanel>
{
    private const int DRAG_MARGIN_SIZE = 7;

    public static string GetWindowIconStyle(Type t)
    {
        return $"WindowIcon{t.Name}";
    }

    public Window()
    {
        RobustXamlLoader.Load(this);
        XamlChildren = ContentsContainer.Children;
        CloseButton.OnPressed += CloseButtonPressed;
        if (GetType() != typeof(Window)) // We're a subclass.
        {
            WindowIcon.AddStyleClass(GetWindowIconStyle(GetType()));
        }
    }

    public string? Title
    {
        get => WindowTitle.Text;
        set => WindowTitle.Text = value;
    }

    private void CloseButtonPressed(BaseButton.ButtonEventArgs args)
    {
        Close();
    }

    protected override DragMode GetDragModeFor(Vector2 relativeMousePos)
    {
        var mode = DragMode.Move;

        if (Resizable)
        {
            if (relativeMousePos.Y < DRAG_MARGIN_SIZE)
            {
                mode = DragMode.Top;
            }
            else if (relativeMousePos.Y > Size.Y - DRAG_MARGIN_SIZE)
            {
                mode = DragMode.Bottom;
            }

            if (relativeMousePos.X < DRAG_MARGIN_SIZE)
            {
                mode |= DragMode.Left;
            }
            else if (relativeMousePos.X > Size.X - DRAG_MARGIN_SIZE)
            {
                mode |= DragMode.Right;
            }
        }

        return mode;
    }

    public void OnDepthUpdate(int n)
    {
    }
}
