using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class BaseEnemy : MonoBehaviour
{
    public Vector2 facingDirection;
    public bool isActionFinished;
    public bool hasGoneDown;
    public bool hasGoneUp;
    public bool isEnemyDead;
    public bool hasEnemyShooted;

    public EnemyState actionState;
    public GameObject enemyProjectile;
    public GameObject projectilePosition;

    [HideInInspector]
    public float enemyHealth;

    [SerializeField] public Animator animator;
    [SerializeField] public Rigidbody2D enemyRB2D;
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public EnemyStateManager enemyStateManager;


    public Hole currentHole;
    public Hole nextHole;

    public BaseEnemy()
    {
        isEnemyDead = false;
    }

    public void SetAnimatorBool(string Animation, bool value)
    {
        animator.SetBool(Animation, value);
    }

    public void UpdateAnimatorFacingVector()
    {
        animator.SetFloat("DirectionX", facingDirection.x);
        animator.SetFloat("DirectionY", facingDirection.y);
    }

    public virtual Hole FindNextHole()
    {
        return null;
    }
    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            EnemyWaveController.counter++;
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        currentHole.is_hole_occupied = false;
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerAttack playerAttack = collision.GetComponent<PlayerAttack>();

        if (playerAttack != null)
        {
            TakeDamage(playerAttack.damage);
        }
    }
}
