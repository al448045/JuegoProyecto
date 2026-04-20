using UnityEngine;

public class EnemyGoUpState : EnemyState
{
    public override void EnterState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.enemyCapsuleCollider.enabled = true;
        enemyStateManager.currentEnemy.StartCoroutine(enemyStateManager.currentEnemy.MoveUpOrDown(enemyStateManager.currentEnemy.negativeVerticalOffset, enemyStateManager.currentEnemy.positiveVerticalOffset, 1f));
    }

    public override void ExitState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.StopAllCoroutines();
    }

    public override void UpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {

        if (enemyStateManager.currentEnemy.hasGoneUp)
        {
            enemyStateManager.SwitchState(enemyStateManager.enemyIdleState);
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
