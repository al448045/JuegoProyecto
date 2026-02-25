using UnityEngine;

public class PlayerAttackState : PlayerState
{
    private float AttackTimer = 3.0f;

    public override void EnterState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        Debug.Log("Estado de Attack");
    }

    public override void UpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        if (playerInfo.IsSpacePressed == true)
        {
            playerInfo.IsSpacePressed = false;
            playerManager.SwitchState(playerManager.IdleState);
        }

        AttackTimer -= Time.deltaTime;

        if (AttackTimer <= 0.0)
        {
            playerManager.SwitchState(playerManager.IdleState);
        }

    }

    public override void OnCollisionEnter(PlayerStateManager playerManager, PlayerInfo playerInfo, Collision collision)
    {

    }


}
