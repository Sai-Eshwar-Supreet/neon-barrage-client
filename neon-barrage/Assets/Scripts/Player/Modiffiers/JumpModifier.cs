using UnityEngine;

public class JumpModifier : BasePlayerModifier<PlayerMovementContext>
{
    private readonly float gravity;
    private readonly float initialJumpVelocity;

    private float velocityY = 0;

    public JumpModifier(PlayerMovementContext ctx) : base(ctx)
    {
        float timeToApex = ctx.Stats.JumpDuration / 2f;
        gravity = (-2f * ctx.Stats.MaxJumpHeight) / (timeToApex * timeToApex);
        initialJumpVelocity = (2 * ctx.Stats.MaxJumpHeight) / timeToApex;
    }

    public override void OnExit()
    {
        // noop
    }

    public override void Update()
    {
        Vector3 vel = ctx.Velocity;
        if (ctx.Controller.isGrounded)
        {
            vel.y = velocityY = ctx.Input.IsJumpPressed ? initialJumpVelocity : ctx.Stats.GroundStickGravity;
            ctx.Input.ResetJumpBuffer();
        }
        else
        {
            float prevY = velocityY;
            velocityY += gravity * Time.deltaTime;
            vel.y = (prevY + velocityY) * 0.5f;
        }

        ctx.Velocity = vel;
    }
}
