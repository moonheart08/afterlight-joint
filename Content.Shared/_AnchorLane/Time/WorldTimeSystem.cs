using Robust.Shared.Player;
using Robust.Shared.Serialization;
using Robust.Shared.Timing;

namespace Content.Shared._AnchorLane.Time;

/// <summary>
/// This handles the in-game time, clock, and calender.
///
/// </summary>
public sealed class WorldTimeSystem : AnchorLaneSystem
{
    private DateTime _serverStart;

    [Dependency] private readonly IGameTiming _timing = default!;

    /// <inheritdoc/>
    public override void Initialize()
    {
        RegisterPlayerStatusHandler();
        if (NetManager.IsClient)
        {
            SubscribeNetworkEvent<ServerWorldTimeStartSync>(OnWorldTimeSync);
        }
        else
        {
            _serverStart = DateTime.UtcNow;
        }
    }

    public WorldTime Now()
    {
        return WorldTime.FromDateTime(_serverStart.Add(_timing.CurTime));
    }

    private void OnWorldTimeSync(ServerWorldTimeStartSync ev)
    {
        _serverStart = ev.ServerDate;
    }

    public override void OnClientConnected(ICommonSession session)
    {
        RaiseNetworkEvent(new ServerWorldTimeStartSync(_serverStart), session);
    }
}

[Serializable, NetSerializable]
public sealed class ServerWorldTimeStartSync(DateTime serverDate) : EntityEventArgs
{
    public DateTime ServerDate { get; } = serverDate;
}
