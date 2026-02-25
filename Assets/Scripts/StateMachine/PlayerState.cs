using UnityEngine;

public abstract class PlayerState 
{
   public abstract void EnterState(PlayerStateManager playerManager, PlayerInfo playerInfo);

   public abstract void UpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo);

   public abstract void OnCollisionEnter(PlayerStateManager playerManager, PlayerInfo playerInfo, Collision collision);

}
