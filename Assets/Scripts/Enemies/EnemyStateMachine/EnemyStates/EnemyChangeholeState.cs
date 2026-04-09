using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyChangeholeState : EnemyState
{
    public override void EnterState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.isActionFinished = false;
        enemyStateManager.currentEnemy.spriteRenderer.color = Color.red;

        enemyStateManager.currentEnemy.nextHole = enemyStateManager.currentEnemy.FindNextHole();
        GameManager.Instance.holeManager.ChangeHoleState(enemyStateManager.currentEnemy.currentHole, enemyStateManager.currentEnemy.nextHole);
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
            GameManager.Instance.holeManager.ChangeHoleState(enemyStateManager.currentEnemy.currentHole, enemyStateManager.currentEnemy.nextHole);
            enemyStateManager.currentEnemy.nextHole = null;
        }

        enemyStateManager.currentEnemy.StartCoroutine(enemyStateManager.currentEnemy.GoUp());

        if (enemyStateManager.currentEnemy.hasGoneUp)
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
