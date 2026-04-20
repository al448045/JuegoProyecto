using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawningState : EnemyState
{
    private CustomTimer spawningTimer = new CustomTimer();
    public override void EnterState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.enemyCapsuleCollider.enabled = false;
        spawningTimer.timerAmount = 1f;
    }

    public override void ExitState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.enemyCapsuleCollider.enabled = true;
    }

    public override void UpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {

        spawningTimer.UpdateTimer();
        if (spawningTimer.timerAmount <= 0f)
        {
            enemyStateManager.SwitchState(enemyStateManager.enemyGoUpAndDownState);

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
