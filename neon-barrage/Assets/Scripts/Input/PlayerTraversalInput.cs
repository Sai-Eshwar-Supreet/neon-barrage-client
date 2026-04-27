using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTraversalInput : MonoBehaviour
{

    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] private bool canClimb = true;

    public bool CanClimb => canClimb;

    public bool IsEnabled { get; private set; }

    public bool IsClimbPressed { get; private set; } = false;
    public float ClimbMove { get; private set; }

    private PlayerActions.TraversalActions traversalInput;


    private void OnEnable() => Enable();
    private void OnDisable() => Disable();

    public void Enable()
    {
        IsEnabled = true;

        traversalInput = playerInputManager.Traversal;
        traversalInput.Enable();

        SetupInputActions();
    }

    public void Disable()
    {
        IsEnabled = false;

        CleanupInputActions();
        traversalInput.Disable();
    }

    private void SetupInputActions()
    {

        if (canClimb)
        {
            traversalInput.Climb.Enable();
            traversalInput.ClimbMove.Enable();
        }
        else
        {
            traversalInput.Climb.Disable();
            traversalInput.ClimbMove.Disable();
        }
        traversalInput.Climb.performed += OnClimbInputReceived;
        traversalInput.Climb.canceled += OnClimbInputReceived;
        traversalInput.ClimbMove.performed += OnClimbMoveInputReceived;
        traversalInput.ClimbMove.canceled += OnClimbMoveInputReceived;
    }

    private void CleanupInputActions()
    {
        traversalInput.Climb.performed -= OnClimbInputReceived;
        traversalInput.Climb.canceled -= OnClimbInputReceived;
        traversalInput.ClimbMove.performed -= OnClimbMoveInputReceived;
        traversalInput.ClimbMove.canceled -= OnClimbMoveInputReceived;
    }

    private void OnClimbInputReceived(InputAction.CallbackContext context)
    {
        IsClimbPressed = context.ReadValueAsButton();
    }

    private void OnClimbMoveInputReceived(InputAction.CallbackContext context)
    {
        ClimbMove = context.ReadValue<float>();
    }
}
