using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInfo 
{
    public Color _idleColor;
    public Color _moveColor;
    public Color _attackColor;

    public SpriteRenderer _playerRenderer;
    public InputAction next;
    public bool IsSpacePressed = false;

    public PlayerInfo(Color idleColor, Color moveColor, Color attackColor, SpriteRenderer playerRenderer)
    {
        _idleColor = idleColor;
        _moveColor = moveColor;
        _attackColor = attackColor;
        _playerRenderer = playerRenderer;
        next = InputManager.debugStateActions.DebugStates.NextState;
        next.performed += NextState;
    }

    public void NextState(InputAction.CallbackContext callbackContext)
    {
        IsSpacePressed = true;
        Debug.Log("Espacio Presionado");
    }
}
