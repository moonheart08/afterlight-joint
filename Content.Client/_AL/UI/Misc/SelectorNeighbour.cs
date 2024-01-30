// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Robust.Client.UserInterface;
using Robust.Shared.Utility;

namespace Content.Client._AL.UI.Misc;

public sealed class SelectorNeighbour : Selector
{
    public Selector Self { get;  }
    public Selector Other { get; }

    public int MaxDistance { get; }

    public NeighbourDirection Direction { get; }

    public SelectorNeighbour(Selector self, Selector other, int maxDistance, NeighbourDirection direction)
    {
        DebugTools.Assert(maxDistance > 0);
        Self = self;
        MaxDistance = maxDistance;
        Other = other;
        Direction = direction;
    }

    public override bool Matches(Control control)
    {
        var parent = control.Parent;
        var selfPos = control.GetPositionInParent();

        if (!Self.Matches(control))
            return false;

        if (parent is null)
            return false;
        var childrenAbove = parent.ChildCount - control.GetPositionInParent();
        var childrenBelow = control.GetPositionInParent() - 1;

        switch (Direction)
        {
            case NeighbourDirection.Either:
            case NeighbourDirection.Above:
                var upCheckDist = Math.Min(MaxDistance, childrenAbove);

                // Walk up relative to self.
                for (var i = upCheckDist; i > 0; i--)
                {
                    if (Other.Matches(parent.GetChild(selfPos + i)))
                    {
                        return true;
                    }
                }

                if (Direction is NeighbourDirection.Either)
                    goto case NeighbourDirection.Below;

                break;
            case NeighbourDirection.Below:
                var downCheckDist = Math.Min(MaxDistance, childrenBelow);

                // Walk up relative to self.
                for (var i = downCheckDist; i > 0; i--)
                {
                    if (Other.Matches(parent.GetChild(selfPos - i)))
                    {
                        return true;
                    }
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return false;
    }

    public override StyleSpecificity CalculateSpecificity()
    {
        return Other.CalculateSpecificity();
    }

    public enum NeighbourDirection
    {
        Above,
        Below,
        Either,
    }
}

public sealed class MutableSelectorNeighbour : MutableSelector
{
    public MutableSelector Self { get;  }
    public MutableSelector Other { get; }
    public int MaxDistance { get; }

    public SelectorNeighbour.NeighbourDirection Direction { get; }

    public MutableSelectorNeighbour(MutableSelector self, MutableSelector other, int maxDistance, SelectorNeighbour.NeighbourDirection direction)
    {
        DebugTools.Assert(maxDistance > 0);
        MaxDistance = maxDistance;
        Self = self;
        Other = other;
        Direction = direction;
    }

    protected override Selector ToSelector()
    {
        return new SelectorNeighbour(Self, Other, MaxDistance, Direction);
    }
}
