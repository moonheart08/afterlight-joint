// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Robust.Shared.Configuration;

namespace Content.Client._AL.UI;

[CVarDefs]
public static class UICVars
{
    public static readonly CVarDef<bool> UseDepth = CVarDef.Create("afterlight.ui.use_depth", true, CVar.CLIENTONLY | CVar.ARCHIVE);
    public static readonly CVarDef<bool> HighContrastText = CVarDef.Create("afterlight.ui.high_contrast_text", false, CVar.CLIENTONLY | CVar.ARCHIVE);
    public static readonly CVarDef<bool> HighContrastExtrude = CVarDef.Create("afterlight.ui.high_contrast_extrude", false, CVar.CLIENTONLY | CVar.ARCHIVE);
}
