using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyChangeholeState : EnemyState
{
    public override void EnterState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        Debug.Log("Entrando al estado de " + enemyStateManager.currentState);
        enemyStateManager.currentEnemy.isActionFinished = false;
        enemyStateManager.currentEnemy.changingTimer.timerAmount = enemyStateManager.currentEnemy.changingTime;

        enemyStateManager.currentEnemy.ChangePosition(enemyStateManager.currentEnemy.FindNextHole());
    }

    public override void ExitState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {

    }

    public override void UpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.changingTimer.UpdateTimer();

        if (enemyStateManager.currentEnemy.changingTimer.timerAmount <= 0)
        {
            enemyStateManager.SwitchState(enemyStateManager.enemyIdleState);
        }
    }

    public override void FixedUpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.facingDirection = (enemyStateManager.currentEnemy.gameManager.player.transform.position - enemyStateManager.currentEnemy.transform.position).normalized;
        enemyStateManager.currentEnemy.UpdateAnimatorFacingVector();
    }

    public override void OnCollisionEnter2D(EnemyStateManager enemyStateManager, BaseEnemy Enemy, Collision2D collision)
    {

    }

    public override void OnTriggerEnter2D(EnemyStateManager enemyStateManager, BaseEnemy Enemy, Collider2D collider)
    {

    }
}
