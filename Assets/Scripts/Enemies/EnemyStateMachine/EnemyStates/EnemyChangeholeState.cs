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

        enemyStateManager.currentEnemy.spriteRenderer.color = Color.red;

        enemyStateManager.currentEnemy.nextHole = enemyStateManager.currentEnemy.FindNextHole();
        enemyStateManager.currentEnemy.gameManager.ChangeHoleState(enemyStateManager.currentEnemy.currentHole, enemyStateManager.currentEnemy.nextHole);
    }

    public override void ExitState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {

    }

    public override void UpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {

        if (enemyStateManager.currentEnemy.transform.position != enemyStateManager.currentEnemy.currentHole.transform.position && enemyStateManager.currentEnemy.nextHole != null)
        {
            enemyStateManager.currentEnemy.ChangePosition(enemyStateManager.currentEnemy.nextHole.transform.position);
            enemyStateManager.currentEnemy.currentHole = enemyStateManager.currentEnemy.nextHole;
            enemyStateManager.currentEnemy.gameManager.ChangeHoleState(enemyStateManager.currentEnemy.currentHole, enemyStateManager.currentEnemy.nextHole);
            enemyStateManager.currentEnemy.nextHole = null;
        }

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
