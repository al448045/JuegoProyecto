using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyChangeholeState : EnemyState
{
    public override void EnterState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.hasChangedHole = false;
        enemyStateManager.currentEnemy.nextHole = enemyStateManager.currentEnemy.FindNextHole();
    }

    public override void ExitState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {

    }

    public override void UpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        if (enemyStateManager.currentEnemy.hasChangedHole)
        {
            enemyStateManager.SwitchState(enemyStateManager.enemyIdleState);
        }

        else
        {
            GameManager.Instance.holeManager.Change2HoleStates(enemyStateManager.currentEnemy.currentHole, false, enemyStateManager.currentEnemy.nextHole, true);
            enemyStateManager.currentEnemy.ChangePosition(enemyStateManager.currentEnemy.nextHole);
            enemyStateManager.currentEnemy.currentHole = enemyStateManager.currentEnemy.nextHole;
            enemyStateManager.currentEnemy.nextHole = null;
        }
    }

    public override void FixedUpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.UpdateAnimatorFacingVector();
    }

    public override void OnCollisionEnter2D(EnemyStateManager enemyStateManager, BaseEnemy Enemy, Collision2D collision)
    {

    }

    public override void OnTriggerEnter2D(EnemyStateManager enemyStateManager, BaseEnemy Enemy, Collider2D collider)
    {

    }
}
