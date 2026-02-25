using UnityEngine;

public class PlayerIdleState : PlayerState
{

    private float IdleTimer = 3f;

    public override void EnterState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        Debug.Log("Estado de Idle");
    }

    public override void UpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        if (playerInfo.IsSpacePressed == true)
        {
            playerInfo.IsSpacePressed = false;
            playerManager.SwitchState(playerManager.MoveState);
        }

        IdleTimer -= Time.deltaTime;

        if (IdleTimer <= 0.0)
        {
            playerManager.SwitchState(playerManager.MoveState);
        }
    }

    public override void OnCollisionEnter(PlayerStateManager playerManager, PlayerInfo playerInfo, Collision collision)
    {

    }
}
