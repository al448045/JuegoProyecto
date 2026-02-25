using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public float moveSpeed;
    private Vector2 _moveDirection;
    private float MoveTimer = 3.0f;

    public override void EnterState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        Debug.Log("Estado de Move");
    }

    public override void UpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        if (playerInfo.IsSpacePressed == true)
        {
            playerInfo.IsSpacePressed = false;
            playerManager.SwitchState(playerManager.AttackState);
        }

        MoveTimer -= Time.deltaTime;

        if (MoveTimer <= 0.0)
        {
            playerManager.SwitchState(playerManager.AttackState);
        }
    }

    public override void OnCollisionEnter(PlayerStateManager playerManager, PlayerInfo playerInfo, Collision collision)
    {

    }
}
