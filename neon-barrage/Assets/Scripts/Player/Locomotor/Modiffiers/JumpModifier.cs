using UnityEngine;
using UnityEngine.InputSystem;

public class JumpModifier : BasePlayerModifier
{
    private readonly JumpAbilityData data;
    private readonly float gravity;
    private readonly float initialJumpVelocity;

    private float velocityY = 0;

    public JumpModifier(PlayerMovementContext ctx, JumpAbilityData data) : base(ctx)
    {
        this.data = data;

        float timeToApex = data.JumpDuration / 2f;
        gravity = (-2f * data.MaxJumpHeight) / (timeToApex * timeToApex);
        initialJumpVelocity = (2 * data.MaxJumpHeight) / timeToApex;
    }

    public override void Update()
    {
        if (ctx.Controller.isGrounded)
        {
            ctx.Velocity.y = velocityY = ctx.Input.IsJumpPressed ? initialJumpVelocity : data.GroundStickGravity;
            ctx.Input.ResetJumpBuffer();
        }
        else
        {
            float prevY = velocityY;
            velocityY += gravity * Time.deltaTime;
            ctx.Velocity.y = (prevY + velocityY) * 0.5f;
        }
    }
}
