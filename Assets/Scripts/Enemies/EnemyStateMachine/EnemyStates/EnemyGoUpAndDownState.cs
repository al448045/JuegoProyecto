using UnityEngine;

public class EnemyGoUpAndDownState : EnemyState
{
    public override void EnterState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.enemyCapsuleCollider.enabled = false;
        enemyStateManager.currentEnemy.StartCoroutine(enemyStateManager.currentEnemy.MoveUpAndDown(enemyStateManager.currentEnemy.negativeVerticalOffset, enemyStateManager.currentEnemy.positiveVerticalOffset, 1f));
    }

    public override void ExitState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.StopAllCoroutines();
    }

    public override void UpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        if (enemyStateManager.currentEnemy.hasGoneUpAndDown)
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
