using UnityEngine;
public class DashModifier : BasePlayerModifier<PlayerMovementContext>
{
    private Vector3? dashVelocity = null;
    private bool IsDashing => dashVelocity.HasValue;
    private bool IsOnCooldown => Time.time < CooldownEndTime;
    private float CooldownEndTime => dashEndTime + ctx.Stats.DashCooldown;

    private float dashEndTime = 0;

    public DashModifier(PlayerMovementContext ctx) : base(ctx) { }

    public override void Update()
    {
        float now = Time.time;

        if(IsDashing && now > dashEndTime) dashVelocity = null;

        if (!IsDashing && IsOnCooldown) return;

        if (!IsDashing && ctx.Input.IsDashPressed)
        {
            dashVelocity = ctx.Input.DashDirection * ctx.Stats.DashSpeed;
            dashEndTime = now + ctx.Stats.DashDuration;
            ctx.Input.ResetDashBuffer();
            return;
        }
        
        if (IsDashing) ctx.Velocity = dashVelocity.Value;
    }

    public override void OnExit()
    {
        if (IsDashing)
        {
            dashEndTime = Time.time;
        }

        dashVelocity = null;
    }
}
