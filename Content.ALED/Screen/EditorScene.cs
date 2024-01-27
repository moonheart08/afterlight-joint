using System;
using Robust.Client.State;

namespace Content.ALED.Screen;

public sealed class EditorScene : State
{
    protected override Type? LinkedScreenType => typeof(EditorScreen);

    protected override void Startup()
    {
    }

    protected override void Shutdown()
    {
    }
}
