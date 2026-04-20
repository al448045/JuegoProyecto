using UnityEngine;

public class EnemyGoDownState : EnemyState
{
    public override void EnterState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.StartCoroutine(enemyStateManager.currentEnemy.MoveUpOrDown(enemyStateManager.currentEnemy.positiveVerticalOffset, enemyStateManager.currentEnemy.negativeVerticalOffset, 1f));
    }

    public override void ExitState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.enemyCapsuleCollider.enabled = false;
        enemyStateManager.currentEnemy.StopAllCoroutines();
    }

    public override void UpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {

        if (enemyStateManager.currentEnemy.hasGoneDown)
        {
            enemyStateManager.SwitchState(enemyStateManager.enemyChangeholeState);
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
