using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.Administration.UI.Bwoink
{
    /// <summary>
    /// This window connects to a BwoinkSystem channel. BwoinkSystem manages the rest.
    /// </summary>
    [GenerateTypedNameReferences]
    public sealed partial class BwoinkWindow : Content.AL.UIKit.Widgets.Window
    {
        public BwoinkWindow()
        {
            RobustXamlLoader.Load(this);

            Bwoink.ChannelSelector.OnSelectionChanged += sel =>
            {
                if (sel is not null)
                {
                    Title = $"{sel.CharacterName} / {sel.Username}";

                    if (sel.OverallPlaytime != null)
                    {
                        Title += $" | {Loc.GetString("generic-playtime-title")}: {sel.PlaytimeString}";
                    }
                }
            };

            OnOpen += () => Bwoink.PopulateList();
        }
    }
}
