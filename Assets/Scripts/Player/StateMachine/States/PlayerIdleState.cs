using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerState
{
    public override void EnterState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        playerManager.playerController.playerSpriteRenderer.color = Color.green;
    }

    public override void ExitState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {

    }

    public override void UpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        if (playerManager.playerController.player_wants_move)
        {
            playerManager.SwitchState(playerManager.MoveState);
        }

        if (playerManager.playerController.player_wants_attack)
        {
            playerManager.SwitchState(playerManager.AttackState);
        }

        if (playerManager.playerController.player_wants_object)
        {
            playerManager.SwitchState(playerManager.ObjectState);
        }
    }

    public override void FixedUpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {

    }

    public override void OnTriggerEnter2D(PlayerStateManager playerManager, PlayerInfo playerInfo, Collider2D collider)
    {

    }

    public override void OnCollisionEnter2D(PlayerStateManager playerManager, PlayerInfo playerInfo, Collision2D collision)
    {

    }
}
