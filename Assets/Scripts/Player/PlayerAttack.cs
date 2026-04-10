using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float damage = 10.0f;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    private void Start()
    {
        transform.localPosition = playerController.playerInfo.playerMoveDirection;
    }

    private void FixedUpdate()
    {
        Vector3 playerAttackVector3 = Vector3.left * playerController.playerInfo.playerMoveDirection.x + Vector3.down * playerController.playerInfo.playerMoveDirection.y;
        playerController.playerAttack.transform.rotation = Quaternion.LookRotation(Vector3.forward, playerAttackVector3);

        if (playerController.playerRB2D.linearVelocity == Vector2.zero)
        {
            playerController.playerAttack.transform.position = playerController.transform.position + playerController.playerInfo.playerAttackOffset;
        }

        else
        {
            playerController.playerAttack.transform.localPosition = playerController.playerInfo.playerMoveDirection;
        }
    }
}
