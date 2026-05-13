using UnityEngine;

public class EnemyShootState : EnemyState
{
    private CustomTimer actionTimer = new CustomTimer();

    public override void EnterState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.SetAnimatorBool("IsAction", true);
        enemyStateManager.currentEnemy.ChangeActionState(false);
    }

    public override void ExitState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.SetAnimatorBool("IsAction", false);
        enemyStateManager.currentEnemy.ChangeShootingState(false);
    }

    public override void UpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        if (enemyStateManager.currentEnemy.isActionFinished)
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
