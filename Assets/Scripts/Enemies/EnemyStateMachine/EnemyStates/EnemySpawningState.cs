using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawningState : EnemyState
{
    public override void EnterState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        enemyStateManager.currentEnemy.enemyCapsuleCollider.enabled = false;
    }

    public override void ExitState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {

    }

    public override void UpdateState(EnemyStateManager enemyStateManager, BaseEnemy Enemy)
    {
        // Down --> Up

        enemyStateManager.currentEnemy.StartCoroutine(enemyStateManager.currentEnemy.MoveUpOrDown(enemyStateManager.currentEnemy.transform.position, enemyStateManager.currentEnemy.currentHole.transform.position));

        //Up --> Down

        enemyStateManager.currentEnemy.StartCoroutine(enemyStateManager.currentEnemy.MoveUpOrDown(enemyStateManager.currentEnemy.currentHole.transform.position, enemyStateManager.currentEnemy.transform.position));
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
