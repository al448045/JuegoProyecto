using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyMeleeState : EnemyState
{
    private CustomTimer actionTimer = new CustomTimer();

    public override void EnterState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        Debug.Log("Entrando al estado de " + enemyStateManager.currentState);
        enemyStateManager.currentEnemy.SetAnimatorBool("IsAction", true);
        enemyStateManager.currentEnemy.actionTimer.timerAmount = enemyStateManager.currentEnemy.actionTime;
    }

    public override void ExitState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.SetAnimatorBool("IsAction", false);
        enemyStateManager.currentEnemy.isActionFinished = true;
    }

    public override void UpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {

        enemyStateManager.currentEnemy.actionTimer.UpdateTimer();

        if (enemyStateManager.currentEnemy.actionTimer.timerAmount <= 0f)
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
