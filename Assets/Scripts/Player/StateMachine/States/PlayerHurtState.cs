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

        playerInfo.playerController.playerSpriteRenderer.color = Color.red;
    }

    public override void ExitState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        playerManager.playerController.player_was_hurt = false;
        playerManager.playerController.playerRB2D.linearVelocity = Vector2.zero;
    }

    public override void UpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        
        if (!(playerManager.playerController.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hurt_Rotate")))
        {
            playerManager.SwitchState(playerManager.IdleState);
        }
    }

    public override void FixedUpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        playerManager.playerController.DeceleratePlayer();
    }

    public override void OnTriggerEnter2D(PlayerStateManager playerManager, PlayerInfo playerInfo, Collider2D collider) { }

    public override void OnCollisionEnter2D(PlayerStateManager playerManager, PlayerInfo playerInfo, Collision2D collision) { }

}
