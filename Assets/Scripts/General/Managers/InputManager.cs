using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager: MonoBehaviour
{
    [SerializeField] private InputActionAsset InputActions;
    [SerializeField] public PlayerController playerController;

    public InputAction moveAction;
    public InputAction attackAction;
    public InputAction objectAction;

    private GameplayAsset gameplayActions;

    private void Awake()
    {
        gameplayActions = new GameplayAsset();
    }

    private void OnEnable()
    {
        moveAction = gameplayActions.Gameplay.Move;         // WASD
        attackAction = gameplayActions.Gameplay.Attack;     // SPACE
        objectAction = gameplayActions.Gameplay.Object;     // E

        moveAction.Enable();
        attackAction.Enable();
        objectAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        attackAction.Disable();
        objectAction.Disable();
    }

    private void Start()
    {

    }

    private void Update()
    {
       
    }
}
