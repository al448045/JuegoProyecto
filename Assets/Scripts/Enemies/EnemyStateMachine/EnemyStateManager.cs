using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyStateManager : MonoBehaviour
{
    public EnemyState currentState;

    public EnemyIdleState enemyIdleState                = new EnemyIdleState();
    public EnemyMeleeState enemyMeleeState              = new EnemyMeleeState();
    public EnemyChangeholeState enemyChangeholeState    = new EnemyChangeholeState();

    [SerializeField] public BaseEnemy currentEnemy;

    private void Start()
    {
        currentState = enemyIdleState;
        currentState.EnterState(this, currentEnemy);
    }

    public void SwitchState(EnemyState newState)
    {
        currentState.ExitState(this, currentEnemy);
        currentState = newState;
        currentState.EnterState(this, currentEnemy);
    }

    private void Update()
    {
        currentState.UpdateState(this, currentEnemy);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this, currentEnemy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(this, currentEnemy, collision);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        currentState.OnTriggerEnter2D(this, currentEnemy, collider);
    }
}
