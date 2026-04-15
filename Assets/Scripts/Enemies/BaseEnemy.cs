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
    public float verticalOffset;


    public EnemyState actionState;
    public GameObject enemyProjectile;
    public GameObject projectilePosition;
    
    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody2D enemyRB2D;
    [HideInInspector] public SpriteRenderer spriteRenderer;

    [SerializeField] public EnemyStateManager enemyStateManager;

    public Hole currentHole;
    public Hole nextHole;

    public BaseEnemy()
    {
        isEnemyDead = false;
        showTime = 0.5f;
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

    public IEnumerator MoveUpOrDown(Vector2 start, Vector2 end, float duration, float time)
    {
        transform.localPosition = start;

        float elapsedTime = 0f;
        while (elapsedTime < time)
        {
            transform.localPosition = Vector2.Lerp(start,end, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = end;
    }
    public void ChangePosition(Hole nextHole)
    {
        transform.position = new Vector2(nextHole.transform.position.x, nextHole.transform.position.y + verticalOffset);
    }


    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        enemyRB2D = GetComponent<Rigidbody2D>();
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
