using Robust.Shared.Enums;
using Robust.Shared.Network;
using Robust.Shared.Player;

namespace Content.Shared._AnchorLane;

public abstract class AnchorLaneSystem : EntitySystem
{
    [Dependency] protected readonly INetManager NetManager = default!;
    [Dependency] protected readonly ISharedPlayerManager PlayerManager = default!;

    private bool _registeredStatusHandler = false;

    protected void RegisterPlayerStatusHandler()
    {
        if (NetManager.IsClient)
            return;

        _registeredStatusHandler = true;
        PlayerManager.PlayerStatusChanged += OnPlayerManagerOnPlayerStatusChanged;
    }

    private void OnPlayerManagerOnPlayerStatusChanged(object? _, SessionStatusEventArgs args)
    {
        if (args is {NewStatus: SessionStatus.Connected, OldStatus: SessionStatus.Connecting})
        {
            OnClientConnected(args.Session);
        }
    }

    public override void Shutdown()
    {
        if (_registeredStatusHandler && NetManager.IsServer)
        {
            PlayerManager.PlayerStatusChanged -= OnPlayerManagerOnPlayerStatusChanged;
        }
    }

    /// <summary>
    ///     Fires upon a client joining the server.
    /// </summary>
    public virtual void OnClientConnected(ICommonSession session)
    {
    }
}
