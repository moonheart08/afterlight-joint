// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Linq;
using Content.Client._AL.UI.Interfaces;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.Client._AL.UI.Widgets;

[Virtual]
public abstract class Stack : BoxContainer
{
    public Stack()
    {
        Margin = new Thickness(4);
    }

    protected override void ChildAdded(Control newChild)
    {
        base.ChildAdded(newChild);
        if (Children.Count() == 1 && InnerLayoutRatioNum is {} num)
        {
            newChild.SizeFlagsStretchRatio = num;
        }

        if (ExpandInner)
        {
            if (Orientation == LayoutOrientation.Horizontal)
            {
                newChild.HorizontalExpand = true;
            }
            else
            {
                newChild.VerticalExpand = true;
            }
        }
    }

    public string? InnerLayoutRatio { get; set; } = null;
    public bool ExpandInner { get; set; } = false;

    protected float? InnerLayoutRatioNum
    {
        get
        {
            if (InnerLayoutRatio is null)
                return null;

            var split = InnerLayoutRatio.Split(':');
            if (split.Length != 2 || !float.TryParse(split[0], out var left) || !float.TryParse(split[1], out var right))
            {
                throw new Exception(
                    $"Couldn't parse layout ratio {InnerLayoutRatio}, a ratio is of the format X:Y, i.e. 1:2 or 16:9");
            }

            return left / right;
        }
    }
}

[Virtual]
public class VStack : Stack
{
    public VStack()
    {
        Orientation = LayoutOrientation.Vertical;
        HorizontalExpand = false;
        VerticalExpand = false;
    }
}

[Virtual]
public class VGrowStack : VStack
{
    public VGrowStack()
    {
        VerticalExpand = true;
    }
}

[Virtual]
public class VFill : VGrowStack
{
}

[Virtual]
public class HStack : Stack
{
    public HStack()
    {
        Orientation = LayoutOrientation.Horizontal;
        HorizontalExpand = false;
        VerticalExpand = false;
    }
}

[Virtual]
public class HGrowStack : HStack
{
    public HGrowStack()
    {
        HorizontalExpand = true;
    }
}

[Virtual]
public class HFill : HGrowStack
{
}
