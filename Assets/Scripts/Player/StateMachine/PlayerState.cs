using UnityEngine;

public abstract class PlayerState 
{
    public abstract void EnterState(PlayerStateManager playerManager, PlayerInfo playerInfo);

    public abstract void ExitState(PlayerStateManager playerManager, PlayerInfo playerInfo);

    public abstract void UpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo);

    public abstract void FixedUpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo);

    public abstract void OnCollisionEnter2D(PlayerStateManager playerManager, PlayerInfo playerInfo, Collision2D collision);

    public abstract void OnTriggerEnter2D(PlayerStateManager playerManager, PlayerInfo playerInfo, Collider2D collider);
}
