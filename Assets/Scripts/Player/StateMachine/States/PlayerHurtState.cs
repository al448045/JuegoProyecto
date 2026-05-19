using UnityEngine;
using System.Collections;

public class PlayerHurtState: PlayerState
{
    public override void EnterState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        if (playerManager.playerController.player_was_killed)
        {
            playerManager.SwitchState(playerManager.DeathState);
        }

        playerManager.playerController.playerCollider.enabled = false;
        playerManager.playerController.StartCoroutine(playerManager.playerController.PlayerWasHurt());

    }

    public override void ExitState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        playerManager.playerController.player_was_hurt = false;
        playerManager.playerController.playerRB2D.linearVelocity = Vector2.zero;
        playerManager.playerController.playerCollider.enabled = true;
        playerManager.playerController.StopAllCoroutines();
    }

    public override void UpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        
        if (playerManager.playerController.player_stopped_hurting)
        {
            playerManager.SwitchState(playerManager.IdleState);
        }

        if (playerManager.playerController.player_was_killed)
        {
            playerManager.SwitchState(playerManager.DeathState);
        }
    }

    public override void FixedUpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        playerManager.playerController.DeceleratePlayer();
    }

    public override void OnTriggerEnter2D(PlayerStateManager playerManager, PlayerInfo playerInfo, Collider2D collider) { }

    public override void OnCollisionEnter2D(PlayerStateManager playerManager, PlayerInfo playerInfo, Collision2D collision) { }

}
