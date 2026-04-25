using UnityEngine;
using UnityEngine.InputSystem;

public class JumpAbility
{
    private readonly JumpAbilityData data;
    private readonly float gravity;
    private readonly float initialJumpVelocity;

    private float lastJumpRequestTime = 0;
    private float velocityY = 0;

    public JumpAbility(JumpAbilityData data)
    {
        if(data.JumpAction == null)
        {
            throw new System.ArgumentNullException("jumpAction", "Jump Input Action Reeference is not assigned.");
        }

        this.data = data;

        float timeToApex = data.JumpDuration / 2f;
        gravity = (-2f * data.MaxJumpHeight) / (timeToApex * timeToApex);
        initialJumpVelocity = (2 * data.MaxJumpHeight) / timeToApex;
    }

    public void Enable()
    {
        data.JumpAction.action.Enable();

        data.JumpAction.action.performed += OnJumpTriggered;
    }


    public void Disable()
    {
        data.JumpAction.action.performed -= OnJumpTriggered;

        data.JumpAction.action.Disable();
    }

    private void OnJumpTriggered(InputAction.CallbackContext context)
    {
        lastJumpRequestTime = Time.time;
    }

    public void Apply(ref Vector3 velocity, bool isGrounded)
    {
        if (isGrounded)
        {
            bool jumpRequested = (Time.time - lastJumpRequestTime) <= data.JumpInputBufferTime;
            velocity.y = velocityY = jumpRequested ? initialJumpVelocity : data.GroundStickGravity;
        }
        else
        {
            float prevY = velocityY;
            velocityY += gravity * Time.deltaTime;
            velocity.y = (prevY + velocityY) * 0.5f;
        }
    }
}
