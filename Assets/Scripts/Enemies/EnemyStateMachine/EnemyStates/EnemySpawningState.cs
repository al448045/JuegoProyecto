using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawningState : EnemyState
{
    public override void EnterState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.StartCoroutine(enemyStateManager.currentEnemy.GoDown());
    }

    public override void ExitState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {

    }

    public override void UpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.spawningTimer.UpdateTimer();

        if (enemyStateManager.currentEnemy.spawningTimer.timerAmount <= 0f)
        {
            enemyStateManager.SwitchState(enemyStateManager.enemyIdleState);
        }
    }

    public override void FixedUpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {

    }
       

    public override void OnCollisionEnter2D(EnemyStateManager enemyStateManager, BaseEnemy Enemy, Collision2D collision)
    {

    }

    public override void OnTriggerEnter2D(EnemyStateManager enemyStateManager, BaseEnemy Enemy, Collider2D collider)
    {

    }
}
