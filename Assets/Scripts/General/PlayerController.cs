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

    // BOOLEANOS

    public bool player_wants_move { get; private set; }
    public bool player_wants_attack { get; private set; }
    public bool player_wants_object { get; set; }
    public bool player_was_hurt;
    public bool player_was_killed;

    private void Start()
    {

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

    private void FixedUpdate()
    {

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Hurt"))
        {
            if (playerInfo.playerHealth > 0.0)
            {
                playerInfo.playerHealth -= 10.0f;
                player_was_hurt = true;
            }

            if (playerInfo.playerHealth <= 0.0)
            {
                player_was_killed = true;
            }

            Debug.Log("Player health = " + playerInfo.playerHealth);
            Debug.Log("Muerto? " + player_was_killed);
        }
    }

    public void DeceleratePlayer()
    {
        playerRB2D.linearVelocity -= playerInfo.playerFriction * playerRB2D.linearVelocity;
    }
}   
