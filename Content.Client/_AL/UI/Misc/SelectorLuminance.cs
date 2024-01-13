using Content.Client._AL.UI.Interfaces;
using Robust.Client.UserInterface;

namespace Content.Client._AL.UI.Misc;

public sealed class SelectorLuminance : Selector
{
    public Selector Modified { get; }

    public float Luminance { get; }
    public SelectorMode Mode { get; }

    public SelectorLuminance(Selector modified, float luminance, SelectorMode mode)
    {
        Modified = modified;
        Luminance = luminance;
        Mode = mode;
    }

    public override bool Matches(Control control)
    {
        var luminosity = 0.0f;
        {
            var parent = control;
            while (parent is not null)
            {
                parent = parent.Parent;
                if (parent is IBrightnessAware b)
                {
                    luminosity = b.Luminance();
                    break;
                }
            }
        }

        return Modified.Matches(control) && Evaluate(luminosity);
    }

    private bool Evaluate(float lum)
    {
        if (Mode == SelectorMode.GreaterThan)
        {
            return Luminance <= lum;
        }
        else if (Mode == SelectorMode.LessThan)
        {
            return Luminance >= lum;
        }

        return false;
    }


    public override StyleSpecificity CalculateSpecificity()
    {
        return Modified.CalculateSpecificity(); // We're an operator, not any more specific.
    }

    public enum SelectorMode
    {
        LessThan,
        GreaterThan
    }
}

public sealed class MutableSelectorLuminance : MutableSelector
{
    public MutableSelector Modified { get; }

    public float Luminance { get; }
    public SelectorLuminance.SelectorMode Mode { get; }


    public MutableSelectorLuminance(MutableSelector modified, float luminance, SelectorLuminance.SelectorMode mode)
    {
        Modified = modified;
        Luminance = luminance;
        Mode = mode;
    }

    protected override Selector ToSelector()
    {
        return new SelectorLuminance(Modified, Luminance, Mode);
    }
}
