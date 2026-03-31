using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] public PlayerController playerController;

    public float playerSpeed;
    public float playerFriction;

    public float playerHealth;

    public Vector2 playerMoveDirection;

}


