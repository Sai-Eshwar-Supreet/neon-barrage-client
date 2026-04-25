using UnityEngine;
using UnityEngine.InputSystem;

public class MoveAbility
{
    private readonly MoveAbilityData data;
    private float currentSpeed = 0;
    private float movementX = 0;

    public MoveAbility(MoveAbilityData data)
    {
        if(data.MoveInput == null)
        {
            throw new System.ArgumentNullException("moveInput", "Move Input Action Asset is not assigned.");
        }

        if (data.SprintInput == null)
        {
            throw new System.ArgumentNullException("sprintInput", "Sprint Input Action Asset is not assigned.");
        }

        this.data = data;
        currentSpeed = data.MoveSpeed;
    }


    public void Enable()
    {
        data.MoveInput.action.Enable();
        data.SprintInput.action.Enable();

        data.MoveInput.action.performed += OnMove;
        data.MoveInput.action.canceled += OnMove;
        data.SprintInput.action.performed += OnSprint;
        data.SprintInput.action.canceled += OnSprint;
    }
    public void Disable()
    {
        data.SprintInput.action.performed -= OnSprint;
        data.MoveInput.action.performed -= OnMove;

        data.MoveInput.action.performed -= OnMove;
        data.MoveInput.action.canceled -= OnMove;
        data.SprintInput.action.performed -= OnSprint;
        data.SprintInput.action.canceled -= OnSprint;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        movementX = context.ReadValue<Vector2>().x;
    }

    private void OnSprint(InputAction.CallbackContext context)
    {
        bool isSprintning = context.ReadValueAsButton();

        currentSpeed = isSprintning ? data.SprintSpeed : data.MoveSpeed;
    }

    public void Apply(ref Vector3 velocity)
    {
        velocity.x = currentSpeed * movementX;
    }
}
