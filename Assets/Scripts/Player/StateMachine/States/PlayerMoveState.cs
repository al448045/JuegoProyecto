using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveState : PlayerState
{
    public override void EnterState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        playerInfo.playerController.playerSpriteRenderer.color = Color.blue;
    }

    public override void ExitState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {

    }

    public override void UpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {

        if (playerInfo.playerMoveDirection.sqrMagnitude <= 0.01)
        {
            playerManager.SwitchState(playerManager.IdleState);
        }

        if (playerManager.playerController.player_wants_attack)
        {
            playerManager.SwitchState(playerManager.AttackState);
        }

        if (playerManager.playerController.player_was_hurt)
        {
            playerManager.SwitchState(playerManager.HurtState);
        }

        if (playerManager.playerController.player_wants_object)
        {
            playerManager.SwitchState(playerManager.ObjectState);
        }
    }

    public override void FixedUpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        playerInfo.playerMoveDirection = playerManager.playerController.inputManager.moveAction.ReadValue<Vector2>();
        playerManager.playerController.playerRB2D.linearVelocity = (playerInfo.playerMoveDirection.normalized * playerInfo.playerSpeed);
    }

    public override void OnTriggerEnter2D(PlayerStateManager playerManager, PlayerInfo playerInfo, Collider2D collider)
    {

    }

    public override void OnCollisionEnter2D(PlayerStateManager playerManager, PlayerInfo playerInfo, Collision2D collision)
    {

    }
}
