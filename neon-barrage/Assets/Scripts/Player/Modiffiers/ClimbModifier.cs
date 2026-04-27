using UnityEngine;

public class ClimbModifier : BasePlayerModifier<PlayerTraversalContext>
{
    public ClimbModifier(PlayerTraversalContext ctx) : base(ctx)
    {
    }

    public override void Update()
    {
        Vector3 vel = ctx.Velocity;
        vel.y = ctx.Stats.ClimbSpeed * ctx.Input.ClimbMove;
        ctx.Velocity = vel;
    }
}
