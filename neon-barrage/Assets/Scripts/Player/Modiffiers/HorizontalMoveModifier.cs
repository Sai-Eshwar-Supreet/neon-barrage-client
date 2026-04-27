using UnityEngine;

public class HorizontalMoveModifier : BasePlayerModifier<PlayerMovementContext>
{
    public HorizontalMoveModifier(PlayerMovementContext ctx) : base(ctx) { }

    public override void OnExit()
    {
        // noop
    }

    public override void Update()
    {
        float movementX = ctx.Input.HorizontalMove;
        Vector3 vel = ctx.Velocity;
        vel.x = ctx.Stats.MoveSpeed * movementX;
        ctx.Velocity = vel;
    }
}
