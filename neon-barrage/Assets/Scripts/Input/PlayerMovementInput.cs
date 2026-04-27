using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementInput : MonoBehaviour
{
    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool canJump = true;
    [SerializeField] private bool canDash = true;

    [Header("Buffer Timers")]
    [SerializeField] private float jumpBufferDuration = 0.2f;
    [SerializeField] private float dashBufferDuration = 0.2f;

    public bool CanMove => canMove;
    public bool CanJump => canJump;
    public bool CanDash => canDash;

    public bool IsEnabled { get; private set; }

    public float HorizontalMove { get; private set; }
    public Vector2 DashDirection { get; private set;  }
    public bool IsJumpPressed => jumpBufferTime > 0;
    public bool IsDashPressed => dashBufferTime > 0;

    private PlayerActions.MovementActions movementInput;

    // Buffers
    private float jumpBufferTime = 0;
    private float dashBufferTime = 0;


    private void OnEnable()
    {
        Enable();
    }

    private void OnDisable()
    {
        Disable();
    }

    public void Enable()
    {
        IsEnabled = true;


        movementInput = playerInputManager.Movement;
        movementInput.Enable();

        SetupInputActions();
    }

    public void Disable()
    {
        IsEnabled = false;

        CleanupInputActions();
        movementInput.Disable();

        HorizontalMove = 0;
        ResetJumpBuffer();
        ResetDashBuffer();
    }

    private void SetupInputActions()
    {
        if (canMove) movementInput.Move.Enable();
        else movementInput.Move.Disable();
        movementInput.Move.performed += OnMoveInputReceived;
        movementInput.Move.canceled += OnMoveInputReceived;

        if (canJump) movementInput.Jump.Enable();
        else movementInput.Jump.Disable();
        movementInput.Jump.performed += OnJumpInputReceived;

        if (canDash)
        {
            movementInput.Dash.Enable();
            movementInput.DashDirection.Enable();
        }
        else
        {
            movementInput.Dash.Disable();
            movementInput.DashDirection.Disable();
        }
        movementInput.Dash.performed += OnDashInputReceived;
        movementInput.DashDirection.performed += OnDashDirectionInputReceived;
        movementInput.DashDirection.canceled += OnDashDirectionInputReceived;
    }

    private void CleanupInputActions()
    {
        movementInput.Move.performed -= OnMoveInputReceived;
        movementInput.Move.canceled -= OnMoveInputReceived;

        movementInput.Jump.performed -= OnJumpInputReceived;

        movementInput.Dash.performed -= OnDashInputReceived;

        movementInput.DashDirection.performed -= OnDashDirectionInputReceived;
        movementInput.DashDirection.canceled -= OnDashDirectionInputReceived;
    }

    private void OnMoveInputReceived(InputAction.CallbackContext context)
    {
        HorizontalMove = context.ReadValue<float>();
    }

    private void OnJumpInputReceived(InputAction.CallbackContext context)
    {
        jumpBufferTime = jumpBufferDuration;
    }
    private void OnDashInputReceived(InputAction.CallbackContext context)
    {
        dashBufferTime = dashBufferDuration;
    }

    private void OnDashDirectionInputReceived(InputAction.CallbackContext context)
    {
        DashDirection = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        CountdownBuffers();
    }

    private void CountdownBuffers()
    {
        if (jumpBufferTime > 0) jumpBufferTime -= Time.deltaTime;
        if (dashBufferTime > 0) dashBufferTime -= Time.deltaTime;
    }

    public void ResetJumpBuffer() => jumpBufferTime = 0;
    public void ResetDashBuffer() => dashBufferTime = 0;
}