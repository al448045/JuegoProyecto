using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] public PlayerController playerController;

    public float playerSpeed;
    public float playerFriction;

    public float playerHealth;
    public float playerMaxHealth;

    public Vector2 playerMoveDirection;

    public Vector3 playerAttackOffset;

}


