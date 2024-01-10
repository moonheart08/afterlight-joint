using Content.Client._AL.UI.Interfaces;
using Content.Client._AL.UI.Widgets;

namespace Content.Client._AL.UI.Windows.OptionsMenu;

public sealed class OptionsMenuWindow : Window, IApplyableDialog
{
    public bool Modified { get; private set; }

    public void Apply()
    {
        throw new NotImplementedException();
    }
}
