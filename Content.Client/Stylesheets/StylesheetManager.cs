using Content.AL.UIKit;
using Content.Client._AL.UI;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface;
using Robust.Shared.Configuration;
using Robust.Shared.Console;
using Robust.Shared.IoC;
using Robust.Shared.Toolshed;

namespace Content.Client.Stylesheets
{
    public sealed class StylesheetManager : IStylesheetManager
    {
        [Dependency] private readonly IConfigurationManager _cfg = default!;
        [Dependency] private readonly IUserInterfaceManager _userInterfaceManager = default!;
        [Dependency] private readonly IResourceCache _resourceCache = default!;

        public Stylesheet SheetNano { get; private set; } = default!;
        public Stylesheet SheetSpace { get; private set; } = default!;

        public void Initialize()
        {

            SheetNano = new StyleNano(_resourceCache).Stylesheet;
            SheetSpace = new StyleSpace(_resourceCache).Stylesheet;
            /*
            _userInterfaceManager.Stylesheet = SheetNano;
            */ // AL EDIT: FUCK THIS LOL!

            _cfg.OnValueChanged(UICVars.UseDepth, _ => UpdateSheet());
            _cfg.OnValueChanged(UICVars.HighContrastText, _ => UpdateSheet());
            _cfg.OnValueChanged(UICVars.HighContrastExtrude, _ => UpdateSheet());
            UpdateSheet();
        }

        public void UpdateSheet()
        {
            _userInterfaceManager.Stylesheet = GetCurrentSheet(ALStyleConfig.FromCVars()).Stylesheet;
        }

        public BaseStyle GetCurrentSheet(ALStyleConfig cfg)
        {
            return new ALStyle(_resourceCache, cfg);
        }
    }

    public sealed class ALUIReloadCommand : LocalizedCommands
    {
        public override string Command => "alui_reload";

        public override void Execute(IConsoleShell shell, string argStr, string[] args)
        {
            IoCManager.Resolve<StylesheetManager>().UpdateSheet();
        }
    }
}
