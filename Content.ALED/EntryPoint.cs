using Content.ALED.Screen;
using Robust.Client;
using Robust.Client.State;
using Robust.Shared;
using Robust.Shared.Configuration;
using Robust.Shared.ContentPack;
using Robust.Shared.IoC;

namespace Content.ALED;

public sealed class EntryPoint : GameClient
{
    [Dependency] private readonly IStateManager _state = default!;
    [Dependency] private readonly IBaseClient _client = default!;
    [Dependency] private readonly IConfigurationManager _cfg = default!;

    public override void Init()
    {
        IoCManager.InjectDependencies(this);
        _cfg.SetCVar(CVars.ResTexturePreloadingEnabled, false);
    }

    public override void PostInit()
    {
        _state.RequestStateChange<EditorScene>();
        _client.StartSinglePlayer();
    }
}
