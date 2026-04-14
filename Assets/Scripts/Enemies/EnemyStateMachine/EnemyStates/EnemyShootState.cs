using UnityEngine;

public class EnemyShootState : EnemyState
{
    private CustomTimer actionTimer = new CustomTimer();

    public override void EnterState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.SetAnimatorBool("IsAction", true);
    }

    public override void ExitState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.SetAnimatorBool("IsAction", false);
        enemyStateManager.currentEnemy.isActionFinished = true;
        enemyStateManager.currentEnemy.hasEnemyShooted = false;
    }

    public override void UpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.actionTimer.UpdateTimer();

        if (!enemyStateManager.currentEnemy.hasEnemyShooted)
        {
            GameObject.Instantiate(enemyStateManager.currentEnemy.enemyProjectile, enemyStateManager.currentEnemy.projectilePosition.transform.position, Quaternion.identity);
            enemyStateManager.currentEnemy.hasEnemyShooted = true;
        }

        else
        {
            if (enemyStateManager.currentEnemy.actionTimer.timerAmount <= 0f)
            {
                enemyStateManager.SwitchState(enemyStateManager.enemyIdleState);
            }
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
