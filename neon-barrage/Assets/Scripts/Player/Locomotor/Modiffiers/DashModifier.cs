using System.Collections;
using UnityEngine;
public class DashModifier : BasePlayerModifier
{
    private readonly DashAbilityData data;
    private readonly WaitForSeconds waitDash;
    private readonly MonoBehaviour mb;

    private Vector3? dashVelocity = null;
    private float cooldownEndTime = 0;

    public DashModifier(PlayerMovementContext ctx, DashAbilityData data, MonoBehaviour mb) : base(ctx)
    {
        this.data = data;
        this.mb = mb;
        waitDash = new WaitForSeconds(data.DashDuration);
    }

    public override void Update()
    {
        bool isOnCooldown = Time.time < cooldownEndTime;

        if (ctx.Velocity.sqrMagnitude > 0 && ctx.Input.IsDashPressed && !dashVelocity.HasValue && !isOnCooldown)
        {
            dashVelocity = ctx.Input.DashDirection * data.DashSpeed;
            ctx.Input.ResetDashBuffer();
            mb.StartCoroutine(Dash());
        }
        
        if (dashVelocity.HasValue) ctx.Velocity = dashVelocity.Value;
    }

    private IEnumerator Dash()
    {
        yield return waitDash;
        cooldownEndTime = Time.time + data.DashCooldown;
        dashVelocity = null;
    }
}
