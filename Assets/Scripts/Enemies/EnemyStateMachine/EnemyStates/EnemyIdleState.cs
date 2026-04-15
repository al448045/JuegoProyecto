using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyIdleState : EnemyState
{

    public override void EnterState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {

    }

    public override void ExitState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {

    }

    public override void UpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        if (enemyStateManager.currentEnemy.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (enemyStateManager.currentEnemy.isActionFinished)
            {
                enemyStateManager.SwitchState(enemyStateManager.enemyChangeholeState);
            }

            else
            {
                enemyStateManager.SwitchState(enemyStateManager.currentEnemy.actionState);
            }
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
