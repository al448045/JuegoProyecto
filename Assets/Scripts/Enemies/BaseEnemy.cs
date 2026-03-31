using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class BaseEnemy : MonoBehaviour
{
    public Vector2 facingDirection;
    public bool isActionFinished;

    [SerializeField] public float enemyHealth;
    [SerializeField] public float actionTime;
    [SerializeField] public float idleTime;
    [SerializeField] public float changingTime;


    [SerializeField] public Animator animator;
    [SerializeField] public Rigidbody2D enemyRB2D;
    [SerializeField] public SpriteRenderer spriteRenderer;


    [SerializeField] public GameManager gameManager;
    [SerializeField] public EnemyStateManager enemyStateManager;

    public CustomTimer idleTimer;
    public CustomTimer actionTimer;
    public CustomTimer changingTimer;

    public BaseEnemy()
    {
        idleTimer = new CustomTimer(idleTime);
        actionTimer = new CustomTimer(actionTime);
        changingTimer = new CustomTimer(changingTime);
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

    public virtual Vector2 FindNextHole() 
    {
        return Vector2.zero;
    }

    public void ChangePosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }
}
