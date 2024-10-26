using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

public class PlayerController : ITickable
{
    private PlayerMovement _playerMovement;
    private InputActions _inputActions;
    private InputAction _moveAction;

    private Vector2 _moveInput;

    [Inject]
    public PlayerController(PlayerMovement playerMovement, InputActions inputActions)
    {
        Debug.Log("Constructor");
        _playerMovement = playerMovement;
        _inputActions = inputActions;

        _moveAction = _inputActions.FindAction("Move");
        _moveAction.performed += OnMovePerformed;
        _moveAction.canceled += OnMoveCanceled;
        _moveAction.Enable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Debug.Log("OnMovePerformed");
        _moveInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _moveInput = Vector2.zero;
    }

    public void Tick()
    {
        Vector3 direction = new Vector3(_moveInput.x, 0, _moveInput.y);
        _playerMovement.Move(direction);
    }
}
