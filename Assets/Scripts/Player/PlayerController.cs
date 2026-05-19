using System.Collections;
using UnityEngine;

public class PlayerController: MonoBehaviour
{

    // REFERENCIAS

    [SerializeField] public InputManager inputManager;
    [SerializeField] public PlayerInfo playerInfo;
    [SerializeField] public PlayerStateManager playerStateManager;

    // COMPONENTES

    [SerializeField] public Rigidbody2D playerRB2D;
    [SerializeField] public Animator playerAnimator;
    [SerializeField] public SpriteRenderer playerSpriteRenderer;
    [SerializeField] public GameObject playerAttack;
    [SerializeField] public CapsuleCollider2D playerCollider;

    // BOOLEANOS

    public bool player_wants_move { get; private set; }
    public bool player_wants_attack { get; private set; }
    public bool player_wants_object { get; set; }
    public bool player_was_hurt;
    public bool player_was_killed;
    public bool player_stopped_hurting;

    private void Awake()
    {
        playerAttack.SetActive(false);
        playerInfo.playerAttackOffset = new Vector3(0, -1, 0);
    }

    private void Update()
    {
        // Boolean setting

        player_wants_move = inputManager.moveAction.ReadValue<Vector2>() != Vector2.zero;
        player_wants_object = inputManager.objectAction.triggered;
        player_wants_attack = inputManager.attackAction.triggered;


        // Animator

        playerAnimator.SetFloat("Horizontal", playerInfo.playerMoveDirection.x);
        playerAnimator.SetFloat("Vertical", playerInfo.playerMoveDirection.y);
        playerAnimator.SetFloat("Speed", playerRB2D.linearVelocity.sqrMagnitude);

        playerAnimator.SetBool("Attack", player_wants_attack);
        playerAnimator.SetBool("Hurt", player_was_hurt);
        playerAnimator.SetBool("Object", player_wants_object);
        playerAnimator.SetBool("Dead", player_was_killed); 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Hurt"))
        {
            if (playerInfo.playerHealth > 0.0)
            {
                playerInfo.playerHealth -= 1;
                SetPlayerHealth(playerInfo.playerHealth);
                player_was_hurt = true;
            }

            if (playerInfo.playerHealth <= 0.0)
            {
                player_was_killed = true;
            }
        }
    }

    private void SetPlayerHealth(int currentHealth)
    {
        UIHandler.Instance.ChangePlayerHealthbar(currentHealth);
    }

    public void DeceleratePlayer()
    {
        playerRB2D.linearVelocity -= playerInfo.playerFriction * playerRB2D.linearVelocity;
    }

    public IEnumerator PlayerWasHurt()
    {
        player_stopped_hurting = false;
        float time = 0f;
        while (time < 1f)
        {
            if (playerSpriteRenderer.color == Color.white)
            {
                playerSpriteRenderer.color = Color.red; 
            }

            else
            {
                playerSpriteRenderer.color = Color.white;
            }

            time += 0.2f;
            yield return new WaitForSeconds(0.2f);
        }
        playerSpriteRenderer.color = Color.white;
        player_stopped_hurting = true;
    }
}   
