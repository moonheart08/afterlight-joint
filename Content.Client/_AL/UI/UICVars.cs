using Robust.Shared.Configuration;

namespace Content.Client._AL.UI;

[CVarDefs]
public static class UICVars
{
    public static readonly CVarDef<bool> UseDepth = CVarDef.Create("afterlight.ui.use_depth", true, CVar.CLIENTONLY | CVar.ARCHIVE);
    public static readonly CVarDef<bool> HighContrastText = CVarDef.Create("afterlight.ui.high_contrast_text", false, CVar.CLIENTONLY | CVar.ARCHIVE);
    public static readonly CVarDef<bool> HighContrastExtrude = CVarDef.Create("afterlight.ui.high_contrast_extrude", false, CVar.CLIENTONLY | CVar.ARCHIVE);
}
