using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public abstract class EnemyState
{
    public abstract void EnterState(EnemyStateManager enemyStateManager, BaseEnemy Enemy);

    public abstract void ExitState(EnemyStateManager enemyStateManager, BaseEnemy Enemy);

    public abstract void UpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy);

    public abstract void FixedUpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy);

    public abstract void OnCollisionEnter2D(EnemyStateManager enemyStateManager, BaseEnemy Enemy, Collision2D collision);

    public abstract void OnTriggerEnter2D(EnemyStateManager enemyStateManager, BaseEnemy Enemy, Collider2D collider);
}
