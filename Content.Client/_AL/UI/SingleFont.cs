// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace Content.Client._AL.UI;

public sealed class SingleFont : FontStack
{
    public override string FontPrimary => throw new NotImplementedException();

    public override string FontSymbols => throw new NotImplementedException();

    public override string FontFallback => throw new NotImplementedException();

    public override string[] Extra => throw new NotImplementedException();

    public string SingularFont;

    public SingleFont(string singularFont)
    {
        SingularFont = singularFont;
    }

    protected override string[] GetFontPaths(FontKind kind)
    {
        return new[] {SingularFont, FontFallback};
    }
}
