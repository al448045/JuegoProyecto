using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackState : PlayerState
{
    public override void EnterState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        playerManager.playerController.playerSpriteRenderer.color = Color.purple;
    }

    public override void ExitState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        playerManager.playerController.playerRB2D.linearVelocity = Vector2.zero;
    }

    public override void UpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        if (!(playerManager.playerController.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack")))
        {
            playerManager.SwitchState(playerManager.IdleState);
        }
    }

    public override void FixedUpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        playerManager.playerController.DeceleratePlayer();
    }

    public override void OnTriggerEnter2D(PlayerStateManager playerManager, PlayerInfo playerInfo, Collider2D collider)
    {

    }

    public override void OnCollisionEnter2D(PlayerStateManager playerManager, PlayerInfo playerInfo, Collision2D collision)
    {

    }
}
