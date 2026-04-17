using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class BaseEnemy : MonoBehaviour
{
    public Vector2 facingDirection;

    public bool isActionFinished;
    public bool isEnemyDead;
    public bool hasEnemyShooted;
    public bool hasChangedHole;

    public float showTime;
    public float enemyHealth;

    public CustomTimer idleTimer;

    public EnemyState actionState;
    public GameObject enemyProjectile;
    public GameObject projectilePosition;
    
    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody2D enemyRB2D;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public CapsuleCollider2D enemyCapsuleCollider;

    public EnemyStateManager enemyStateManager;

    public Hole currentHole;
    public Hole nextHole;

    public BaseEnemy()
    {
        isEnemyDead = false;
        isActionFinished = false;
        hasChangedHole = false;
        hasEnemyShooted = false;

        showTime = 0.5f;

        idleTimer = new CustomTimer();
    }

    public void SetAnimatorBool(string Animation, bool value)
    {
        animator.SetBool(Animation, value);
    }

    public void UpdateAnimatorFacingVector()
    {

        facingDirection = (GameManager.Instance.player.transform.position - transform.position).normalized;
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

    public IEnumerator MoveUpOrDown(Vector2 start, Vector2 end)
    {
        transform.localPosition = start;

        while (Mathf.Abs(start.y - end.y) <= 0.01f)
        {
            Debug.Log("Moving");
            transform.localPosition = Vector2.Lerp(start,end,0.5f);
            yield return null;
        }

        transform.localPosition = end;
    }
    public void ChangePosition(Hole nextHole)
    {
        transform.position = new Vector2(nextHole.transform.position.x, nextHole.transform.position.y + nextHole.HoleSize.y);
    }

    public void ChangeActionState(bool newActionState)
    {
        isActionFinished = newActionState;
    }

    public void ChangeShootingState(bool newShootState)
    {
        hasEnemyShooted = newShootState;
    }

    public void ChangeHoleState(bool newHoleState)
    {
        hasChangedHole = newHoleState;
    }


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        enemyRB2D = GetComponent<Rigidbody2D>();
        enemyCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerAttack playerAttack = collision.GetComponent<PlayerAttack>();

        if (playerAttack != null)
        {
            TakeDamage(playerAttack.damage);
        }
    }
}
