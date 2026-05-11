using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyIdleState : EnemyState
{
    public override void EnterState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.idleTimer.timerAmount = Random.Range(0.5f,2f);
    }

    public override void ExitState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {

    }

    public override void UpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        Debug.Log("Animator IsAction: " + enemyStateManager.currentEnemy.animator.GetBool("IsAction"));

        enemyStateManager.currentEnemy.idleTimer.UpdateTimer();

        if (enemyStateManager.currentEnemy.idleTimer.timerAmount <= 0f)
        {
            if (enemyStateManager.currentEnemy.isActionFinished)
            {
                enemyStateManager.SwitchState(enemyStateManager.enemyGoDownState);
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
