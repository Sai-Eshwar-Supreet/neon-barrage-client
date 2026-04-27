using UnityEngine;
public class DashModifier : BasePlayerModifier<PlayerMovementContext>
{
    private Vector3? dashVelocity = null;

    private float dashEndTime = 0;
    private float cooldownEndTime = 0;

    public DashModifier(PlayerMovementContext ctx) : base(ctx) { }

    public override void Update()
    {
        float now = Time.time;

        bool isDashing = dashVelocity.HasValue;
        bool isOnCooldown = Time.time < cooldownEndTime;

        if (!isDashing && !isOnCooldown && ctx.Velocity.sqrMagnitude > 0.01f && ctx.Input.IsDashPressed)
        {
            dashVelocity = ctx.Input.DashDirection * ctx.Stats.DashSpeed;
            dashEndTime = now + ctx.Stats.DashDuration;
            ctx.Input.ResetDashBuffer();
            return;
        }
        
        if (isDashing)
        {
            ctx.Velocity = dashVelocity.Value;

            if(now > dashEndTime)
            {
                dashVelocity = null;
                cooldownEndTime = now + ctx.Stats.DashCooldown;
            }
        }
    }
}
