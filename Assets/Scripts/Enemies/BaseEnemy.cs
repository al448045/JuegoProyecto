using System.Collections;
using UnityEngine;


public class BaseEnemy : MonoBehaviour
{
    public Vector2 facingDirection;
    public Vector2 negativeVerticalOffset;
    public Vector2 positiveVerticalOffset;

    public bool isActionFinished;
    public bool isEnemyDead;
    public bool hasEnemyShooted;
    public bool hasChangedHole;
    public bool hasGoneDown;
    public bool hasGoneUp;
    public bool hasGoneUpAndDown;

    public int scoreAmount;

    public float showTime;
    public float enemyHealth;
    public float enemyMaxHealth;

    public CustomTimer idleTimer;

    public EnemyState actionState;
    public GameObject enemyProjectile;
    public GameObject projectilePosition;

    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody2D enemyRB2D;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public CapsuleCollider2D enemyCapsuleCollider;
    public EnemyUI enemyUI;

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
        scoreAmount = 100;
        enemyHealth = enemyMaxHealth;

        idleTimer = new CustomTimer();
    }

    #region Coroutines

    public IEnumerator MoveUpOrDown(Vector2 start, Vector2 end, float duration)
    {
        hasGoneDown = false;
        hasGoneUp = false;

        float elapsedTime = 0f;

        transform.localPosition = start;

        while (elapsedTime < duration)
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = end;

        hasGoneDown = true;
        hasGoneUp = true;
    }

    public IEnumerator MoveUpAndDown(Vector2 start, Vector2 end, float duration)
    {
        hasGoneUpAndDown = false;

        float elapsedTime = 0f;

        transform.localPosition = start;

        while (elapsedTime < duration)
        {
            spriteRenderer.transform.localPosition = Vector2.Lerp(start, end, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = end;

        yield return new WaitForSeconds(showTime);

        elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = start;

        hasGoneUpAndDown = true;
    }

    #endregion

    #region Animator Functions
    public void SetAnimatorBool(string Animation, bool value)
    {
        animator.SetBool(Animation, value);
    }

    public void UpdateAnimatorFacingVector()
    {
        facingDirection = (GameManager.Instance.player.transform.position - transform.position).normalized;
        if (facingDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    #endregion 

    #region Damage and Death
    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        enemyUI.SetHealth(enemyHealth / enemyMaxHealth);

        if (enemyHealth <= 0)
        {
            EnemyWaveController.counter++;
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        currentHole.is_hole_occupied = false;
        GameManager.Instance.scoreManager.UpdateScore(scoreAmount);
        Destroy(transform.parent.gameObject);
    }
    #endregion

    #region Position and Holes

    public virtual Hole FindNextHole()
    {
        return null;
    }
    public void ChangePosition(Hole nextHole)
    {
        gameObject.transform.parent.position = new Vector2(nextHole.holeSpriteRenderer.bounds.center.x, nextHole.transform.position.y);
    }

    #endregion 

    #region ChangeBools Functions
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

    #endregion

    #region UnityFuncions

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

    public void InitEnemy()
    {
        negativeVerticalOffset = new Vector2(0f, -spriteRenderer.bounds.size.y);
        positiveVerticalOffset = new Vector2(0f, spriteRenderer.bounds.size.y / 4);
    }

    #endregion
}
