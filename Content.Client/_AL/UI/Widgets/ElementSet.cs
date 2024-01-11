﻿using System.Linq;
using Content.Client._AL.UI.Interfaces;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets;

public sealed class ElementSet : Container
{
    public static readonly AttachedProperty<BaseButton> ElementVisibilityButton = AttachedProperty<BaseButton>.CreateNull("ElementVisibilityButton", typeof(ElementSet));
    public static readonly AttachedProperty<Control> ElementControlsVisibility = AttachedProperty<Control>.CreateNull("ElementControlsVisibility", typeof(ElementSet));

    public Control CurrentElement { get; private set; } = default!;
    public string? ControlledByGroup { get; set; } = null;

    private readonly List<Control> _elements  = new();
    public IReadOnlyList<Control> Elements => _elements;


    public ElementSet()
    {
        MouseFilter = MouseFilterMode.Pass;
    }

    protected override void EnteredTree()
    {
        base.EnteredTree();
        if (ControlledByGroup is { } group)
        {
            if (FindControl<Control>(group) is IGroupOrganizer organizer)
            {
                AddGroupControl(organizer.GetGroup());
            }
            else
            {
                throw new Exception(
                    $"A ControlledByGroup ({ControlledByGroup} in this case) must implement IGroupOrganizer!");
            }

            ControlledByGroup = null;
        }
    }

    protected override void ChildAdded(Control newChild)
    {
        base.ChildAdded(newChild);
        _elements.Add(newChild);
        if (_elements.Count == 1)
            CurrentElement = newChild;
        else
            newChild.Visible = false;
    }

    private void SetActiveChild(int child)
    {
        CurrentElement.Visible = false;
        var c = GetChild(child);
        c.Visible = true;
        CurrentElement = c;
    }

    public void AddGroupControl(ButtonGroup group)
    {
        if (group.Buttons.Count != Children.Count())
        {
            throw new Exception("Must have enough elements in a set to match the button group!");
        }

        var i = 0;
        foreach (var button in group.Buttons)
        {
            button.SetValue(ElementControlsVisibility, GetChild(i));
            GetChild(i).SetValue(ElementVisibilityButton, button);


            var i1 = i;
            button.OnPressed += _ =>
            {
                SetActiveChild(i1);
            };
            i++;
        }
    }
}
