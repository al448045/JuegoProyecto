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

    [HideInInspector]
    public float actionTime;

    [HideInInspector]
    public float idleTime;

    [HideInInspector]
    public float changingTime;

    [HideInInspector]
    public float spawningTime;

    [SerializeField] public Animator animator;
    [SerializeField] public Rigidbody2D enemyRB2D;
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public EnemyStateManager enemyStateManager;


    public Hole currentHole;
    public Hole nextHole;

    public CustomTimer idleTimer;
    public CustomTimer actionTimer;
    public CustomTimer changingTimer;
    public CustomTimer spawningTimer;

    public BaseEnemy()
    {
        idleTimer = new CustomTimer(idleTime);
        actionTimer = new CustomTimer(actionTime);
        changingTimer = new CustomTimer(changingTime);
        spawningTimer = new CustomTimer(spawningTime);

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

    public void ChangePosition(Vector2 newPosition)
    {
        float verticalOffset = nextHole.HoleSize.y;
        transform.position = new Vector2(newPosition.x, newPosition.y + verticalOffset);
    }

    public IEnumerator GoDown()
    {
        for (float i = 1f; i >= 0; i -= 0.1f)
        {
            //spriteRenderer.color = new Vector4(1, 1, 1, i);
            yield return new WaitForSeconds(0.1f);
        }
        hasGoneDown = true;
    }

    public IEnumerator GoUp()
    {
        for (float i = 0f; i <= 1; i += 0.1f)
        {
            //spriteRenderer.color = new Vector4(1, 1, 1, i);
            yield return new WaitForSeconds(0.1f);
        }
        hasGoneUp = true;
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
