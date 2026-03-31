using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    public PlayerState currentState;

    public PlayerMoveState MoveState        = new PlayerMoveState();
    public PlayerIdleState IdleState        = new PlayerIdleState();
    public PlayerAttackState AttackState    = new PlayerAttackState();
    public PlayerHurtState HurtState        = new PlayerHurtState();
    public PlayerDeathState DeathState      = new PlayerDeathState();
    public PlayerObjectState ObjectState    = new PlayerObjectState();

    [SerializeField] public PlayerController playerController;


    private void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this, playerController.playerInfo);
    }

    public void SwitchState(PlayerState newState)
    {
        currentState.ExitState(this, playerController.playerInfo);
        currentState = newState;
        currentState.EnterState(this, playerController.playerInfo);
    }

    private void Update()
    {
        currentState.UpdateState(this, playerController.playerInfo);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this, playerController.playerInfo);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(this, playerController.playerInfo,collision);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        currentState.OnTriggerEnter2D(this, playerController.playerInfo, collider);
    }
}
